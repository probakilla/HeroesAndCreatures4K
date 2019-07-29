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

        public HumanBuilder() {
            CreateCharacter();
        }

        public HumanBuilder(AbstractCharacter character) {
            CreateCharacter(character);
        }

        public void CreateCharacter() {
            Stats = new CharacterStats();
        }

        private void CreateCharacter(AbstractCharacter character) {
            Stats = new CharacterStats {
                Agility = character.Agility,
                Health = character.Health,
                MaxHealth = character.MaxHealth
            };
            Weapon = new SimpleWeapon(character.Power);
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
