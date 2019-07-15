using SwaggAndCreaturesLib.Characters;
using SwaggAndCreaturesLib.Fight;
using SwaggAndCreaturesLib.User;
using System;
using System.Collections.Generic;

namespace Unity4KDisplay
{
    public static class MainWindow
    {

        private static void TestCharacterDraw()
        {
            List<ICharacter> computerTeam = RandomTeam(4, false);
            List<ICharacter> playerTeam = RandomTeam(4, true);
            IUser cpu = new Computer(computerTeam);
            IUser player = new Player(playerTeam);
            Fight fight = new Fight(cpu, player);
            fight.StartFight();
        }

        public static void Main(string[] args)
        {
            TestCharacterDraw();
        }

        private static List<ICharacter> RandomTeam(int teamLength, bool isPlayerTeam)
        {
            List<ICharacter> team = new List<ICharacter>();
            for (int i = 0; i < teamLength; ++i)
            {
                double randomHealth = GenerateRandomDouble(0.0, 100.0);
                int randomAgility = GenerateRandomInteger(0, 100);
                int characterPlace = (isPlayerTeam) ? i + 4 : i;
                team.Add(new CharacterConsoleDisplay((int)randomHealth, randomAgility, characterPlace));
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
            return rand.Next(min, max);
        }
    }
}
