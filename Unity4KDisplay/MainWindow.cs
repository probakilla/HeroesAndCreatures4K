using Display;
using SwaggAndCreaturesLib.Fight;
using Unity4KDisplay.Generators;

namespace Unity4KDisplay {
    public static class MainWindow {
        private static FightGenerator generator = FightGenerator.GetInstance;

        public static void Main(string[] args) => StartGame();

        private static void StartGame() {
            ConsoleDisplay.TitleScreen();
            Fight fight = generator.GetFight();
            bool youWon = fight.StartFight();
            if (youWon) {
                ConsoleDisplay.YouWonScreen();
            }
            ConsoleDisplay.YouLooseScreen();
        }
    }
}
