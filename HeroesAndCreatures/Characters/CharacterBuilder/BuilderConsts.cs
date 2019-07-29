using System;
using System.Collections.Generic;

namespace HeroesAndCreatures.Characters.CharacterBuilder {
    public static class CharacterBuilderConsts {
        public static readonly string Title = "   NEW CHARACTER CREATION";
        public static readonly string QuestionString = "   What do you want to change ?";
        public static readonly string OptionsString = "   A) Agility  H) Health  W) Weapon  R) Random    F) Finished";
        public static readonly string NotAllocated = "   Not allocated";
        public static readonly string ValuesLimitString = "   Please enter a value between 0 and 9999";
        public static readonly string AbortWarningString = "   The character isn't properly created, abort creation ?";
        public static readonly string YesNoString = "   y / N";
        public static readonly int MinStat = 1;
        public static readonly int MaxStat = 9999;
        public static readonly int TitleRow = 1;
        public static readonly int HealthRow = 3;
        public static readonly int AgilityRow = 4;
        public static readonly int WeaponRow = 5;
        public static readonly int DialogRow = 7;
        public static readonly int SecongDialogRow = 8;
        public static readonly List<ConsoleKey> BuilderOptions = new List<ConsoleKey>
        { ConsoleKey.A, ConsoleKey.H, ConsoleKey.W, ConsoleKey.R, ConsoleKey.F };
        public static readonly List<ConsoleKey> AbortOptions = new List<ConsoleKey>
        { ConsoleKey.N, ConsoleKey.Y, ConsoleKey.Enter };
    }

    public static class TeamBuilderConsts {
        public static readonly string PlayerTitle = "   PLAYER TEAM CREATION";
        public static readonly string ComputerTitle = "   COMPUTER TEAM CREATION";
        public static readonly string QuestionString = CharacterBuilderConsts.QuestionString;
        public static readonly string EditCharacterString = "   C) Edit characters   F) Finished";
        public static readonly string OptionsString = "   C) Create new character    F) Finished";
        public static readonly string NotFinisedString = "   The team is not complete";
        public static readonly string PlaceSelectText = "   Select which one to edit";
        public static readonly string AvailablePlaces = "   A number between 1 and 4 (included)";
        public static readonly int TitleRow = 1;
        public static readonly int TeamSummaryRow = 3;
        public static readonly int DialogRow = 8;
        public static readonly int SecondDialogRow = 9;
        public static readonly List<ConsoleKey> BuilderOptions = new List<ConsoleKey>
        { ConsoleKey.C, ConsoleKey.F };
        public static readonly List<ConsoleKey> TeamPlaces = new List<ConsoleKey>
        { ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4 };
    }
}
