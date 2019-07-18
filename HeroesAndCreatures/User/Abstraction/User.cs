namespace HeroesAndCreatures.User {
    public class User : AbstractUser {
        public User(IUserImpl user) : base(user) { }
    }
}
