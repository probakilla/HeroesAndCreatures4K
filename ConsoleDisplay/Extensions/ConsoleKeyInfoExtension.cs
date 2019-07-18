using ConsoleDisplay.Screens;
using System;
using System.Collections.Generic;

namespace ConsoleDisplay.Extensions {
    public static class ConsoleKeyInfoExtension {
        public static bool IsValidOption(this ConsoleKeyInfo keyInfo) {
            return keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.Q || keyInfo.Key == ConsoleKey.D2;
        }

        public static int GetKeyInt(this ConsoleKeyInfo keyInfo) {
            return Convert.ToInt32(keyInfo.KeyChar.ToString());
        }

        public static OptionChoices ToOptionChoices(this ConsoleKeyInfo keyInfo) {
            switch(keyInfo.Key) {
                case ConsoleKey.D1:
                    return OptionChoices.RandomFight;
                case ConsoleKey.D2:
                    return OptionChoices.TeamBuilder;
                case ConsoleKey.Q:
                    return OptionChoices.Quit;
                default:
                    return OptionChoices.Unrecognized;
            }
        }

        public static bool IsInList(this ConsoleKeyInfo keyInfo, List<ConsoleKey> keys) {
            return keys.Contains(keyInfo.Key);
        }
    }
}
