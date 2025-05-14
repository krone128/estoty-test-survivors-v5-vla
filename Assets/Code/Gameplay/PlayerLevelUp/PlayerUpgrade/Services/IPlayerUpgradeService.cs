using System.Collections.Generic;

namespace Code.Infrastructure
{
    public interface IPlayerUpgradeService
    {
        public void ApplyPlayerUpgrade(IPlayerUpgrade playerUpgrade);
    }
}