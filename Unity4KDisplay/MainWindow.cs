using Display.Character;
using SwaggAndCreaturesLib.Team;
using System;

namespace Unity4KDisplay {
    public static class MainWindow {

        public static void Main(string[] args) => TestTeam();

        private static void TestTeam() {
            CharacterTeam Fixture = new CharacterTeam();
            for (int i = 0; i < CharacterTeam.TEAM_LENGTH; ++i) {
                Fixture.InsertCharacter(new CharacterConsoleDisplay(i, i), true);
            }
        }
    }
}