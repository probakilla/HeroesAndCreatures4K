using SwaggAndCreaturesLib.Team;
using SwaggAndCreaturesLib.User.Abstraction;

namespace SwaggAndCreaturesLib.User.UserFactory {
    class PlayerFactory : AbstractFactory {
        public override AbstractUser GetUser(CharacterTeam team) {
            IUserImpl user = new ConsolePlayer(team);
            return new AbstractUser(user);
        }
    }
}
