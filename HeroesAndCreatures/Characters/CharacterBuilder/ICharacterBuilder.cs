using HeroesAndCreatures.Weapons;

namespace HeroesAndCreatures.Characters.CharacterBuilder {
    public interface ICharacterBuilder {
        void CreateCharacter();
        void SetHealth(double health);
        void SetAgility(int agility);
        void GiveWeapon(IWeapon weapon);
        AbstractCharacter GetCharacter();
    }
}
