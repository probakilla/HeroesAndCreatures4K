using Display.Extensions;
using System;
using System.Text;

namespace Display.Screens {
    public struct ConsoleDisplay {
        public void DialogMessage(string message) {
            ResetDialogLine();
            WriteDialog(message, false);
        }

        public void InfoMessage(string message) {
            ResetInfoLine();
            WriteDialog(message, true);
        }

        public void ResetDialogLine() {
            string emptyString = string.Empty.PadLeft(ConsoleConsts.PaddingSize);
            WriteDialog(emptyString, false);
        }

        public void ResetInfoLine() {
            string emptyString = string.Empty.PadLeft(ConsoleConsts.PaddingSize);
            WriteDialog(emptyString, true);
        }

        private void WriteDialog(string message, bool isInfoMessage) {
            int line = (isInfoMessage) ? ConsoleConsts.InfoLine : ConsoleConsts.DialogLine;
            try {
                Console.SetCursorPosition(0, line);
                Console.Write(message);
            } catch (ArgumentOutOfRangeException e) {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public void TitleScreen() {
            StringBuilder builder = new StringBuilder();
            builder.Append("     ####################################").AppendLine();
            builder.Append("    #             WELCOME IN             #").AppendLine();
            builder.Append("   #         HEROES AND CREATURES         #").AppendLine();
            builder.Append("    #             4K EDITION             #").AppendLine();
            builder.Append("     ####################################").JumpTwoLines();
            builder.Append("             PLEASE PRESS ANY KEY").AppendLine().JumpTwoLines();
            Console.WriteLine(builder.ToString());
            Console.ReadKey();
            Console.Clear();
        }

        public void YouWonScreen() {
            Console.Clear();
            StringBuilder builder = new StringBuilder();
            builder.JumpTwoLines();
            builder.Append("    GGGG     GGGG").AppendLine();
            builder.Append("   G        G").AppendLine();
            builder.Append("   G  GGG   G  GGG").AppendLine();
            builder.Append("   G    G   G    G").AppendLine();
            builder.Append("    GGGG     GGGG").AppendLine();
            builder.JumpTwoLines();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(builder.ToString());
            Console.ResetColor();
            PressToExitBlock();
        }

        public void YouLooseScreen() {
            Console.Clear();
            StringBuilder builder = new StringBuilder();
            builder.JumpTwoLines();
            builder.Append("    CCCCC   H    H    EEEEE   H    H").AppendLine();
            builder.Append("   C        H    H   E        H    H").AppendLine();
            builder.Append("   C        HHHHHH   EEEE     HHHHHH").AppendLine();
            builder.Append("   C        H    H   E        H    H").AppendLine();
            builder.Append("    CCCCC   H    H    EEEEE   H    H").AppendLine();
            builder.JumpTwoLines();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(builder.ToString());
            Console.ResetColor();
            PressToExitBlock();
        }

        private void PressToExitBlock() {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}