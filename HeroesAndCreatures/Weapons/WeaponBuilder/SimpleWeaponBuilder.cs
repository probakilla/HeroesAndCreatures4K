namespace HeroesAndCreatures.Weapons.WeaponBuilder {
    public class SimpleWeaponBuilder : IWeaponBuilder {
        private WeaponStats WeaponStats;

        public SimpleWeaponBuilder() {
            CreateWeapon();
        }

        public void CreateWeapon() {
            WeaponStats = new WeaponStats();
        }

        public IWeapon GetWeapon() {
            return new SimpleWeapon(WeaponStats);
        }

        public void SetWeaponPower(float power) {
            WeaponStats.Power = power;
        }
    }
}
