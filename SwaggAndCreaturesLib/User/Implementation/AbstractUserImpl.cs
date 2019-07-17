using SwaggAndCreaturesLib.Characters;
using SwaggAndCreaturesLib.Team;
using System.Collections.Generic;

namespace SwaggAndCreaturesLib.User {
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

        protected bool IsTargetValid(List<AbstractCharacter> team, int target) {
            return !team[target].IsDead();
        }
    }
}
