using SwaggAndCreaturesLib.Characters;
using System.Collections.Generic;

namespace SwaggAndCreaturesLib.User
{
    public interface IUser
    {
        List<ICharacter> Team { get; }

        ICharacter GetNextToAttack();
        void IncreaseAllInitiative();
        void Play(List<ICharacter> oppositeTeam);
    }
}
