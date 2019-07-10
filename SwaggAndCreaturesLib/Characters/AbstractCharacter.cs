using SwaggAndCreaturesLib.Weapons;

namespace SwaggAndCreaturesLib.Characters
{
    public abstract class AbstractCharacter : ICharacter
    {
        private const double DEFAULT_ATK = 1;

        public double Health { get; set; }
        protected IWeapon Weapon = null;

        protected AbstractCharacter(double health) => Health = health;

        public void EquipWeapon(IWeapon weapon) => Weapon = weapon;

        public void UnequipWeapon() => Weapon = null;

        public double Attack() => Weapon == null ? DEFAULT_ATK : Weapon.Attack();

        public void Block(double amount)
        {
            Health -= amount;
            if (Health < 0)
            {
                Health = 0.0;
            }
        }

        public bool IsDead() => Health <= 0.0;
    }
}
