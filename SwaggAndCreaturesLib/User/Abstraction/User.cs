namespace SwaggAndCreaturesLib.User {
    public class User : AbstractUser {
        public User(IUserImpl user) : base(user) { }
    }
}
