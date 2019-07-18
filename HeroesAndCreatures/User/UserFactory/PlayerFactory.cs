using HeroesAndCreatures.Team;

namespace HeroesAndCreatures.User.UserFactory {
    class PlayerFactory : AbstractFactory {
        public override AbstractUser GetUser(CharacterTeam team) {
            IUserImpl user = new ConsolePlayer(team);
            return new User(user);
        }
    }
}
