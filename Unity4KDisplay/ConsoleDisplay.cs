using SwaggAndCreaturesLib.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unity4KDisplay
{
    public class ConsoleDisplay
    {
        private static ConsoleDisplay INSTANCE;
        public static ConsoleDisplay Instance
        {
            get
            {
                if (INSTANCE == null)
                {
                    INSTANCE = new ConsoleDisplay();
                }
                return INSTANCE;
            }
            private set { INSTANCE = value; }
        }

        private ConsoleDisplay() { }

        public void Launch()
        {
            DisplayTitleScreen();
        }

        private void DisplayTitleScreen()
        {
            string titleScreen = TitleScreen();
            Console.WriteLine(titleScreen);
            Console.ReadKey();
            Console.Clear();
        }

        private string TitleScreen()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("########################################").AppendLine()
                   .Append("#    WELCOME IN HEROES AND CREATURE    #").AppendLine()
                   .Append("#              4K EDITION              #").AppendLine()
                   .Append("########################################").AppendLine().AppendLine()
                   .Append("Press any key to play.").AppendLine()
                   .AppendLine().AppendLine();
            return builder.ToString();
        }

        public void TeamConsolePrint(List<ICharacter> computerTeam, List<ICharacter> playerTeam)
        {
            string computerTeamDisplay = TeamDisplay.DisplayTeam(computerTeam, false);
            string playerTeamDisplay = TeamDisplay.DisplayTeam(computerTeam, true);
            Console.WriteLine(computerTeamDisplay);
            Console.WriteLine();
            Console.WriteLine(TeamDisplay.TeamSeparator(4));
            Console.WriteLine();
            Console.WriteLine(playerTeamDisplay);
            Console.ReadLine();
        }
    }
}
