using ConsoleDisplay.Screens;
using HeroesAndCreatures.Characters;
using HeroesAndCreatures.Team;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndCreatures.User {
    public class ConsoleComputer : AbstractUserImpl {
        private static readonly GameDisplay Display = new GameDisplay();

        public ConsoleComputer(CharacterTeam team) : base(team) { }

        public override void Play(List<AbstractCharacter> oppositeTeam) {
            AbstractCharacter character = GetNextToAttack();
            character.HisTurnDisplay();
            int choice;
            bool continueFlag = true;
            do {
                choice = GenerateRandomInteger(0, oppositeTeam.Count);
                if (IsTargetValid(oppositeTeam, choice)) {
                    continueFlag = false;
                }
            } while (continueFlag);
            WriteComputerMove(character, choice);
            oppositeTeam[choice].Block(character.Attack());
            character.Display();
        }

        private static int GenerateRandomInteger(int min, int max) {
            Random rand = new Random();
            return rand.Next(min, max);
        }

        private static void WriteComputerMove(AbstractCharacter character, int choice) {
            Display.ResetDialogLine();
            StringBuilder builder = new StringBuilder("Computer move: Character (");
            builder.Append(character.CharacterPlace.ToString())
                .Append(") attacked: (").Append(choice + TeamConsts.MaxTeamLength).Append(")");
            Display.InfoMessage(builder.ToString());
            string dialog = "With a power of: " + (int)character.Power;
            Display.DialogMessage(dialog);
            System.Threading.Thread.Sleep(UserConsts.WaitAfterActionTime);
        }
    }
}