using SwaggAndCreaturesLib.Weapons;
using System;

namespace SwaggAndCreaturesLib.Characters {
    public abstract class AbstractCharacter : ICharacter {
        private const double DEFAULT_ATK = 1;
        private const int DEFAULT_INITIATIVE = 0;
        public static readonly int MAX_INITIATIVE = 2000;

        protected IWeapon Weapon = null;
        private CharacterStats Stats;

        public double Health {
            get => Stats.Health;
            protected set => Stats.Health = value;
        }

        public int Agility {
            get => Stats.Agility;
            protected set => Stats.Agility = value;
        }

        public int Initiative {
            get => Stats.Initiative;
            protected set => Stats.Initiative = value;
        }

        public double Power {
            get => HasAWeapon() ? Weapon.Attack() : DEFAULT_ATK;
        }

        protected int Place;
        public virtual int CharacterPlace { get; set; }

        protected AbstractCharacter(double health, int agility) {
            Stats = new CharacterStats(health, agility);
            Place = -1;
        }

        public void EquipWeapon(IWeapon weapon) => Weapon = weapon;

        public void UnequipWeapon() => Weapon = null;

        public double Attack() {
            ResetInitiative();
            return HasAWeapon() ? Weapon.Attack() : DEFAULT_ATK;
        }

        private void ResetInitiative() => Initiative = DEFAULT_INITIATIVE;

        private bool HasAWeapon() => Weapon != null;

        public virtual void Block(double amount) {
            Health -= amount;
            if (Health < 0) {
                Health = 0.0;
            }
        }

        public virtual bool IsDead() => Health <= 0.0;

        public virtual void IncreaseInitiative() {
            Initiative += Agility;
            if (Initiative > MAX_INITIATIVE) {
                Initiative = MAX_INITIATIVE;
            }
        }

        public virtual void DrawCharacter() {
            throw new NotImplementedException("Can't be draw");
        }
    }
}