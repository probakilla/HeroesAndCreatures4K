using HeroesAndCreatures.Weapons;

namespace ConsoleLauncher.Generators {
    public class WeaponGenerator {
        private static WeaponGenerator Instance = null;
        private readonly RandomNumberGenerator NumberGenerator;

        public static WeaponGenerator GetInstance {
            get {
                if (Instance == null) {
                    Instance = new WeaponGenerator();
                }
                return Instance;
            }
        }

        private WeaponGenerator() {
            NumberGenerator = RandomNumberGenerator.GetInstance;
        }

        public IWeapon GetRandomWeapon() {
            float power = NumberGenerator.GetRandomFloat(GeneratorConsts.MinStat, GeneratorConsts.MaxStat);
            return new SimpleWeapon(power);
        }
    }
}
