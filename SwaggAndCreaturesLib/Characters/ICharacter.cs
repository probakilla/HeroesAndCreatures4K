using SwaggAndCreaturesLib.Weapons;

namespace SwaggAndCreaturesLib.Characters {
    public interface ICharacter {
        double Health { get; }
        int Agility { get; }
        int Initiative { get; }
        int CharacterPlace { get; set; }
        double Power { get; }

        void EquipWeapon(IWeapon weapon);
        void UnequipWeapon();
        double Attack();
        void Block(double amount);
        bool IsDead();
        void IncreaseInitiative();
        void DrawCharacter();
    }
}
