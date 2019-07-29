using HeroesAndCreatures.Fight;
using HeroesAndCreatures.Team;
using HeroesAndCreatures.User;

namespace ConsoleLauncher.Generators {
    public class FightGenerator {
        private static FightGenerator Instance = null;
        private readonly UserGenerator UserGenerator;

        public static FightGenerator GetInstance {
            get {
                if (Instance == null) {
                    Instance = new FightGenerator();
                }
                return Instance;
            }
        }

        private FightGenerator() {
            UserGenerator = UserGenerator.GetInstance;
        }

        public Fight GetFight() {
            IUserImpl cpu = UserGenerator.GetUser(false);
            IUserImpl player = UserGenerator.GetUser(true);
            return new Fight(cpu, player);
        }

        public Fight GetFight(CharacterTeam computerTeam, CharacterTeam playerTeam) {
            IUserImpl cpu = UserGenerator.GetUser(false, computerTeam);
            IUserImpl player = UserGenerator.GetUser(true, playerTeam);
            return new Fight(cpu, player);
        }
    }
}
