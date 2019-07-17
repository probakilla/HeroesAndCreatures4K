using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwaggAndCreaturesLib.Characters;
using SwaggAndCreaturesLib.Weapons;
using UnitTests.Consts;

namespace UnitTests.Characters {
    [TestClass]
    public class CharacterTest {
        private AbstractCharacter Fixture;

        [TestInitialize]
        public void SetUp() {
            Fixture = new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility);
        }

        [TestCleanup]
        public void TearDown() {
            Fixture = null;
        }

        [TestMethod]
        public void TestProperties() {
            Assert.AreEqual(CharacterConsts.DefaultHealth, Fixture.Health);
            Assert.AreEqual(CharacterConsts.DefaultAgility, Fixture.Agility);
            Assert.AreEqual(CharacterConsts.DefaultInitiative, Fixture.Initiative);
            Assert.AreEqual(CharacterConsts.DefaultPower, Fixture.Power);
            Assert.AreEqual(CharacterConsts.DefaultPlace, Fixture.CharacterPlace);
        }

        [TestMethod]
        public void TestEquipWeapon() {
            EquipWeapon();
            Assert.AreEqual(WeaponConsts.DefaultWeaponPower, Fixture.Power);
        }

        [TestMethod]
        public void TestUnequipWeapon() {
            EquipWeapon();
            Fixture.UnequipWeapon();
            Assert.AreEqual(CharacterConsts.DefaultPower, Fixture.Power);
        }

        private void EquipWeapon() {
            IWeapon weapon = new SimpleWeapon(WeaponConsts.DefaultWeaponPower);
            Fixture.EquipWeapon(weapon);
        }

        [TestMethod]
        public void TestIncreaseInitiative() {
            Fixture.IncreaseInitiative();
            Assert.AreEqual(CharacterConsts.DefaultAgility, Fixture.Initiative);
        }

        [TestMethod]
        public void TestAttack() {
            Fixture.IncreaseInitiative();
            Assert.AreEqual(CharacterConsts.DefaultPower, Fixture.Attack());
            Assert.AreEqual(CharacterConsts.DefaultInitiative, Fixture.Initiative);
        }

        [TestMethod]
        public void TestBlock() {
            Fixture.Block(WeaponConsts.DefaultWeaponPower);
            Assert.AreEqual(CharacterConsts.DefaultHealth - WeaponConsts.DefaultWeaponPower, Fixture.Health);
        }

        [TestMethod]
        public void TestIsDead() {
            Fixture.Block(CharacterConsts.DefaultHealth);
            Assert.IsTrue(Fixture.IsDead());
        }
    }
}
