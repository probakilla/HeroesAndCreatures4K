using System;
using System.Collections.Generic;

namespace HeroesAndCreatures.Characters.CharacterBuilder {
    public static class BuilderConsts {
        public static readonly string Title = "   NEW CHARACTER CREATION";
        public static readonly int TitleRow = 1;
        public static readonly int HealthRow = 3;
        public static readonly int AgilityRow = 4;
        public static readonly int WeaponRow = 5;
        public static readonly int BuilderDialogLine = 7;
        public static readonly int BuilderSecondDialofLine = 8;
        public static readonly List<ConsoleKey> BuilderOptions = new List<ConsoleKey>
        { ConsoleKey.A, ConsoleKey.H, ConsoleKey.W, ConsoleKey.F };
        public static readonly List<ConsoleKey> AbortOptions = new List<ConsoleKey>
        { ConsoleKey.N, ConsoleKey.Y, ConsoleKey.Enter };
    }
}
