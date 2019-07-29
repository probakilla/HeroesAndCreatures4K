using ConsoleDisplay.Screens;
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

        public ConsoleCharacter(float health, int agility) : base(health, agility) { }

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
            WriteAt("(", 3, DisplayConsts.PlaceRow);
            WriteAt(CharacterPlace.ToString(), 4, DisplayConsts.PlaceRow);
            WriteAt(")", 5, DisplayConsts.PlaceRow);

            WriteAt("O", 4, DisplayConsts.HeadRow);

            WriteAt("/", 3, DisplayConsts.ArmsRow);
            WriteAt("|", 4, DisplayConsts.ArmsRow);
            WriteAt("\\", 5, DisplayConsts.ArmsRow);

            WriteAt("|", 4, DisplayConsts.TorsoRow);

            WriteAt("/", 3, DisplayConsts.LegsRow);
            WriteAt("\\", 5, DisplayConsts.LegsRow);
        }

        private void DrawDeadStats() {
            WriteRow(" HP: DEAD", DisplayConsts.HealthRow);
            WriteRow("  I: DEAD", DisplayConsts.InitiativeRow);
        }

        private void WriteRow(string str, int row) {
            WriteAt(str, DisplayConsts.OriginRow, row);
        }

        private void WriteAt(string str, int x, int y) {
            GameDisplay.WriteAt(str, Abscissa + x, Ordinate + y);
        }

        private string GetHpString() {
            int healthValue = Convert.ToInt32(Health);
            return healthValue.ToString().PadLeft(DisplayConsts.MaxStatSize);
        }

        private void ChangeConsoleColorFromHealthPercentage(float currentHealth) {
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
            BlinkCharacter("X", 2, DisplayConsts.LegsRow);
            BlinkCharacter("X", 3, DisplayConsts.TorsoRow);
            BlinkCharacter("X", 4, DisplayConsts.ArmsRow, "|");
            BlinkCharacter("X", 5, DisplayConsts.HeadRow);
            BlinkCharacter("X", 6, DisplayConsts.PlaceRow);
        }

        private void BlinkCharacter(string character, int abscissa, int ordinate, string oldCharacter = " ") {
            WriteAt(character, abscissa, ordinate);
            AnimationDelay(DisplayConsts.BlinkWaitDuration);
            WriteAt(oldCharacter, abscissa, ordinate);
        }

        private void AnimationDelay(int waitDuration) {
            System.Threading.Thread.Sleep(waitDuration);
        }

        public override void Block(float amount) {
            GetHitAnimation();
            int initialHp = (int)Health;
            base.Block(amount);
            HealthLossAnimation(initialHp);
        }

        private void DrawHealth(int healthPoints) {
            WriteAt(DisplayConsts.HealthString, 0, DisplayConsts.HealthRow);
            string hpString = Convert.ToString(healthPoints).PadLeft(DisplayConsts.HealthRow);
            ChangeConsoleColorFromHealthPercentage(healthPoints);
            WriteAt(hpString, 4, DisplayConsts.HealthRow);
            Console.ResetColor();
        }

        private void HealthLossAnimation(int initialHp) {
            int waitTime = initialHp > DisplayConsts.HealthThresholdAnimation ?
                DisplayConsts.QuickHealthWaitDuration :
                DisplayConsts.HealthWaitDuration;
            while (initialHp >= (int)Health) {
                AnimationDelay(waitTime);
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
            WriteAt("_", 2, DisplayConsts.PlaceRow);
            WriteAt("_", 3, DisplayConsts.PlaceRow);
            WriteAt("_", 4, DisplayConsts.PlaceRow);
            WriteAt("_", 5, DisplayConsts.PlaceRow);
            WriteAt("_", 6, DisplayConsts.PlaceRow);

            WriteAt("/", 1, DisplayConsts.HeadRow);
            WriteAt("R", 2, DisplayConsts.HeadRow);
            WriteAt("I", 4, DisplayConsts.HeadRow);
            WriteAt("P", 6, DisplayConsts.HeadRow);
            WriteAt("\\", 7, DisplayConsts.HeadRow);

            WriteAt("|", 1, DisplayConsts.ArmsRow);
            WriteAt("_", 3, DisplayConsts.ArmsRow);
            WriteAt("|", 4, DisplayConsts.ArmsRow);
            WriteAt("_", 5, DisplayConsts.ArmsRow);
            WriteAt("|", 7, DisplayConsts.ArmsRow);

            WriteAt("|", 7, DisplayConsts.TorsoRow);
            WriteAt("|", 4, DisplayConsts.TorsoRow);
            WriteAt("|", 1, DisplayConsts.TorsoRow);

            WriteAt("|", 7, DisplayConsts.LegsRow);
            WriteAt("|", 4, DisplayConsts.LegsRow);
            WriteAt("|", 1, DisplayConsts.LegsRow);
        }

        public void ClearCharacterDisplay() {
            WriteAt(" ", 4, DisplayConsts.HeadRow);

            WriteAt(" ", 3, DisplayConsts.ArmsRow);
            WriteAt(" ", 4, DisplayConsts.ArmsRow);
            WriteAt(" ", 5, DisplayConsts.ArmsRow);

            WriteAt(" ", 4, DisplayConsts.TorsoRow);

            WriteAt(" ", 3, DisplayConsts.LegsRow);
            WriteAt(" ", 5, DisplayConsts.LegsRow);
        }

        private void DrawStats() {
            WriteAt(DisplayConsts.HealthString, 0, DisplayConsts.HealthRow);
            ChangeConsoleColorFromHealthPercentage(Health);
            WriteAt(GetHpString(), 4, DisplayConsts.HealthRow);
            Console.ResetColor();
            WriteAt(GetInitiativeString(), 0, DisplayConsts.InitiativeRow);
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
            WriteAt(DisplayConsts.InitiativeString, 0, DisplayConsts.InitiativeRow);
            int init = initiative;
            if (initiative > DisplayConsts.MaxInitiativeDisplayed) {
                init = DisplayConsts.MaxInitiativeDisplayed;
            }
            string initiativeString = Convert.ToString(init).PadLeft(DisplayConsts.MaxStatSize);
            if (init == DisplayConsts.MaxInitiativeDisplayed) {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            WriteAt(initiativeString, 4, DisplayConsts.InitiativeRow);
            Console.ResetColor();
        }

        public override void HisTurnDisplay() {
            Console.ForegroundColor = ConsoleColor.Red;
            DrawCharacter();
            Console.ResetColor();
        }
    }
}