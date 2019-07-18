namespace HeroesAndCreatures.Weapons {
    public class SimpleWeapon : AbstractWeapon {
        public SimpleWeapon(float power) : base(power) { }

        public SimpleWeapon(WeaponStats stats) : base(stats) { }
    }
}