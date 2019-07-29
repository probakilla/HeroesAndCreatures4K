using HeroesAndCreatures.Characters;
using System;
using System.Text;

namespace HeroesAndCreatures.Team.TeamBuilder {
    class CharacterTeamBuilder : ITeamBuilder {
        private readonly bool IsPlayerTeam;
        private CharacterTeam Team;

        public CharacterTeamBuilder(bool isPlayerTeam) {
            IsPlayerTeam = isPlayerTeam;
            CreateTeam();
        }

        public void AddCharacter(AbstractCharacter character) {
            Team.InsertCharacter(character, IsPlayerTeam);
        }

        public void ReplaceCharacter(AbstractCharacter character, int place) {
            Team.ReplaceCharacter(character, place, IsPlayerTeam);
        }

        public void CreateTeam() {
            Team = new CharacterTeam();
        }

        public string GetSummary() {
            StringBuilder builder = new StringBuilder();
            char place = '1';
            for (int i = 0; i < TeamConsts.MaxTeamLength; ++i) {
                builder.Append("   ").Append(place++).Append(") ");
                try {
                    string character = Team.Team[i].ToString();
                    builder.Append(character).AppendLine();
                } catch (ArgumentOutOfRangeException) {
                    builder.Append("   CHARACTER NOT CREATED YET").AppendLine();
                }
            }
            return builder.ToString();
        }

        public CharacterTeam GetTeam() {
            return Team;
        }
    }
}
