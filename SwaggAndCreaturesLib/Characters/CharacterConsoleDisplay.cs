using System;

namespace SwaggAndCreaturesLib.Characters
{
    public class CharacterConsoleDisplay : Human
    {
        private readonly int OrigRow = 0;
        private readonly int OrigCol = 0;
        private const int BOX_WIDTH = 9;
        private const int BOX_HEIGHT = 7;
        private const int FIELD_SPACE = 3;
        private const int FIRST_COMPUTER_CHAR = 0;
        private const int LAST_COMPUTER_CHAR = 3;
        private const int FIRST_PLAYER_CHAR = 4;
        private const int LAST_PLAYER_CHAR = 7;
        private const int WAIT_DURATION = 150;
        private const int HEALTH_WAIT_DURATION = 2;

        private int Abscissa;
        private int Ordinate;
        private int CharacterNumber;

        public CharacterConsoleDisplay(int health, int agility, int characterNumber) : base(health, agility)
        {
            CharacterNumber = characterNumber;
            CalculateOrdinate();
            CalculateAbscissa();
        }

        private void CalculateOrdinate()
        {
            if (IsComputerCharacter())
            {
                Ordinate = OrigRow;
            }
            else if (IsPlayerCharacter())
            {
                Ordinate = OrigRow + BOX_HEIGHT + FIELD_SPACE;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private void CalculateAbscissa()
        {
            if (IsPlayerCharacter())
            {
                CharacterNumber = CharacterNumber - FIRST_PLAYER_CHAR;
            }
            Abscissa = OrigCol + (CharacterNumber * BOX_WIDTH);
        }

        private bool IsComputerCharacter()
        {
            return CharacterNumber >= FIRST_COMPUTER_CHAR && CharacterNumber <= LAST_COMPUTER_CHAR;
        }

        private bool IsPlayerCharacter()
        {
            return CharacterNumber >= FIRST_PLAYER_CHAR && CharacterNumber <= LAST_PLAYER_CHAR;
        }

        public void DrawCharacter()
        {
            WriteAt("(", 3, 0);
            WriteAt(CharacterNumber.ToString(), 4, 0);
            WriteAt(")", 5, 0);

            WriteAt("O", 4, 1);

            WriteAt("/", 3, 2);
            WriteAt("|", 4, 2);
            WriteAt("\\", 5, 2);

            WriteAt("|", 4, 3);

            WriteAt("/", 3, 4);
            WriteAt("\\", 5, 4);
            DrawStats();
        }

        private void DrawDeadStats()
        {
            WriteAt(" HP: DEAD", 0, 5);
            WriteAt(" I: DEAD", 0, 6);
        }

        private void WriteAt(string str, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(OrigCol + (Abscissa + x), OrigRow + (Ordinate + y));
                Console.Write(str);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        private string GetHpString()
        {
            string hpString = " HP:";
            return hpString + Health.ToString().PadLeft(4, ' ');
        }

        private string GetInitiativeString()
        {
            string initLettre = " I:";
            string initValue = Convert.ToString(Initiative).PadLeft(4, ' ');
            return initLettre + initValue;
        }

        private void GetHitAnimation()
        {
            BlinkCharacter("X", 2, 4);
            BlinkCharacter("X", 3, 3);
            BlinkCharacter("X", 4, 2, "|");
            BlinkCharacter("X", 5, 1);
            BlinkCharacter("X", 6, 0);
        }

        private void BlinkCharacter(string character, int abscissa, int ordinate, string oldCharacter = " ")
        {
            WriteAt(character, abscissa, ordinate);
            AnimationDelay(WAIT_DURATION);
            WriteAt(oldCharacter, abscissa, ordinate);
        }

        private void AnimationDelay(int waitDuration)
        {
            System.Threading.Thread.Sleep(waitDuration);
        }

        public override void Block(double amount)
        {
            GetHitAnimation();
            int initialHp = (int)Health;
            base.Block(amount);
            HealthLossAnimation(initialHp);
        }

        private void DrawHealth(int healthPoints)
        {
            string hpString = " HP: " + Convert.ToString(healthPoints).PadLeft(4, ' ');
            WriteAt(hpString, Abscissa, 5);
        }

        private void HealthLossAnimation(int initialHp)
        {
            while (initialHp >= (int)Health)
            {
                AnimationDelay(HEALTH_WAIT_DURATION);
                DrawHealth(initialHp--);
            }
        }

        public override bool IsDead()
        {
            bool isDead = base.IsDead();
            if (isDead)
            {
                ClearCharacterDisplay();
                DrawDeadStats();
                DeadDisplay();
            }
            return isDead;
        }

        private void DeadDisplay()
        {
            WriteAt("_", 2, 0);
            WriteAt("_", 3, 0);
            WriteAt("_", 4, 0);
            WriteAt("_", 5, 0);
            WriteAt("_", 6, 0);

            WriteAt("/", 1, 1);
            WriteAt("R", 2, 1);
            WriteAt("I", 4, 1);
            WriteAt("P", 6, 1);
            WriteAt("\\", 7, 1);

            WriteAt("|", 1, 2);
            WriteAt("_", 3, 2);
            WriteAt("|", 4, 2);
            WriteAt("_", 5, 2);
            WriteAt("|", 7, 2);

            WriteAt("|", 7, 3);
            WriteAt("|", 4, 3);
            WriteAt("|", 1, 3);

            WriteAt("|", 7, 4);
            WriteAt("|", 4, 4);
            WriteAt("|", 1, 4);
        }

        public void ClearCharacterDisplay()
        {
            WriteAt(" ", 4, 1);

            WriteAt(" ", 3, 2);
            WriteAt(" ", 4, 2);
            WriteAt(" ", 5, 2);

            WriteAt(" ", 4, 3);

            WriteAt(" ", 3, 4);
            WriteAt(" ", 5, 4);
        }

        private void DrawStats()
        {
            WriteAt(GetHpString(), 0, 5);
            WriteAt(GetInitiativeString(), 0, 6);
        }

        public override void IncreaseInitiative()
        {
            int baseInit = Initiative;
            base.IncreaseInitiative();
            while (baseInit < Initiative)
            {
                DrawInitiative(baseInit++);
            }
        }

        private void DrawInitiative(int initiative)
        {
            string initiativeString = " I: " + Convert.ToString(initiative).PadLeft(4, ' ');
            WriteAt(initiativeString, Abscissa, 6);
        }
    }
}
