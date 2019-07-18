using HeroesAndCreatures.Characters;
using HeroesAndCreatures.Team;
using System.Collections.Generic;

namespace HeroesAndCreatures.User {
    public abstract class AbstractUserImpl : IUserImpl {
        private readonly CharacterTeam UserTeam;

        public List<AbstractCharacter> Team {
            get => UserTeam.Team;
        }

        protected AbstractUserImpl(CharacterTeam team) {
            UserTeam = team;
        }

        public AbstractCharacter GetNextToAttack() {
            return UserTeam.GetNextToAttack();
        }

        public void IncreaseAllInitiative() {
            UserTeam.IncreaseAllInitiative();
        }

        public abstract void Play(List<AbstractCharacter> oppositeTeam);

        protected virtual bool IsTargetValid(List<AbstractCharacter> team, int target) {
            return !team[target].IsDead();
        }
    }
}
