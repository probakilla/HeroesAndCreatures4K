using SwaggAndCreaturesLib.Weapons;

namespace SwaggAndCreaturesLib.Characters
{
    public interface ICharacter
    {
        double Health { get; }

        void EquipWeapon(IWeapon weapon);
        void UnequipWeapon();
        double Attack();
        void Block(double amount);
        bool IsDead();
    }
}
