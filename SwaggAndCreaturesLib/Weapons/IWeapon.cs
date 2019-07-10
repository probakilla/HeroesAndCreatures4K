namespace SwaggAndCreaturesLib.Weapons
{
    public interface IWeapon
    {
        string Name { get; }
        double Attack();
    }
}
