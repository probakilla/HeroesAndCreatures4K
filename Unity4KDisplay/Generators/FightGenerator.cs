using SwaggAndCreaturesLib.Fight;
using SwaggAndCreaturesLib.User;

namespace Unity4KDisplay.Generators {
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

        private FightGenerator() => UserGenerator = UserGenerator.GetInstance;

        public Fight GetFight() {
            IUser cpu = UserGenerator.GetUser(false);
            IUser player = UserGenerator.GetUser(true);
            return new Fight(cpu, player);
        }
    }
}
