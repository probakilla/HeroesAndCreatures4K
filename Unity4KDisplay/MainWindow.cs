using SwaggAndCreaturesLib.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unity4KDisplay
{
    public static class MainWindow
    {
        private const int TEAM_LENGTH = 4;

        public static void Main(string[] args)
        {
            string titleScreen = TitleScreen();
            List<ICharacter> computerTeam = RandomTeam(TEAM_LENGTH);
            List<ICharacter> playerTeam = RandomTeam(TEAM_LENGTH);
            string computerTeamDisplay = TeamDisplay.DisplayTeam(computerTeam, false);
            string playerTeamDisplay = TeamDisplay.DisplayTeam(playerTeam, true);
            Console.WriteLine(titleScreen);
            Console.WriteLine(computerTeamDisplay);
            Console.WriteLine();
            Console.WriteLine(TeamDisplay.TeamSeparator(TEAM_LENGTH));
            Console.WriteLine();
            Console.WriteLine(playerTeamDisplay);
            Console.ReadLine();
        }

        private static string TitleScreen()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("########################################").AppendLine()
                   .Append("#    WELCOME IN HEROES AND CREATURE    #").AppendLine()
                   .Append("#              4K EDITION              #").AppendLine()
                   .Append("########################################").AppendLine()
                   .AppendLine().AppendLine();
            return builder.ToString();
        }

        private static List<ICharacter> RandomTeam(int teamLength)
        {
            List<ICharacter> team = new List<ICharacter>();
            for (int i = 0; i < teamLength; ++i)
            {
                double randomHealth = GenerateRandomDouble(0.0, 100.0);
                team.Add(new Human(randomHealth));
            }
            return team;
        }

        private static double GenerateRandomDouble(double min, double max)
        {
            Random rand = new Random();
            double next = rand.NextDouble();
            return min + (next * (max - min));
        }
    }

}
