using HeroesAndCreatures.Weapons;

namespace HeroesAndCreatures.Characters {
    internal interface ICharacter {
        float MaxHealth { get; }
        float Health { get; }
        int Agility { get; }
        int Initiative { get; }
        int CharacterPlace { get; set; }
        float Power { get; }

        void EquipWeapon(IWeapon weapon);
        void UnequipWeapon();
        float Attack();

        void Block(float amount);
        bool IsDead();
        void IncreaseInitiative();
        void Display();
        void HisTurnDisplay();
        string ToString();
    }
}
