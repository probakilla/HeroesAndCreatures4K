using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeroesAndCreatures.Characters;
using HeroesAndCreatures.Team;
using UnitTests.Consts;
using UnitTests.Team;

namespace UnitTests {
    [TestClass]
    public class CharacterTeamTests {
        private CharacterTeam Fixture;

        [TestInitialize]
        public void SetUp() {
            Fixture = new CharacterTeam();
        }

        [TestCleanup]
        public void TearDown() {
            Fixture = null;
        }

        [TestMethod]
        public void TestAddOneCharacter() {
            Assert.AreEqual(TeamConsts.EmptyTeam, Fixture.Team.Count);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), false);
            Assert.AreEqual(TeamConsts.OneCharTeam, Fixture.Team.Count);
            Assert.AreEqual(TeamConsts.FirstComputerPlace, Fixture.Team[TeamConsts.FirstComputerPlace].CharacterPlace);
        }

        [TestMethod]
        public void TestAddTwoCharacter() {
            Assert.AreEqual(TeamConsts.EmptyTeam, Fixture.Team.Count);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), false);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), false);
            Assert.AreEqual(TeamConsts.TwoCharTeam, Fixture.Team.Count);
            Assert.AreEqual(TeamConsts.FirstComputerPlace, Fixture.Team[TeamConsts.FirstComputerPlace].CharacterPlace);
            Assert.AreEqual(TeamConsts.SecondComputerPlace, Fixture.Team[TeamConsts.SecondComputerPlace].CharacterPlace);
        }

        [TestMethod]
        public void TestAddThreeCharacter() {
            Assert.AreEqual(TeamConsts.EmptyTeam, Fixture.Team.Count);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), false);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), false);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), false);
            Assert.AreEqual(TeamConsts.ThreeCharTeam, Fixture.Team.Count);
            Assert.AreEqual(TeamConsts.FirstComputerPlace, Fixture.Team[TeamConsts.FirstComputerPlace].CharacterPlace);
            Assert.AreEqual(TeamConsts.SecondComputerPlace, Fixture.Team[TeamConsts.SecondComputerPlace].CharacterPlace);
            Assert.AreEqual(TeamConsts.ThirdComputerPlace, Fixture.Team[TeamConsts.ThirdComputerPlace].CharacterPlace);
        }

        [TestMethod]
        public void TestAddFourCharacter() {
            Assert.AreEqual(TeamConsts.EmptyTeam, Fixture.Team.Count);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), false);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), false);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), false);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), false);
            Assert.AreEqual(TeamConsts.FourCharTeam, Fixture.Team.Count);
            Assert.AreEqual(TeamConsts.FirstComputerPlace, Fixture.Team[TeamConsts.FirstComputerPlace].CharacterPlace);
            Assert.AreEqual(TeamConsts.SecondComputerPlace, Fixture.Team[TeamConsts.SecondComputerPlace].CharacterPlace);
            Assert.AreEqual(TeamConsts.ThirdComputerPlace, Fixture.Team[TeamConsts.ThirdComputerPlace].CharacterPlace);
            Assert.AreEqual(TeamConsts.FourthComputerPlace, Fixture.Team[TeamConsts.FourthComputerPlace].CharacterPlace);
        }

        [TestMethod]
        public void TestComputerTeamCreation() {
            FillTeam(false);
            for (int i = 0; i < TeamConsts.MaxTeamLength; ++i) {
                Assert.AreEqual(i, Fixture.Team[i].CharacterPlace);
                Assert.AreEqual(i + 1, Fixture.Team[i].Agility);
                Assert.AreEqual(i + 1, Fixture.Team[i].Health);
                Assert.AreEqual(1, Fixture.Team[i].Power);
            }
        }

        [TestMethod]
        public void TestPlayerTeamCreation() {
            FillTeam(true);
            for (int i = 0; i < TeamConsts.MaxTeamLength; ++i) {
                Assert.AreEqual(i + TeamConsts.MaxTeamLength, Fixture.Team[i].CharacterPlace);
                Assert.AreEqual(i + 1, Fixture.Team[i].Agility);
                Assert.AreEqual(i + 1, Fixture.Team[i].Health);
                Assert.AreEqual(1, Fixture.Team[i].Power);
            }
        }

        private void FillTeam(bool isPlayer) {
            for (int i = 0; i < TeamConsts.MaxTeamLength; ++i) {
                Fixture.InsertCharacter(new Human(i + 1, i + 1), isPlayer);
            }
        }

        [TestMethod]
        public void TestGetNextToAttackLast() {
            FillTeam(false);
            Fixture.IncreaseAllInitiative();
            AbstractCharacter character = Fixture.GetNextToAttack();
            Assert.AreEqual(TeamConsts.HighestDefaultAgility, character.Agility);
            Assert.AreEqual(TeamConsts.HighestDefaultHealth, character.Health);
            Assert.AreEqual(TeamConsts.FourthComputerPlace, character.CharacterPlace);
        }

        [TestMethod]
        public void TestGetNextToAttackFirst() {
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, TeamConsts.HighestAgility), false);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), false);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), false);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), false);
            Fixture.IncreaseAllInitiative();
            AbstractCharacter choosenOne = Fixture.GetNextToAttack();
            Assert.AreEqual(TeamConsts.FirstComputerPlace, choosenOne.CharacterPlace);
        }

        [TestMethod]
        public void TestGetNextToAttackSecond() {
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), false);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, TeamConsts.HighestAgility), false);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), false);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), false);
            Fixture.IncreaseAllInitiative();
            AbstractCharacter choosenOne = Fixture.GetNextToAttack();
            Assert.AreEqual(TeamConsts.SecondComputerPlace, choosenOne.CharacterPlace);
        }

        [TestMethod]
        public void TestGetNextToAttackThird() {
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), false);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), false);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, TeamConsts.HighestAgility), false);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), false);
            Fixture.IncreaseAllInitiative();
            AbstractCharacter choosenOne = Fixture.GetNextToAttack();
            Assert.AreEqual(TeamConsts.ThirdComputerPlace, choosenOne.CharacterPlace);
        }

        [TestMethod]
        public void TestGetNextToAttackLastPlayer() {
            FillTeam(true);
            Fixture.IncreaseAllInitiative();
            AbstractCharacter character = Fixture.GetNextToAttack();
            Assert.AreEqual(TeamConsts.HighestDefaultAgility, character.Agility);
            Assert.AreEqual(TeamConsts.HighestDefaultHealth, character.Health);
            Assert.AreEqual(TeamConsts.FourthPlayerPlace, character.CharacterPlace);
        }

        [TestMethod]
        public void TestGetNextToAttackFirstPlayer() {
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, TeamConsts.HighestAgility), true);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), true);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), true);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), true);
            Fixture.IncreaseAllInitiative();
            AbstractCharacter choosenOne = Fixture.GetNextToAttack();
            Assert.AreEqual(TeamConsts.FirstPlayerPlace, choosenOne.CharacterPlace);
        }

        [TestMethod]
        public void TestGetNextToAttackSecondPlayer() {
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), true);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, TeamConsts.HighestAgility), true);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), true);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), true);
            Fixture.IncreaseAllInitiative();
            AbstractCharacter choosenOne = Fixture.GetNextToAttack();
            Assert.AreEqual(TeamConsts.SecondPlayerPlace, choosenOne.CharacterPlace);
        }

        [TestMethod]
        public void TestGetNextToAttackThirdPlayer() {
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), true);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), true);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, TeamConsts.HighestAgility), true);
            Fixture.InsertCharacter(new Human(CharacterConsts.DefaultHealth, CharacterConsts.DefaultAgility), true);
            Fixture.IncreaseAllInitiative();
            AbstractCharacter choosenOne = Fixture.GetNextToAttack();
            Assert.AreEqual(TeamConsts.ThirdPlayerPlace, choosenOne.CharacterPlace);
        }
    }
}
