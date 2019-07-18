using HeroesAndCreatures.Team;

namespace HeroesAndCreatures.User.UserFactory {
    public abstract class AbstractFactory : IUserFactory {
        public abstract AbstractUser GetUser (CharacterTeam team);
    }
}
