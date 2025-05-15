using Code.Gameplay.Projectiles.Behaviours;
using Code.Gameplay.Teams;
using UnityEngine;

namespace Code.Gameplay.Projectiles.Services
{
	public interface IProjectileFactory
	{
		Projectile CreateProjectile(Vector3 at, Vector2 direction, TeamType teamType, float damage, float movementSpeed,
			float bounceStat, float piercingStat);

		Projectile SpawnOrbitalProjectile(Transform parentTransform, TeamType teamType, float damage);
	}
}