using Display.Character;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwaggAndCreaturesLib.Team;

namespace UnitTests {
    [TestClass]
    public class CharacterTeamTests {
        private CharacterTeam Fixture;

        [TestInitialize]
        public void SetUp() => Fixture = new CharacterTeam();

        [TestCleanup]
        public void TearDown() => Fixture = null;

        [TestMethod]
        public void TestComputerTeamCreation() {
            for (int i = 0; i < CharacterTeam.TEAM_LENGTH; ++i) {
                Fixture.InsertCharacter(new CharacterConsoleDisplay(i + 1, i + 1), false);
            }
            for (int i = 0; i < CharacterTeam.TEAM_LENGTH; ++i) {
                Assert.AreEqual(i, Fixture.Team[i].CharacterPlace);
                Assert.AreEqual(i + 1, Fixture.Team[i].Agility);
                Assert.AreEqual(i + 1, Fixture.Team[i].Health);
                Assert.AreEqual(1, Fixture.Team[i].Power);
            }
        }

        [TestMethod]
        public void TestPlayerTeamCreation() {
            for (int i = 0; i < CharacterTeam.TEAM_LENGTH; ++i) {
                Fixture.InsertCharacter(new CharacterConsoleDisplay(i + 1, i + 1), true);
            }
            for (int i = 0; i < CharacterTeam.TEAM_LENGTH; ++i) {
                Assert.AreEqual(i + CharacterTeam.TEAM_LENGTH, Fixture.Team[i].CharacterPlace);
                Assert.AreEqual(i + 1, Fixture.Team[i].Agility);
                Assert.AreEqual(i + 1, Fixture.Team[i].Health);
                Assert.AreEqual(1, Fixture.Team[i].Power);
            }
        }


    }
}
