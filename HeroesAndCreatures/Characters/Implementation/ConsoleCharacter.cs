using System;

namespace HeroesAndCreatures.Characters {
    internal class ConsoleCharacter : AbstractCharacterImplementation {
        private int Abscissa;
        private int Ordinate;

        public override int CharacterPlace {
            get => Place;
            set {
                Place = value;
                UpdateCoordinates();
            }
        }

        public ConsoleCharacter(double health, int agility) : base(health, agility) { }

        private void UpdateCoordinates() {
            CalculateOrdinate();
            CalculateAbscissa();
        }

        private void CalculateOrdinate() {
            if (IsComputerCharacter()) {
                Ordinate = DisplayConsts.OriginRow;
            } else if (IsPlayerCharacter()) {
                Ordinate = DisplayConsts.OriginRow + DisplayConsts.BoxHeight + DisplayConsts.FieldSpace;
            } else {
                throw new InvalidOperationException();
            }
        }

        private void CalculateAbscissa() {
            int placeTmp = CharacterPlace;
            if (IsPlayerCharacter()) {
                placeTmp = CharacterPlace - DisplayConsts.FirstPlayerPlace;
            }
            Abscissa = DisplayConsts.OriginColumn + (placeTmp * DisplayConsts.BoxWidth);
        }

        private bool IsComputerCharacter() {
            return CharacterPlace >= DisplayConsts.FirstComputerPlace &&
                    CharacterPlace <= DisplayConsts.LastComputerPlace;
        }

        private bool IsPlayerCharacter() {
            return CharacterPlace >= DisplayConsts.FirstPlayerPlace &&
                    CharacterPlace <= DisplayConsts.LastPlayerPlace;
        }

        public override void Display() {
            DrawCharacter();
            DrawStats();
        }

        private void DrawCharacter() {
            WriteAt("(", 3, DisplayConsts.PlaceColumn);
            WriteAt(CharacterPlace.ToString(), 4, DisplayConsts.PlaceColumn);
            WriteAt(")", 5, DisplayConsts.PlaceColumn);

            WriteAt("O", 4, DisplayConsts.HeadColumn);

            WriteAt("/", 3, DisplayConsts.ArmsColumn);
            WriteAt("|", 4, DisplayConsts.ArmsColumn);
            WriteAt("\\", 5, DisplayConsts.ArmsColumn);

            WriteAt("|", 4, DisplayConsts.TorsoColumn);

            WriteAt("/", 3, DisplayConsts.LegsColumn);
            WriteAt("\\", 5, DisplayConsts.LegsColumn);
        }

        private void DrawDeadStats() {
            WriteAt(" HP: DEAD", 0, DisplayConsts.HealthColumn);
            WriteAt("  I: DEAD", 0, DisplayConsts.InitiativeColumn);
        }

