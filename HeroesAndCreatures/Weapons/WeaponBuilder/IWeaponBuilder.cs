namespace HeroesAndCreatures.Weapons.WeaponBuilder {
    public interface IWeaponBuilder {
        void CreateWeapon();
        void SetWeaponPower(float power);
        IWeapon GetWeapon();
    }
}
