using HeroesAndCreatures.Characters;
using System.Collections.Generic;

namespace HeroesAndCreatures.User {
    public abstract class AbstractUser {
        private readonly IUserImpl Implementation;

        protected AbstractUser(IUserImpl user) {
            Implementation = user;
        }

        public virtual AbstractCharacter GetNextToAtack() {
            return Implementation.GetNextToAttack();
        }

        public virtual void IncreaseAllInitiative() {
            Implementation.IncreaseAllInitiative();
        }

        public void Play(List<AbstractCharacter> oppositeTeam) {
            Implementation.Play(oppositeTeam);
        }
    }
}