        private void WriteAt(string str, int x, int y) {
            try {
                Console.SetCursorPosition(
                    DisplayConsts.OriginColumn + (Abscissa + x),
                    DisplayConsts.OriginRow + (Ordinate + y));
                Console.Write(str);
            } catch (ArgumentOutOfRangeException e) {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        private string GetHpString() {
            int healthValue = Convert.ToInt32(Health);
            return healthValue.ToString().PadLeft(DisplayConsts.MaxStatSize);
        }

        private void ChangeConsoleColorFromHealthPercentage(double currentHealth) {
            int tier = Convert.ToInt32(MaxHealth / 3);
            int roundedCurrentHealth = Convert.ToInt32(currentHealth);
            if (roundedCurrentHealth <= tier) {
                Console.ForegroundColor = ConsoleColor.Red;
            } else if (roundedCurrentHealth <= tier * 2) {
                Console.ForegroundColor = ConsoleColor.Yellow;
            } else {
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        private string GetInitiativeString() {
            string initLettre = DisplayConsts.InitiativeString;
            string initValue = Convert.ToString(Initiative).PadLeft(DisplayConsts.MaxStatSize);
            return initLettre + initValue;
        }

        private void GetHitAnimation() {
            BlinkCharacter("X", 2, DisplayConsts.LegsColumn);
            BlinkCharacter("X", 3, DisplayConsts.TorsoColumn);
            BlinkCharacter("X", 4, DisplayConsts.ArmsColumn, "|");
            BlinkCharacter("X", 5, DisplayConsts.HeadColumn);
            BlinkCharacter("X", 6, DisplayConsts.PlaceColumn);
        }

        private void BlinkCharacter(string character, int abscissa, int ordinate, string oldCharacter = " ") {
            WriteAt(character, abscissa, ordinate);
            AnimationDelay(DisplayConsts.BlinkWaitDuration);
            WriteAt(oldCharacter, abscissa, ordinate);
        }

        private void AnimationDelay(int waitDuration) {
            System.Threading.Thread.Sleep(waitDuration);
        }

        public override void Block(double amount) {
            GetHitAnimation();
            int initialHp = (int)Health;
            base.Block(amount);
            HealthLossAnimation(initialHp);
        }

        private void DrawHealth(int healthPoints) {
            WriteAt(DisplayConsts.HealthString, 0, DisplayConsts.HealthColumn);
            string hpString = Convert.ToString(healthPoints).PadLeft(DisplayConsts.HealthColumn);
            ChangeConsoleColorFromHealthPercentage(healthPoints);
            WriteAt(hpString, 4, DisplayConsts.HealthColumn);
            Console.ResetColor();
        }

        private void HealthLossAnimation(int initialHp) {
            while (initialHp >= (int)Health) {
                AnimationDelay(DisplayConsts.HealthWaitDuration);
                DrawHealth(initialHp--);
            }
        }

        public override bool IsDead() {
            bool isDead = base.IsDead();
            if (isDead) {
                ClearCharacterDisplay();
                DrawDeadStats();
                DeadDisplay();
            }
            return isDead;
        }

        private void DeadDisplay() {
            WriteAt("_", 2, DisplayConsts.PlaceColumn);
            WriteAt("_", 3, DisplayConsts.PlaceColumn);
            WriteAt("_", 4, DisplayConsts.PlaceColumn);
            WriteAt("_", 5, DisplayConsts.PlaceColumn);
            WriteAt("_", 6, DisplayConsts.PlaceColumn);

            WriteAt("/", 1, DisplayConsts.HeadColumn);
            WriteAt("R", 2, DisplayConsts.HeadColumn);
            WriteAt("I", 4, DisplayConsts.HeadColumn);
            WriteAt("P", 6, DisplayConsts.HeadColumn);
            WriteAt("\\", 7, DisplayConsts.HeadColumn);

            WriteAt("|", 1, DisplayConsts.ArmsColumn);
            WriteAt("_", 3, DisplayConsts.ArmsColumn);
            WriteAt("|", 4, DisplayConsts.ArmsColumn);
            WriteAt("_", 5, DisplayConsts.ArmsColumn);
            WriteAt("|", 7, DisplayConsts.ArmsColumn);

            WriteAt("|", 7, DisplayConsts.TorsoColumn);
            WriteAt("|", 4, DisplayConsts.TorsoColumn);
            WriteAt("|", 1, DisplayConsts.TorsoColumn);

            WriteAt("|", 7, DisplayConsts.LegsColumn);
            WriteAt("|", 4, DisplayConsts.LegsColumn);
            WriteAt("|", 1, DisplayConsts.LegsColumn);
        }

        public void ClearCharacterDisplay() {
            WriteAt(" ", 4, DisplayConsts.HeadColumn);

            WriteAt(" ", 3, DisplayConsts.ArmsColumn);
            WriteAt(" ", 4, DisplayConsts.ArmsColumn);
            WriteAt(" ", 5, DisplayConsts.ArmsColumn);

            WriteAt(" ", 4, DisplayConsts.TorsoColumn);

            WriteAt(" ", 3, DisplayConsts.LegsColumn);
            WriteAt(" ", 5, DisplayConsts.LegsColumn);
        }

        private void DrawStats() {
            WriteAt(DisplayConsts.HealthString, 0, DisplayConsts.HealthColumn);
            ChangeConsoleColorFromHealthPercentage(Health);
            WriteAt(GetHpString(), 4, DisplayConsts.HealthColumn);
            Console.ResetColor();
            WriteAt(GetInitiativeString(), 0, DisplayConsts.InitiativeColumn);
        }

        public override void IncreaseInitiative() {
            int baseInit = Initiative;
            base.IncreaseInitiative();
            if (!IsDead()) {
                while (baseInit < Initiative) {
                    DrawInitiative(baseInit++);
                }
            }
        }

        private void DrawInitiative(int initiative) {
            WriteAt(DisplayConsts.InitiativeString, 0, DisplayConsts.InitiativeColumn);
            int init = initiative;
            if (initiative > DisplayConsts.MaxInitiativeDisplayed) {
                init = DisplayConsts.MaxInitiativeDisplayed;
            }
            string initiativeString = Convert.ToString(init).PadLeft(DisplayConsts.MaxStatSize);
            if (init == DisplayConsts.MaxInitiativeDisplayed) {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            WriteAt(initiativeString, 4, DisplayConsts.InitiativeColumn);
            Console.ResetColor();
        }

        public override void HisTurnDisplay() {
            Console.ForegroundColor = ConsoleColor.Red;
            DrawCharacter();
            Console.ResetColor();
        }
    }
}