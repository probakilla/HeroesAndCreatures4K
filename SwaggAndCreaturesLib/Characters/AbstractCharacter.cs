using SwaggAndCreaturesLib.Weapons;

namespace SwaggAndCreaturesLib.Characters
{
    public abstract class AbstractCharacter : ICharacter
    {
        private const double DEFAULT_ATK = 1;
        public static readonly int MAX_INITIATIVE = 1000;

        protected IWeapon Weapon = null;
        private CharacterStats Stats;

        public double Health
        {
            get { return Stats.Health; }
            private set { Stats.Health = value; }
        }

        public int Agility
        {
            get { return Stats.Agility; }
            private set { Stats.Agility = value; }
        }

        public int Initiative
        {
            get { return Stats.Initiative; }
            private set { Stats.Initiative = value; }
        }

        protected AbstractCharacter(double health, int agility)
        {
            Stats = new CharacterStats(health, agility);
        }

        public void EquipWeapon(IWeapon weapon) => Weapon = weapon;

        public void UnequipWeapon() => Weapon = null;

        public double Attack()
        {
            Initiative = 0;
            return Weapon == null ? DEFAULT_ATK : Weapon.Attack();
        }

        public void Block(double amount)
        {
            Health -= amount;
            if (Health < 0)
            {
                Health = 0.0;
            }
        }

        public bool IsDead() => Health <= 0.0;

        public void IncreaseInitiative()
        {
            Initiative += Agility;
            if (Initiative > MAX_INITIATIVE)
            {
                Initiative = MAX_INITIATIVE;
            }
        }
    }
}
