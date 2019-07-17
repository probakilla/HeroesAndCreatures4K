using SwaggAndCreaturesLib.Characters;
using SwaggAndCreaturesLib.Team.TeamExceptions;
using System.Collections.Generic;

namespace SwaggAndCreaturesLib.Team {
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
    }
}
