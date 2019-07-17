using SwaggAndCreaturesLib.Weapons;

namespace SwaggAndCreaturesLib.Characters {
    internal interface ICharacter {
        double MaxHealth { get; }
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
        void Display();
        void HisTurnDisplay();
    }
}
