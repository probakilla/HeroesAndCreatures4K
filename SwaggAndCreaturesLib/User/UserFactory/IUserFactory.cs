using SwaggAndCreaturesLib.Team;
using SwaggAndCreaturesLib.User.Abstraction;

namespace SwaggAndCreaturesLib.User.UserFactory {
    public interface IUserFactory {
        AbstractUser GetUser(CharacterTeam team);
    }
}
