using Code.Gameplay.UnitStats;
using Code.Gameplay.UnitStats.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Projectiles.Behaviours
{
    public abstract class ProjectileHitDispatcherBase : MonoBehaviour
    {
        [SerializeField] private StatType _maxHitsStat;
        [SerializeField] private Stats _stats;

        private int MaxHits => Mathf.RoundToInt(_stats.GetStat(_maxHitsStat));
        private int CurrentHit { get; set; }

        public bool Dispatch(int hitId)
        {
            if (CurrentHit >= MaxHits) return false;
            CurrentHit++;
            DispatchEffect(hitId);
            return true;
        }
        
        
        public void ResetCounter()
        {
            CurrentHit = 0;
        }

        protected void Complete()
        {
            CurrentHit = MaxHits;
        }
        
        protected abstract void DispatchEffect(int targetId);
    }
}