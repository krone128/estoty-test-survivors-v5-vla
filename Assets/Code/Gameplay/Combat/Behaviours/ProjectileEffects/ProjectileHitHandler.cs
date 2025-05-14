using Code.Gameplay.Combat.Dispatchers;
using UnityEngine;

namespace Code.Gameplay.Lifetime.Behaviours
{
	[RequireComponent(typeof(IDamageApplier))]
	public class ProjectileHitHandler : MonoBehaviour
	{
		[SerializeField] private float _delay;
		[SerializeField] private ProjectileHitDispatcherBase[] _projectileDispatchers;
		
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
			foreach (var projectileDispatcher in _projectileDispatchers)
			{
				if (projectileDispatcher.Dispatch(targetId))
				{
					return;
				}
			}
			
			Destroy(gameObject, _delay);
		}
	}
}