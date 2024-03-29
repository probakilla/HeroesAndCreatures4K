﻿using ConsoleDisplay.Extensions;
using ConsoleDisplay.Screens;
using HeroesAndCreatures.Characters;
using HeroesAndCreatures.Team;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndCreatures.User {
    public class ConsolePlayer : AbstractUserImpl {
        private readonly GameDisplay Display = new GameDisplay();

        public ConsolePlayer(CharacterTeam team) : base(team) { }

        public override void Play(List<AbstractCharacter> oppositeTeam) {
            Display.DialogMessage("Please select a target ");
            AbstractCharacter character = GetNextToAttack();
            character.HisTurnDisplay();
            int choice;
            bool continueFlag = true;
            do {
                WriteCharacterInfo(character);
                choice = GetUserInput();
                if (IsTargetValid(oppositeTeam, choice)) {
                    continueFlag = false;
                } else {
                    Display.DialogMessage("Can't attack dead characters ");
                }
            } while (continueFlag);
            oppositeTeam[choice].Block(character.Attack());
            character.Display();
        }

        private int GetUserInput() {
            do {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                try {
                    if (keyInfo.IsInList(UserConsts.UserTargetOptions)) {
                        return keyInfo.GetKeyInt();
                    }
                } catch {
                    Display.DialogMessage("  Invalid Input ! (Number between 0-3) ");
                }
                Display.DialogMessage("  Invalid Input ! (Number between 0-3) ");
            } while (true);
        }

        private void WriteCharacterInfo(AbstractCharacter character) {
            StringBuilder builder = new StringBuilder("Turn: (");
            builder.Append(character.CharacterPlace.ToString())
                .Append(") Attack power: ")
                .Append((int)character.Power).Append(" ");
            Display.InfoMessage(builder.ToString());
        }
    }
}