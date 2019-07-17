using SwaggAndCreaturesLib.Team;

namespace SwaggAndCreaturesLib.User.UserFactory {
    public abstract class AbstractFactory : IUserFactory {
        public abstract AbstractUser GetUser (CharacterTeam team);
    }
}
