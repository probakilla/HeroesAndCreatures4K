using SwaggAndCreaturesLib.Team;

namespace SwaggAndCreaturesLib.User.UserFactory {
    public interface IUserFactory {
        AbstractUser GetUser(CharacterTeam team);
    }
}
