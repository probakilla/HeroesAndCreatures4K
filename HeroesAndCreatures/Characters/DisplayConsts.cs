namespace HeroesAndCreatures.Characters {
    public static class DisplayConsts {
        public static readonly int OriginRow = 0;
        public static readonly int OriginColumn = 0;
        public static readonly int PlaceColumn = 0;
        public static readonly int HeadColumn = 1;
        public static readonly int ArmsColumn = 2;
        public static readonly int TorsoColumn = 3;
        public static readonly int LegsColumn = 4;
        public static readonly int HealthColumn = 5;
        public static readonly int InitiativeColumn = 6;

        public static readonly int BoxWidth = 9;
        public static readonly int BoxHeight = 7;
        public static readonly int MaxStatSize = 4;
        public static readonly int FieldSpace = 3;

        public static readonly int FirstComputerPlace = 0;
        public static readonly int LastComputerPlace = 3;
        public static readonly int FirstPlayerPlace = 4;
        public static readonly int LastPlayerPlace = 7;

        public static readonly int BlinkWaitDuration = 150;
        public static readonly int HealthWaitDuration = 20;

        public static readonly string HealthString = " HP:";
        public static readonly string InitiativeString = "  I:";
        public static readonly int MaxInitiativeDisplayed = 1000;
    }
}
