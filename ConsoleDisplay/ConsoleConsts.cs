using System;
using System.Collections.Generic;

namespace ConsoleDisplay {
    public static class ConsoleConsts {
        public static readonly int InfoLine = 20;
        public static readonly int DialogLine = 21;
        public static readonly int PaddingSize = 64;
        public static readonly int WaitingTime = 1250;
        public static readonly int OriginRow = 0;
        public static readonly int OriginColumn = 0;

        public static readonly List<ConsoleKey> HomeOptions =
            new List<ConsoleKey> { ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.Q };
    }
}
