using System;
using Code.Gameplay.Lifetime.Behaviours;
using Code.Gameplay.UnitStats.Behaviours;

namespace Code.Gameplay.Characters.Heroes.Services
{
	public interface IHeroProvider
	{
		public event Action OnLevelUp;
		
		Behaviours.Hero Hero { get; }
		Health Health { get; }
		Stats Stats { get; }
		PlayerExperience Experience { get; }
		PlayerAbilities Abilities { get; }
		void SetHero(Behaviours.Hero hero);
	}
}