using SwaggAndCreaturesLib.Characters;
using System;
using System.Collections.Generic;

namespace Unity4KDisplay
{
    public static class MainWindow
    {

        public static void Main(string[] args)
        {
            ConsoleDisplay display = ConsoleDisplay.Instance;
            display.Launch();
        }

        private static List<ICharacter> RandomTeam(int teamLength)
        {
            List<ICharacter> team = new List<ICharacter>();
            for (int i = 0; i < teamLength; ++i)
            {
                double randomHealth = GenerateRandomDouble(0.0, 100.0);
                int randomAgility = GenerateRandomInteger(0, 100);
                team.Add(new Human(randomHealth, randomAgility));
            }
            return team;
        }

        private static double GenerateRandomDouble(double min, double max)
        {
            Random rand = new Random();
            double next = rand.NextDouble();
            return min + (next * (max - min));
        }

        private static int GenerateRandomInteger(int min, int max)
        {
            Random rand = new Random();
            int next = rand.Next();
            return min + (next * (max - min));
        }
    }
}
