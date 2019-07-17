﻿using SwaggAndCreaturesLib.Weapons;
using System;

namespace SwaggAndCreaturesLib.Characters {
    internal abstract class AbstractCharacterImplementation : ICharacter {
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
            get => HasAWeapon() ? Weapon.Attack() : CharacterConsts.DefaultPower;
        }

        protected int Place;
        public virtual int CharacterPlace { get; set; }

        protected AbstractCharacterImplementation(double health, int agility) {
            Stats = new CharacterStats(health, agility);
            Place = CharacterConsts.DefaultPlace;
        }

        public void EquipWeapon(IWeapon weapon) {
            Weapon = weapon;
        }

        public void UnequipWeapon() {
            Weapon = null;
        }

        public double Attack() {
            ResetInitiative();
            return HasAWeapon() ? Weapon.Attack() : CharacterConsts.DefaultPower;
        }

        private void ResetInitiative() {
            Initiative = CharacterConsts.DefaultInitiative;
        }

        private bool HasAWeapon() {
            return Weapon != null;
        }

        public virtual void Block(double amount) {
            Health -= amount;
            if (Health < CharacterConsts.MinHealth) {
                Health = CharacterConsts.MinHealth;
            }
        }

        public virtual bool IsDead() {
            return Health <= CharacterConsts.MinHealth;
        }

        public virtual void IncreaseInitiative() {
            Initiative += Agility;
            if (Initiative > CharacterConsts.MaxInitiative) {
                Initiative = CharacterConsts.MaxInitiative;
            }
        }

        public virtual void Display() {
            throw new NotImplementedException("Can't be draw");
        }

        public virtual void HisTurnDisplay() {
            throw new NotImplementedException("Can't be draw");
        }
    }
}