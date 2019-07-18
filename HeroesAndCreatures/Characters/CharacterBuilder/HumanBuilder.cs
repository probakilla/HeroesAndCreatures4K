using HeroesAndCreatures.Weapons;

namespace HeroesAndCreatures.Characters.CharacterBuilder {
    public class HumanBuilder : ICharacterBuilder {
        private CharacterStats Stats;

        public float? WeaponPower {
            get {
                if (Weapon == null) {
                    return null;
                }
                return Weapon.Attack();
            }
        }

        private IWeapon Weapon = null;

        public void CreateCharacter() {
            Stats = new CharacterStats();
        }

        public AbstractCharacter GetCharacter() {
            AbstractCharacter character = new Human(Stats.Health, Stats.Agility);
            if (Weapon != null) {
                character.EquipWeapon(Weapon);
            }
            return character;
        }

        public void GiveWeapon(IWeapon weapon) {
            Weapon = weapon;
        }

        public void SetAgility(int agility) {
            Stats.Agility = agility;
        }

        public void SetHealth(float health) {
            Stats.Health = health;
        }

        public CharacterStats GetCharacterStats() {
            return Stats;
        }
    }
}
