namespace SwaggAndCreaturesLib.User.Abstraction {
    public class AbstractUser {
        private readonly IUserImpl Implementation;

        public AbstractUser(IUserImpl user) {
            Implementation = user;
        }
    }
}
