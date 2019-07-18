namespace HeroesAndCreatures.Weapons {
    public abstract class AbstractWeapon : IWeapon {
        private readonly double Power;
        public string Name { get; private set; }

        protected AbstractWeapon(double power) => Power = power;

        public double Attack() => Power;
    }
}
