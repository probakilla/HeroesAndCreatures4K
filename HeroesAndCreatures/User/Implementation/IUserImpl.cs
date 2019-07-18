using HeroesAndCreatures.Characters;
using System.Collections.Generic;

namespace HeroesAndCreatures.User {
    public interface IUserImpl {
        List<AbstractCharacter> Team { get; }

        AbstractCharacter GetNextToAttack();
        void IncreaseAllInitiative();
        void Play(List<AbstractCharacter> oppositeTeam);
    }
}
