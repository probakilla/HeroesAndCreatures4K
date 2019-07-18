namespace HeroesAndCreatures.Weapons {
    public interface IWeapon {
        string Name { get; }
        double Attack();
    }
}
