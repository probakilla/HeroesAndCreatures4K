using HeroesAndCreatures.Characters;

namespace HeroesAndCreatures.Team.TeamBuilder {
    public interface ITeamBuilder {
        void CreateTeam();
        void AddCharacter(AbstractCharacter character);
        CharacterTeam GetTeam();
        void DrawSummary();
    }
}
