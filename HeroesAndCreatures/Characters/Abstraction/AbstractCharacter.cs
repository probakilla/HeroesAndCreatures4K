using HeroesAndCreatures.Weapons;

namespace HeroesAndCreatures.Characters {
    public abstract class AbstractCharacter {
        private readonly ICharacter Implementation;

        public float MaxHealth { get => Implementation.MaxHealth; }
        public float Health { get => Implementation.Health; }
        public float Agility { get => Implementation.Agility; }
        public int Initiative { get => Implementation.Initiative; }
        public float Power { get => Implementation.Power; }
        public int CharacterPlace {
            get => Implementation.CharacterPlace;
            set => Implementation.CharacterPlace = value;
        }

        protected AbstractCharacter(float health, int agility) {
            Implementation = new ConsoleCharacter(health, agility);
        }

        public virtual void EquipWeapon(IWeapon weapon) {
            Implementation.EquipWeapon(weapon);
        }

        public virtual void UnequipWeapon() {
            Implementation.UnequipWeapon();
        }

        public virtual float Attack() {
            return Implementation.Attack();
        }

        public virtual void Block(float amount) {
            Implementation.Block(amount);
        }

        public virtual bool IsDead() {
            return Implementation.IsDead();
        }

        public virtual void IncreaseInitiative() {
            Implementation.IncreaseInitiative();
        }

        public virtual void Display() {
            Implementation.Display();
        }

        public virtual void HisTurnDisplay() {
            Implementation.HisTurnDisplay();
        }
    }
}
