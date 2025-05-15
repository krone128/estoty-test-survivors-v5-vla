using Code.Gameplay.Movement.Behaviours;
using Code.Gameplay.Vision.Behaviours;

namespace Code.Gameplay.Combat.Dispatchers
{
    public class ProjectileHitBounceDispatcher : ProjectileHitDispatcherBase
    {
        private IMovementDirectionProvider _projectileMovement;
        private VisionSight _visionSight;

        private void Awake()
        {
            _projectileMovement = GetComponent<IMovementDirectionProvider>();
            _visionSight = GetComponent<VisionSight>();
        }
        
        protected override void DispatchEffect(int targetId)
        {
            var newTarget = _visionSight.GetClosestEnemy(targetId);
            if (!newTarget)
            {
                Complete();
                return;
            }
            var direction = (newTarget.transform.position - transform.position).normalized;
            _projectileMovement.SetDirection(direction);
        }
    }
}