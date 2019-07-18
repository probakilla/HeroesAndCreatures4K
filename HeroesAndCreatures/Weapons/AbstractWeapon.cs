namespace HeroesAndCreatures.Weapons {
    public abstract class AbstractWeapon : IWeapon {
        private WeaponStats Stats;
        public string Name { get; private set; }

        protected float Power {
            get => Stats.Power;
        }

        protected AbstractWeapon(float power) {
            Stats = new WeaponStats(power);
        }

        protected AbstractWeapon(WeaponStats stats) {
            Stats = stats;
        }

        public float Attack() {
            return Power;
        }
    }
}
