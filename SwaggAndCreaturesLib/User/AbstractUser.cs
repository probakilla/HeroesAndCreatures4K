﻿using SwaggAndCreaturesLib.Characters;
using SwaggAndCreaturesLib.Team;
using System.Collections.Generic;

namespace SwaggAndCreaturesLib.User {
    public abstract class AbstractUser : IUser {
        private readonly CharacterTeam UserTeam;

        public List<ICharacter> Team {
            get => UserTeam.Team;
        }

        protected AbstractUser(CharacterTeam team) => UserTeam = team;

        public ICharacter GetNextToAttack() => UserTeam.GetNextToAttack();

        public void IncreaseAllInitiative() => UserTeam.IncreaseAllInitiative();

        public abstract void Play(List<ICharacter> oppositeTeam);

        protected bool IsTargetValid(List<ICharacter> team, int target) {
            return !team[target].IsDead();
        }
    }
}
