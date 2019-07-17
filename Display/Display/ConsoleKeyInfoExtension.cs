using System;

namespace Display.Display {
    public static class ConsoleKeyInfoExtension {
        public static bool IsValidOption(this ConsoleKeyInfo keyInfo) {
            return keyInfo.Key == ConsoleKey.D1;
        }

        public static bool IsValidTargetChoice(this ConsoleKeyInfo keyInfo) {
            return keyInfo.Key == ConsoleKey.D0 || keyInfo.Key == ConsoleKey.D1 ||
                keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.D3;
        }

        public static int GetKeyInt(this ConsoleKeyInfo keyInfo) {
            return Convert.ToInt32(keyInfo.KeyChar.ToString());
        }

        public static OptionChoices ToOptionChoices(this ConsoleKeyInfo keyInfo) {
            switch(keyInfo.GetKeyInt()) {
                case 1:
                    return OptionChoices.RandomFight;
                default:
                    return OptionChoices.Unrecognized;
            }
        }
    }
}
