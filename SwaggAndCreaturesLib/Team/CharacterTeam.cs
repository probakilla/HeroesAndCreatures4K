using SwaggAndCreaturesLib.Characters;
using SwaggAndCreaturesLib.Team.TeamExceptions;
using System.Collections.Generic;

namespace SwaggAndCreaturesLib.Team {
    public class CharacterTeam {
        public static readonly int TEAM_LENGTH = 4;

        public List<AbstractCharacter> Team { get; private set; }

        public CharacterTeam() => Team = new List<AbstractCharacter>();

        public void InsertCharacter(AbstractCharacter characterToAdd, bool isPlayerTeam) {
            if (!IsFull()) {
                Team.Add(characterToAdd);
                int place = Team.IndexOf(characterToAdd);
                characterToAdd.CharacterPlace = isPlayerTeam ? place + TEAM_LENGTH : place;
            } else {
                throw new FullTeamException("This team is full");
            }
        }

        public void RemoveCharacter(AbstractCharacter characterToRemove) {
            Team.Remove(characterToRemove);
        }

        public bool IsFull() {
            return Team.Count >= TEAM_LENGTH;
        }

        public AbstractCharacter GetNextToAttack() {
            int maxInitiative = -1;
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
