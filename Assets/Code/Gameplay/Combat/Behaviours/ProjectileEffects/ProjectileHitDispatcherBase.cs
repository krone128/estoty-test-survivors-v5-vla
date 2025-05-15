using Code.Gameplay.UnitStats;
using Code.Gameplay.UnitStats.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Combat.Dispatchers
{
    public abstract class ProjectileHitDispatcherBase : MonoBehaviour
    {
        [SerializeField] private StatType _maxHitsStat;
        [SerializeField] private Stats _stats;
        
        public int MaxHits => Mathf.RoundToInt(_stats.GetStat(_maxHitsStat));
        public int CurrentHit { get; set; }


        public bool Dispatch(int hitId)
        {
            if (CurrentHit >= MaxHits) return false;
            CurrentHit++;
            DispatchEffect(hitId);
            return true;
        }

        protected void Complete()
        {
            CurrentHit = MaxHits;
        }

        public void ResetCounter()
        {
            CurrentHit = 0;
        }
        
        protected abstract void DispatchEffect(int targetId);
    }
}