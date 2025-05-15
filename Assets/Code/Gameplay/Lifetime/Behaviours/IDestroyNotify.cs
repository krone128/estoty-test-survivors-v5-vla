using System;

namespace Code.Gameplay.Lifetime.Behaviours
{
    public interface IDestroyNotify
    {
        public event Action OnDestroy;
    }
}