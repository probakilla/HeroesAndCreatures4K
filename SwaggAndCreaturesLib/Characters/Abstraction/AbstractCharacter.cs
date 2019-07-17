using SwaggAndCreaturesLib.Weapons;

namespace SwaggAndCreaturesLib.Characters {
    public abstract class AbstractCharacter {
        private readonly ICharacter Implementation;

        public double Health { get => Implementation.Health; }
        public int Agility { get => Implementation.Agility; }
        public int Initiative { get => Implementation.Initiative; }
        public double Power { get => Implementation.Power; }
        public int CharacterPlace {
            get => Implementation.CharacterPlace;
            set => Implementation.CharacterPlace = value;
        }

        protected AbstractCharacter(double health, int agility) {
            Implementation = new ConsoleCharacter(health, agility);
        }

        public virtual void EquipWeapon(IWeapon weapon) {
            Implementation.EquipWeapon(weapon);
        }

        public virtual void UnequipWeapon() {
            Implementation.UnequipWeapon();
        }

        public virtual double Attack() {
            return Implementation.Attack();
        }

        public virtual void Block(double amount) {
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
