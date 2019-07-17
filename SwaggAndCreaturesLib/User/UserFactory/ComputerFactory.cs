using SwaggAndCreaturesLib.Team;
using SwaggAndCreaturesLib.User.Abstraction;

namespace SwaggAndCreaturesLib.User.UserFactory {
    public class ComputerFactory : AbstractFactory {
        public override AbstractUser GetUser(CharacterTeam team) {
            IUserImpl user = new ConsoleComputer(team);
            return new AbstractUser(user);
        }
    }
}
