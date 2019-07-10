using System.Collections.Generic;
using System.Linq;
using SwaggAndCreaturesLib.Characters;

namespace SwaggAndCreaturesLib.User
{
    public abstract class AbstractUser : IUser
    {
        public List<ICharacter> Team { get; private set; }

        protected AbstractUser(List<ICharacter> team) => Team = team;

        public ICharacter GetNextToAttack() => Team.First(character => character.Initiative == Team.Max(c => c.Initiative));

        public void IncreaseAllInitiative() => Team.ForEach(character => character.IncreaseInitiative());

        public abstract void Play(List<ICharacter> oppositeTeam);
    }
}
