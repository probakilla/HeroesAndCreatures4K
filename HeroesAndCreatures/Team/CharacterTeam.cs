using HeroesAndCreatures.Characters;
using HeroesAndCreatures.Team.TeamExceptions;
using System;
using System.Collections.Generic;

namespace HeroesAndCreatures.Team {
    public class CharacterTeam {

        public List<AbstractCharacter> Team { get; private set; }

        public CharacterTeam() {
            Team = new List<AbstractCharacter>();
        }

        public void InsertCharacter(AbstractCharacter characterToAdd, bool isPlayerTeam) {
            if (!IsFull()) {
                Team.Add(characterToAdd);
                int place = Team.IndexOf(characterToAdd);
                characterToAdd.CharacterPlace = isPlayerTeam ? place + TeamConsts.MaxTeamLength : place;
            } else {
                throw new FullTeamException();
            }
        }

        public void ReplaceCharacter(AbstractCharacter character, int place, bool isPlayerTeam) {
            character.CharacterPlace = isPlayerTeam ? place + TeamConsts.MaxTeamLength : place;
            Team.Insert(place, character);
        }

        public void RemoveCharacter(AbstractCharacter characterToRemove) {
            Team.Remove(characterToRemove);
        }

        public bool IsFull() {
            return Team.Count >= TeamConsts.MaxTeamLength;
        }

        public AbstractCharacter GetNextToAttack() {
            int maxInitiative = TeamConsts.ImpossibleInitiative;
            AbstractCharacter choosenOne = null;
            foreach(AbstractCharacter character in Team) {
                if (character.Initiative > maxInitiative && ! character.IsDead()) {
                    maxInitiative = character.Initiative;
                    choosenOne = character;
                }
            }
            return choosenOne;
        }

        public void IncreaseAllInitiative() {
            Team.ForEach(character => character.IncreaseInitiative());
        }

        public bool IsInTeamRange(int place) {
            return place >= 0 || place < TeamConsts.MaxTeamLength;
        }
    }
}
