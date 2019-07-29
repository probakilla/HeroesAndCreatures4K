using HeroesAndCreatures.Characters;

namespace HeroesAndCreatures.Team.TeamBuilder {
    public interface ITeamBuilder {
        void CreateTeam();
        void AddCharacter(AbstractCharacter character);
        void ReplaceCharacter(AbstractCharacter character, int place);
        CharacterTeam GetTeam();
        string GetSummary();
    }
}
