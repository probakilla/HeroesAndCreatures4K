using SwaggAndCreaturesLib.Characters;
using SwaggAndCreaturesLib.Team.TeamExceptions;
using System.Collections.Generic;
using System.Linq;

namespace SwaggAndCreaturesLib.Team {
    public class CharacterTeam {
        public static readonly int TEAM_LENGTH = 4;

        public List<ICharacter> Team { get; private set; }

        public CharacterTeam() => Team = new List<ICharacter>();

        public void InsertCharacter(ICharacter characterToAdd, bool isPlayerTeam) {
            if (!IsFull()) {
                Team.Add(characterToAdd);
                int place = Team.IndexOf(characterToAdd);
                characterToAdd.CharacterPlace = isPlayerTeam ? place + TEAM_LENGTH : place;
            } else {
                throw new FullTeamException("This team is full");
            }
        }

        public void RemoveCharacter(ICharacter characterToRemove) => Team.Remove(characterToRemove);

        public bool IsFull() => Team.Count >= TEAM_LENGTH;

        public ICharacter GetNextToAttack() => Team.First(character => character.Initiative == Team.Max(c => c.Initiative));

        public void IncreaseAllInitiative() => Team.ForEach(character => character.IncreaseInitiative());
    }
}
