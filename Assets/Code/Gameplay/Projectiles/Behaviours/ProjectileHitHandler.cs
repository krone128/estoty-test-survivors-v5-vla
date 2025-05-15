using System;
using System.Linq;
using Code.Gameplay.Lifetime.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Projectiles.Behaviours
{
	[RequireComponent(typeof(IDamageApplier))]
	public class ProjectileHitHandler : MonoBehaviour, IDestroyNotify
	{
		[SerializeField] private float _delay;
		[SerializeField] private ProjectileHitDispatcherBase[] _projectileDispatchers;
		
		public event Action OnDestroy;
		
		private IDamageApplier _damageApplier;

		private void Awake()
		{
			_damageApplier = GetComponent<IDamageApplier>();
		}

		private void OnEnable()
		{
			_damageApplier.OnDamageApplied += HandleDamageApplied;
		}

		private void OnDisable()
		{
			_damageApplier.OnDamageApplied -= HandleDamageApplied;
		}

		private void HandleDamageApplied(Health damage, int targetId)
		{
			if (_projectileDispatchers.Any(projectileDispatcher => projectileDispatcher.Dispatch(targetId)))
				return;
			
			OnDestroy?.Invoke();
			Destroy(gameObject, _delay);
		}
	}
}