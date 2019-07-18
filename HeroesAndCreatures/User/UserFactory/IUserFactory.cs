using HeroesAndCreatures.Team;

namespace HeroesAndCreatures.User.UserFactory {
    public interface IUserFactory {
        AbstractUser GetUser(CharacterTeam team);
    }
}
