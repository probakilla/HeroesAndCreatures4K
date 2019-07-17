using Display;
using SwaggAndCreaturesLib.Characters;
using SwaggAndCreaturesLib.Team;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwaggAndCreaturesLib.User {
    public class ConsolePlayer : AbstractUserImpl {
        public ConsolePlayer(CharacterTeam team) : base(team) { }

        public override void Play(List<AbstractCharacter> oppositeTeam) {
            AbstractCharacter character = GetNextToAttack();
            character.HisTurnDisplay();
            int choice = -1;
            bool continueFlag = true;
            do {
                WriteCharacterInfo(character);
                choice = GetUserInput();
                if (IsTargetValid(oppositeTeam, choice)) {
                    continueFlag = false;
                }
            } while (continueFlag);
            oppositeTeam[choice].Block(character.Attack());
            character.Display();
        }

        private int GetUserInput() {
            bool continueFlag = true;
            int choice = -1;
            do {
                ConsoleDisplay.DialogMessage("Please select a target: ");
                string value = AskUserInput();
                try {
                    choice = Convert.ToInt32(value);
                    if (ValidChoice(choice)) {
                        continueFlag = false;
                    }
                } catch {
                    ConsoleDisplay.DialogMessage("Invalid Input !");
                }
            } while (continueFlag);
            return choice;
        }

        private bool ValidChoice(int userChoice) {
            return userChoice >= 0 && userChoice <= 3;
        }

        private void WriteCharacterInfo(AbstractCharacter character) {
            StringBuilder builder = new StringBuilder("Turn: (");
            builder.Append(character.CharacterPlace.ToString())
                .Append(") Attack power: ")
                .Append((int)character.Power);
            ConsoleDisplay.InfoMessage(builder.ToString());
        }

        private string AskUserInput() {
            Console.CursorVisible = true;
            string value = Console.ReadLine();
            Console.CursorVisible = false;
            return value;
        }
    }
}