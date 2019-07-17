using SwaggAndCreaturesLib.Characters;
using System.Collections.Generic;

namespace SwaggAndCreaturesLib.User {
    public interface IUserImpl {
        List<AbstractCharacter> Team { get; }

        AbstractCharacter GetNextToAttack();
        void IncreaseAllInitiative();
        void Play(List<AbstractCharacter> oppositeTeam);
    }
}
