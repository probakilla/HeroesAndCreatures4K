using HeroesAndCreatures.Team;

namespace HeroesAndCreatures.User.UserFactory {
    public class ComputerFactory : AbstractFactory {
        public override AbstractUser GetUser(CharacterTeam team) {
            IUserImpl user = new ConsoleComputer(team);
            return new User(user);
        }
    }
}
