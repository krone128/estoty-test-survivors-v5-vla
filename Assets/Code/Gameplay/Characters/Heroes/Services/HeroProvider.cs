using System;
using Code.Gameplay.Lifetime.Behaviours;
using Code.Gameplay.UnitStats.Behaviours;

namespace Code.Gameplay.Characters.Heroes.Services
{
	public class HeroProvider : IHeroProvider
	{
		public event Action OnLevelUp;
		
		public Behaviours.Hero Hero { get; private set; }
		public Health Health { get; private set; }
		public PlayerExperience Experience { get; private set; }
		public PlayerAbilities Abilities { get; private set; }
		public Stats Stats { get; private set; }

		public void SetHero(Behaviours.Hero hero)
		{
			Hero = hero;
			Health = hero.GetComponent<Health>();
			Experience = hero.GetComponent<PlayerExperience>();
			Abilities = hero.GetComponent<PlayerAbilities>();
			Stats = hero.GetComponent<Stats>();

			Experience.OnLevelUp += InvokeLevelUp;
		}

		private void InvokeLevelUp(int playerLevel)
		{
			OnLevelUp?.Invoke();
		}
	}
}