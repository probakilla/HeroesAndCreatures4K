﻿using System;
using System.Collections.Generic;
using SwaggAndCreaturesLib.Characters;
using SwaggAndCreaturesLib.Extensions;

namespace SwaggAndCreaturesLib.User
{
    public class Player : AbstractUser
    {
        public Player(List<ICharacter> team) : base(team)
        {
        }

        public override void Play(List<ICharacter> oppositeTeam)
        {
            ICharacter character = GetNextToAttack();
            int choice = -1;
            bool continueFlag = true;
            do
            {
                choice = GetUserInput();
                if (IsTargetValid(oppositeTeam, choice))
                {
                    continueFlag = false;
                }
            } while (continueFlag);
            oppositeTeam[choice].Block(character.Attack());
        }

        private int GetUserInput()
        {
            bool continueFlag = true;
            int choice = -1;
            do
            {
                ConsoleDisplay.DialogMessage("Please select a target");
                string value = Console.ReadLine();
                try
                {
                    choice = Convert.ToInt32(value);
                    if (ValidChoice(choice))
                    {
                        continueFlag = false;
                    }
                }
                catch
                {
                    Console.WriteLine("InvalidInput");
                }
            } while (continueFlag);
            return choice;
        }

        private bool ValidChoice(int userChoice)
        {
            return userChoice >= 0 && userChoice <= 3;
        }
    }
}
