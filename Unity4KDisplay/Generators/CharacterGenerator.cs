using Display.Character;
using SwaggAndCreaturesLib.Characters;

namespace Unity4KDisplay.Generators {
    public class CharacterGenerator {
        private static CharacterGenerator Instance = null;
        private readonly RandomNumberGenerator NumberGenerator;

        private CharacterGenerator() => NumberGenerator = RandomNumberGenerator.GetInstance;

        public static CharacterGenerator GetInstance {
            get {
                if (Instance == null) {
                    Instance = new CharacterGenerator();
                }
                return Instance;
            }
        }

        public ICharacter GetRandomCharacter() {
            double health = NumberGenerator.GetRandomDouble(RandomNumberGenerator.MIN_STAT, RandomNumberGenerator.MAX_STAT);
            int agility = NumberGenerator.GetRandomInt(RandomNumberGenerator.MIN_STAT, RandomNumberGenerator.MAX_STAT);
            return new CharacterConsoleDisplay((int)health, agility);
        }

        public ICharacter GetDefaultCharacter() {
            return new CharacterConsoleDisplay(RandomNumberGenerator.MAX_STAT, RandomNumberGenerator.MAX_STAT);
        }
    }
}
