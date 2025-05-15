using System;
using System.Threading.Tasks;
using Code.Gameplay.UnitStats;
using Code.Gameplay.UnitStats.Behaviours;
using Code.Infrastructure;
using UnityEngine;

namespace Code.Gameplay.Lifetime.Behaviours
{
	[RequireComponent(typeof(Stats))]
	public class PlayerExperience : MonoBehaviour
	{
		[field: SerializeField] public int PlayerLevel { get; private set; } = 1;
		[field: SerializeField] public float CurrentExperience { get; private set; }
		[field: SerializeField] public float LevelUpExperience { get; private set; }

		private Stats _stats;

		public event Action<int> OnLevelUp;

		private void Awake()
		{
			_stats = GetComponent<Stats>();
			
			_stats.OnStatChanged += HandleStatChanged;
		}

		private void OnDestroy()
		{
			_stats.OnStatChanged -= HandleStatChanged;
		}

		public void AddExperience(float amount)
		{
			CurrentExperience += amount;
			while (CurrentExperience >= LevelUpExperience) LevelUpPlayer();
		}
		
		private void LevelUpPlayer()
		{
			CurrentExperience -= LevelUpExperience;
			++PlayerLevel;
			OnLevelUp?.Invoke(PlayerLevel);
		}

		private void HandleStatChanged(StatType statType, float value)
		{
			if (statType == StatType.LevelUpExperience)
			{
				LevelUpExperience = value;
			}
		}
	}
}