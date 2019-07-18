using HeroesAndCreatures.Weapons;

namespace HeroesAndCreatures.Characters.CharacterBuilder {
    public interface ICharacterBuilder {
        float? WeaponPower { get; }

        void CreateCharacter();
        void SetHealth(float health);
        void SetAgility(int agility);
        void GiveWeapon(IWeapon weapon);
        AbstractCharacter GetCharacter();
        CharacterStats GetCharacterStats();
    }
}
