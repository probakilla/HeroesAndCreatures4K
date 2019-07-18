using System;
using System.Collections.Generic;

namespace HeroesAndCreatures.User {
    internal static class UserConsts {
        public static readonly int ImpossibleUserChoice = -1;
        public static readonly int WaitAfterActionTime = 1500;
        public static readonly List<ConsoleKey> UserTargetOptions =
            new List<ConsoleKey> { ConsoleKey.D0, ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3 };
    }
}
