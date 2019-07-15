using SwaggAndCreaturesLib.Characters;
using System;
using System.Collections.Generic;

namespace SwaggAndCreaturesLib.User
{
    public class Computer : AbstractUser
    {
        public Computer(List<ICharacter> team) : base(team)
        {
        }

        public override void Play(List<ICharacter> oppositeTeam)
        {
            ICharacter character = GetNextToAttack();
            int choice = -1;
            bool continueFlag = true;
            do
            {
                choice = GenerateRandomInteger(0, oppositeTeam.Count);
                if (IsTargetValid(oppositeTeam, choice))
                {
                    continueFlag = false;
                }
            } while (continueFlag);
            oppositeTeam[choice].Block(character.Attack());
        }

        private static int GenerateRandomInteger(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max);
        }
    }
}
