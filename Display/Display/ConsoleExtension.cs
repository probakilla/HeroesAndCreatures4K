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
            string emptyString = String.Empty.PadLeft(EMPTY_PADDING);
            WriteDialog(emptyString, false);
        }

        public static void ResetInfoLine() {
            string emptyString = String.Empty.PadLeft(EMPTY_PADDING);
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

        public static string TitleScreen() {
            StringBuilder builder = new StringBuilder();
            builder.Append("########################################").AppendLine()
              .Append("#    WELCOME IN HEROES AND CREATURE    #").AppendLine()
              .Append("#              4K EDITION              #").AppendLine()
              .Append("########################################").AppendLine().AppendLine()
              .Append("Press any key to play.").AppendLine()
              .AppendLine().AppendLine();
            return builder.ToString();
        }
    }
}