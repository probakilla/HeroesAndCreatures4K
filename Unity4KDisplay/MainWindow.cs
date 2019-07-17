using Display.Screens;
using SwaggAndCreaturesLib.Fight;
using System;
using Unity4KDisplay.Generators;

namespace Unity4KDisplay {
    public static class MainWindow {
        private static FightGenerator generator = FightGenerator.GetInstance;
        private static ConsoleDisplay Display = new ConsoleDisplay();
        private static SelectOptionScreen SelectDisplay = new SelectOptionScreen();

        public static void Main(string[] args) {
            Console.CursorVisible = false;
            DisplayTitleScreen();
        }

        private static void DisplayTitleScreen() {
            Display.TitleScreen();
            SelectDisplay.HomeScreen();
            OptionChoices choice = SelectDisplay.AskUserValidInput();
            RedirectUser(choice);
        }

        private static void RedirectUser(OptionChoices choice) {
            switch (choice) {
                case OptionChoices.RandomFight:
                    StartRandomBattle();
                    break;
                case OptionChoices.Quit:
                    Environment.Exit(0);
                    break;
            }
        }

        private static void StartRandomBattle() {
            Console.Clear();
            Fight fight = generator.GetFight();
            bool youWon = fight.StartFight();
            if (youWon) {
                Display.YouWonScreen();
            } else {
                Display.YouLooseScreen();
            }
        }
    }
}
