using HeroesAndCreatures.Characters;

namespace ConsoleLauncher.Generators {
    public class CharacterGenerator {
        private static CharacterGenerator Instance = null;
        private readonly RandomNumberGenerator NumberGenerator;

        private CharacterGenerator() {
            NumberGenerator = RandomNumberGenerator.GetInstance;
        }

        public static CharacterGenerator GetInstance {
            get {
                if (Instance == null) {
                    Instance = new CharacterGenerator();
                }
                return Instance;
            }
        }

        public AbstractCharacter GetRandomCharacter() {
            float health = NumberGenerator.GetRandomFloat(
                GeneratorConsts.MinHealth,
                GeneratorConsts.MaxStat);
            int agility = NumberGenerator.GetRandomInt(GeneratorConsts.MinStat, GeneratorConsts.MaxStat);
            return new Human(health, agility);
        }

        public AbstractCharacter GetDefaultCharacter() {
            return new Human(GeneratorConsts.MaxStat, GeneratorConsts.MaxStat);
        }
    }
}
