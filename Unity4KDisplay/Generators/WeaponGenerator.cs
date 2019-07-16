using SwaggAndCreaturesLib.Weapons;

namespace Unity4KDisplay.Generators {
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

        private WeaponGenerator() => NumberGenerator = RandomNumberGenerator.GetInstance;

        public IWeapon GetRandomWeapon() {
            double power = NumberGenerator.GetRandomDouble(RandomNumberGenerator.MIN_STAT, RandomNumberGenerator.MAX_STAT);
            return new SimpleWeapon(power);
        }
    }
}
