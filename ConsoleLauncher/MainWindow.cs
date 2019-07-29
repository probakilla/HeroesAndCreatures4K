using ConsoleDisplay.Screens;
using ConsoleLauncher.Generators;
using HeroesAndCreatures.Fight;
using HeroesAndCreatures.Team;
using HeroesAndCreatures.Team.TeamBuilder;
using System;
using System.Collections.Generic;

namespace ConsoleLauncher {
    public static class MainWindow {
        private static FightGenerator generator = FightGenerator.GetInstance;
        private static GameDisplay Display = new GameDisplay();
        private static SelectOptionScreen SelectDisplay = new SelectOptionScreen();

        private static Dictionary<OptionChoices, Action> KeyAssociations = new Dictionary<OptionChoices, Action> {
            { OptionChoices.RandomFight, delegate() { StartRandomBattle(); } },
            { OptionChoices.TeamBuilder, delegate() { TeamBuilding();  } },
            { OptionChoices.Quit, delegate() { Environment.Exit(0); } }
        };

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
            KeyAssociations[choice]();
        }

        private static void TeamBuilding() {
            TeamBuilderDisplay builderDisplay = new TeamBuilderDisplay(false);
            CharacterTeam computerTeam = builderDisplay.TeamBuilderHome();
            builderDisplay = new TeamBuilderDisplay(true);
            CharacterTeam playerTeam = builderDisplay.TeamBuilderHome();
            Console.Clear();
            Fight fight = generator.GetFight(computerTeam, playerTeam);
            EndFight(fight);
        }

        private static void StartRandomBattle() {
            Console.Clear();
            Fight fight = generator.GetFight();
            EndFight(fight);
        }

        private static void EndFight(Fight fight) {
            if (fight.StartFight()) {
                Display.YouWonScreen();
            } else {
                Display.YouLooseScreen();
            }
        }
    }
}
