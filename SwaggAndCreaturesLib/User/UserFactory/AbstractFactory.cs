using SwaggAndCreaturesLib.Team;
using SwaggAndCreaturesLib.User.Abstraction;

namespace SwaggAndCreaturesLib.User.UserFactory {
    public abstract class AbstractFactory : IUserFactory {
        public abstract AbstractUser GetUser (CharacterTeam team);
    }
}
