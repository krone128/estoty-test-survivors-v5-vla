using Code.Gameplay.Characters.Heroes.Services;
using Code.Gameplay.PlayerLevelUp.PlayerUpgrade.Behaviour;
using UnityEngine;

namespace Code.Gameplay.PlayerLevelUp.PlayerUpgrade
{
    public class OrbitalPlayerUpgrade : PlayerUpgrade
    {
        private int OrbitalMaxCount;
        private float OrbitalSpeed;
        private float OrbitalRadius;
        private float OrbitalRespawnInterval;
        
        public OrbitalPlayerUpgrade(int maxLevel, int orbitalMaxCount, float orbitRadius, float speed, float respawnInterval, string description, Sprite icon)
            : base(maxLevel, description, icon)
        {
            OrbitalSpeed = speed;
            OrbitalRadius = orbitRadius;
            OrbitalMaxCount = orbitalMaxCount;
            OrbitalRespawnInterval = respawnInterval;
            Presenter.Description = string.Format(description, orbitalMaxCount);
        }

        public override void Remove(IHeroProvider heroProvider)
        {
            heroProvider.Hero.GetComponent<OrbitalProjectileSpawner>().enabled = false;
        }

        protected override void ApplyToTarget(IHeroProvider heroProvider)
        {
            var component = heroProvider.Hero.GetComponent<OrbitalProjectileSpawner>();
            component.enabled = true;
            component.Initialize(OrbitalMaxCount, OrbitalSpeed, OrbitalRadius, OrbitalRespawnInterval);
        }
    }
}