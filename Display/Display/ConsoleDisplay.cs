using Display.Extensions;
using System;
using System.Text;

namespace Display {
    public static class ConsoleDisplay {
        private static readonly int INFO_LINE = 20;
        private static readonly int DIALOG_LINE = 21;
        private static readonly int EMPTY_PADDING = 64;

        public static void DialogMessage(string message) {
            ResetDialogLine();
            WriteDialog(message, false);
            System.Threading.Thread.Sleep(1250);
        }

        public static void InfoMessage(string message) {
            ResetInfoLine();
            WriteDialog(message, true);
        }

        public static void ResetDialogLine() {
            string emptyString = string.Empty.PadLeft(EMPTY_PADDING);
            WriteDialog(emptyString, false);
        }

        public static void ResetInfoLine() {
            string emptyString = string.Empty.PadLeft(EMPTY_PADDING);
            WriteDialog(emptyString, true);
        }

        private static void WriteDialog(string message, bool isInfoMessage) {
            int line = (isInfoMessage) ? INFO_LINE : DIALOG_LINE;
            try {
                Console.SetCursorPosition(0, line);
                Console.Write(message);
            } catch (ArgumentOutOfRangeException e) {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public static void TitleScreen() {
            StringBuilder builder = new StringBuilder();
            builder.Append("########################################").AppendLine()
              .Append("#    WELCOME IN HEROES AND CREATURE    #").AppendLine()
              .Append("#              4K EDITION              #").AppendLine()
              .Append("########################################").AppendLine().AppendLine()
              .Append("        PRESS ANY KEY TO PLAY.").AppendLine()
              .JumpTwoLines();
            Console.WriteLine(builder.ToString());
            Console.ReadKey();
            Console.Clear();
        }

        public static void YouWonScreen() {
            Console.Clear();
            StringBuilder builder = new StringBuilder();
            builder.JumpTwoLines();
            builder.Append("    GGGG     GGGG").AppendLine();
            builder.Append("   G        G").AppendLine();
            builder.Append("   G  GGG   G  GGG").AppendLine();
            builder.Append("   G    G   G    G").AppendLine();
            builder.Append("    GGGG     GGGG").AppendLine();
            builder.JumpTwoLines();
            Console.WriteLine(builder.ToString());
            PressToExitBlock();
        }

        public static void YouLooseScreen() {
            Console.Clear();
            StringBuilder builder = new StringBuilder();
            builder.JumpTwoLines();
            builder.Append("    CCCCC   H    H    EEEEE   H    H").AppendLine();
            builder.Append("   C        H    H   E        H    H").AppendLine();
            builder.Append("   C        HHHHHH   EEEE     HHHHHH").AppendLine();
            builder.Append("   C        H    H   E        H    H").AppendLine();
            builder.Append("    CCCCC   H    H    EEEEE   H    H").AppendLine();
            builder.JumpTwoLines();
            Console.WriteLine(builder.ToString());
            PressToExitBlock();
        }

        private static void PressToExitBlock() {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}