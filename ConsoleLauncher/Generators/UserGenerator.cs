using HeroesAndCreatures.Team;
using HeroesAndCreatures.User;

namespace ConsoleLauncher.Generators {
    class UserGenerator {
        private static UserGenerator Instance = null;
        private readonly TeamGenerator TeamGenerator;

        public static UserGenerator GetInstance {
            get {
                if (Instance == null) {
                    Instance = new UserGenerator();
                }
                return Instance;
            }
        }

        private UserGenerator() {
            TeamGenerator = TeamGenerator.GetInstance;
        }

        public IUserImpl GetUser(bool isPlayer) {
            CharacterTeam team = TeamGenerator.GenerateRandomTeam(isPlayer);
            if (isPlayer) {
                return new ConsolePlayer(team);
            }
            return new ConsoleComputer(team);
        }
    }
}
