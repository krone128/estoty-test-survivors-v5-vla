using Code.Gameplay.Identification.Behaviours;
using Code.Gameplay.Movement.Behaviours;
using Code.Gameplay.Projectiles.Behaviours;
using Code.Gameplay.Teams;
using Code.Gameplay.Teams.Behaviours;
using Code.Gameplay.UnitStats;
using Code.Gameplay.UnitStats.Behaviours;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identification;
using Code.Infrastructure.Instantiation;
using UnityEngine;

namespace Code.Gameplay.Projectiles.Services
{
	public class ProjectileFactory : IProjectileFactory
	{	
		private readonly IInstantiateService _instantiateService;
		private readonly IIdentifierService _identifiers;
		private readonly IAssetsService _assetsService;

		public ProjectileFactory(
			IInstantiateService instantiateService,
			IIdentifierService identifiers,
			IAssetsService assetsService)
		{
			_instantiateService = instantiateService;
			_identifiers = identifiers;
			_assetsService = assetsService;
		}
		
		public Projectile CreateProjectile(Vector3 at, Vector2 direction, TeamType teamType,
			float damage, float movementSpeed, float bounceStat, float piercingStat)
		{
			var prefab = _assetsService.LoadAssetFromResources<Projectile>("Projectiles/Projectile");
			Projectile projectile = _instantiateService.InstantiatePrefabForComponent(prefab, at, Quaternion.FromToRotation(Vector3.up, direction));
			
			projectile.GetComponent<Id>()
				.Setup(_identifiers.Next());

			projectile.GetComponent<Stats>()
				.SetBaseStat(StatType.MovementSpeed, movementSpeed)
				.SetBaseStat(StatType.Damage, damage)
				.SetBaseStat(StatType.ProjectileBounce, bounceStat)
				.SetBaseStat(StatType.ProjectilePiercing, piercingStat)
				.SetBaseStat(StatType.VisionRange, 10);

			projectile.GetComponent<Team>()
				.Type = teamType;
			projectile.GetComponent<SettableMovementDirection>()
				.SetDirection(direction);
			
			return projectile;
		}
		
		public Projectile SpawnOrbitalProjectile(Transform parentTransform, TeamType teamType,
			float damage)
		{
			var prefab = _assetsService.LoadAssetFromResources<Projectile>("Projectiles/OrbitalProjectile");
			var projectile = _instantiateService.InstantiatePrefabForComponent(prefab, parentTransform.position,
				Quaternion.identity, parentTransform);
			projectile.gameObject.name = "Orbital";
			
			projectile.GetComponent<Id>()
				.Setup(_identifiers.Next());

			projectile.GetComponent<Stats>()
				.SetBaseStat(StatType.MovementSpeed, 0)
				.SetBaseStat(StatType.Damage, damage)
				.SetBaseStat(StatType.ProjectileBounce, 0)
				.SetBaseStat(StatType.ProjectilePiercing, 0)
				.SetBaseStat(StatType.VisionRange, 0);

			projectile.GetComponent<Team>()
				.Type = teamType;
			
			return projectile;
		}
	}
}