using ConsoleDisplay.Screens;
using HeroesAndCreatures.Fight;
using System;
using ConsoleLauncher.Generators;
using HeroesAndCreatures.Characters.CharacterBuilder;

namespace ConsoleLauncher {
    public static class MainWindow {
        private static FightGenerator generator = FightGenerator.GetInstance;
        private static GameDisplay Display = new GameDisplay();
        private static CharacterBuilderDisplay BuilderDisplay = new CharacterBuilderDisplay();
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
                case OptionChoices.TeamBuilder:
                    BuilderDisplay.CharacterBuilderHome();
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
