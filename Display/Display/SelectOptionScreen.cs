﻿using Display.Extensions;
using System;
using System.Text;
using System.Threading;

namespace Display.Display {
    public enum OptionChoices {
        RandomFight, Unrecognized
    };
    public class SelectOptionScreen {
        private ConsoleDisplay Display = new ConsoleDisplay();
        private static int SleepTime = 2000;

        public void HomeScreen() {
            StringBuilder builder = new StringBuilder();
            builder.Append("     ####################################").AppendLine();
            builder.Append("   #          SELECT ONE OPTION          #").AppendLine();
            builder.Append("     ####################################").JumpTwoLines();
            Console.WriteLine(builder.ToString());
            OptionsToSelect();
        }

        private void OptionsToSelect() {
            StringBuilder builder = new StringBuilder();
            builder.Append("   1 - RANDOM FIGHT").AppendLine();
            Console.WriteLine(builder.ToString());
        }

        public OptionChoices AskUserValidInput() {
            do {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.IsValidOption()) {
                    return keyInfo.ToOptionChoices();
                } else {
                    Thread message = new Thread(() => FlashDisplayDialog("   Unrecognized option, please try again"));
                    message.Start();
                }
            } while (true);
        }

        private void FlashDisplayDialog(string message) {
            Display.DialogMessage(message);
            Thread.Sleep(SleepTime);
            Display.ResetDialogLine();
        }
    }
}
