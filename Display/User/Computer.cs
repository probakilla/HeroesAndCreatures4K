using SwaggAndCreaturesLib.Characters;
using SwaggAndCreaturesLib.Team;
using SwaggAndCreaturesLib.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Display.User {
    public class Computer : AbstractUser {
        private const int DISPLAY_DELAY = 1500;

        public Computer(CharacterTeam team) : base(team) { }

        public override void Play(List<AbstractCharacter> oppositeTeam) {
            AbstractCharacter character = GetNextToAttack();
            character.HisTurnDisplay();
            int choice = -1;
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
            ConsoleDisplay.ResetDialogLine();
            StringBuilder builder = new StringBuilder("Computer move: Character (");
            builder.Append(character.CharacterPlace.ToString())
                .Append(") attacked: (").Append(choice).Append(")");
            ConsoleDisplay.InfoMessage(builder.ToString());
            string dialog = "With a power of: " + (int)character.Power;
            ConsoleDisplay.DialogMessage(dialog);
            System.Threading.Thread.Sleep(DISPLAY_DELAY);
        }
    }
}