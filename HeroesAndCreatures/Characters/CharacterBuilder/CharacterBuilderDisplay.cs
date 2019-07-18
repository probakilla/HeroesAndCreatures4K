using ConsoleDisplay.Extensions;
using ConsoleDisplay.Screens;
using HeroesAndCreatures.Weapons;
using System;
using System.Collections.Generic;

namespace HeroesAndCreatures.Characters.CharacterBuilder {
    public class CharacterBuilderDisplay {
        private readonly ICharacterBuilder Builder;
        private readonly Dictionary<ConsoleKey, Action> KeyAssociation;
        private bool IsBuilding = true;

        public CharacterBuilderDisplay() {
            Builder = new HumanBuilder();
            KeyAssociation = new Dictionary<ConsoleKey, Action> {
                { ConsoleKey.A, delegate() { AskUserForAgility(); } },
                { ConsoleKey.H, delegate() { AskUserForHealth(); } },
                { ConsoleKey.W, delegate() { AskUserForWeaponPower(); } },
                { ConsoleKey.F, delegate() { AskIfNotFinished(); } }
            };
        }

        public AbstractCharacter CharacterBuilderHome() {
            Console.Clear();
            do {
                GameDisplay.WriteRow(BuilderConsts.Title, BuilderConsts.TitleRow);
                DisplayCharacterStatistics();
                DisplayUserDialog("   What do you want to change ?");
                DisplayUserInfo("   A) Agility  H) Health  W) Weapon    F) Finished");
                AskUserForKey();
            } while (IsBuilding);
            return Builder.GetCharacter();
        }

        private void DisplayCharacterStatistics() {
            DisplayCharacterHealth();
            DisplayCharacterAgility();
            DisplayCharacterWeapon();
        }

        private void DisplayCharacterHealth() {
            string health = GetHealthString();
            GameDisplay.ClearRow(BuilderConsts.HealthRow);
            GameDisplay.WriteRow(health, BuilderConsts.HealthRow);
        }

        private string GetHealthString() {
            try {
                CharacterStats stats = Builder.GetCharacterStats();
                int health = Convert.ToInt32(stats.Health);
                return $"   Health: {health.ToString()}";
            } catch {
                return "   No health alocated";
            }
        }

        private void DisplayCharacterAgility() {
            string agility = GetAgilityString();
            GameDisplay.ClearRow(BuilderConsts.AgilityRow);
            GameDisplay.WriteRow(agility, BuilderConsts.AgilityRow);
        }

        private string GetAgilityString() {
            try {
                CharacterStats stats = Builder.GetCharacterStats();
                return $"   Agility: {stats.Agility.ToString()}";
            } catch {
                return "   No Agility alocated";
            }
        }

        private void DisplayCharacterWeapon() {
            string power = GetWeaponString();
            GameDisplay.ClearRow(BuilderConsts.WeaponRow);
            GameDisplay.WriteRow(power, BuilderConsts.WeaponRow);
        }

        private string GetWeaponString() {
            float? power = Builder.WeaponPower;
            if (power.HasValue) {
                int powerConverted = Convert.ToInt32(power);
                return $"   Weapon power: {powerConverted.ToString()}";
            }
            return "   No Weapon equiped";
        }

        private void DisplayUserDialog(string message) {
            GameDisplay.ClearRow(BuilderConsts.BuilderDialogLine);
            GameDisplay.WriteRow(message, BuilderConsts.BuilderDialogLine);
        }

        private void DisplayUserInfo(string message) {
            GameDisplay.ClearRow(BuilderConsts.BuilderSecondDialofLine);
            GameDisplay.WriteRow(message, BuilderConsts.BuilderSecondDialofLine);
        }

        private void AskUserForKey() {
            bool continueFlag = true;
            ConsoleKeyInfo keyInfo;
            do {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.IsInList(BuilderConsts.BuilderOptions)) {
                    continueFlag = false;
                }
            } while (continueFlag);
            CallCorespondingFunction(keyInfo.Key);
        }

        private void CallCorespondingFunction(ConsoleKey key) {
            KeyAssociation[key]();
        }

        private void AskUserForHealth() {
            bool continueFlag = true;
            DisplayUserDialog("   Please enter a value between 0 and 9999");
            Console.CursorVisible = true;
            do {
                ClearChoiceAndResetCursor();
                string choice = Console.ReadLine();
                try {
                    float convertedChoice = float.Parse(choice);
                    if (CheckStatInBound(convertedChoice)) {
                        Builder.SetHealth(convertedChoice);
                        continueFlag = false;
                    }
                } catch {
                    continueFlag = true;
                }
            } while (continueFlag);
            Console.CursorVisible = false;
        }

        private void AskUserForAgility() {
            bool continueFlag = true;
            DisplayUserDialog("   Please enter a value between 0 and 9999");
            Console.CursorVisible = true;
            do {
                ClearChoiceAndResetCursor();
                string choice = Console.ReadLine();
                try {
                    int convertedChoice = int.Parse(choice);
                    if (CheckStatInBound(convertedChoice)) {
                        Builder.SetAgility(convertedChoice);
                        continueFlag = false;
                    }
                } catch {
                    continueFlag = true;
                }
            } while (continueFlag);
            Console.CursorVisible = false;
        }

        private void AskUserForWeaponPower() {
            bool continueFlag = true;
            DisplayUserDialog("   Please enter a value between 0 and 9999");
            Console.CursorVisible = true;
            do {
                ClearChoiceAndResetCursor();
                string choice = Console.ReadLine();
                try {
                    float convertedChoice = float.Parse(choice);
                    if (CheckStatInBound(convertedChoice)) {
                        CreateAndEquipWeapon(convertedChoice);
                        continueFlag = false;
                    }
                } catch {
                    continueFlag = true;
                }
            } while (continueFlag);
            Console.CursorVisible = false;
        }

        private void CreateAndEquipWeapon(float power) {
            IWeapon weapon = new SimpleWeapon(power);
            Builder.GiveWeapon(weapon);
        }

        private bool CheckStatInBound(float stat) {
            return stat > CharacterConsts.MinStat && stat <= CharacterConsts.MaxStat;
        }

        private void ClearChoiceAndResetCursor() {
            GameDisplay.ClearRow(BuilderConsts.BuilderSecondDialofLine);
            Console.SetCursorPosition(3, BuilderConsts.BuilderSecondDialofLine);
        }

        private void FinishCreateCharacter() {
            IsBuilding = false;
        }

        private void AskIfNotFinished() {
            if (!IsCharacterFinished()) {
                DisplayUserDialog("   The character isn't properly created, abort creation ?");
                DisplayUserInfo("   y / N");
                IsBuilding = AskAbort();
            } else {
                FinishCreateCharacter();
            }
        }

        private bool AskAbort() {
            do {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.IsInList(BuilderConsts.AbortOptions)) {
                    return ContinueBuilding(keyInfo.Key);
                }
            } while (true);
        }

        private bool ContinueBuilding(ConsoleKey key) {
            return key == ConsoleKey.N;
        }

        private bool IsCharacterFinished() {
            return Builder.WeaponPower != null && Builder.GetCharacterStats().Health != 0f &&
                Builder.GetCharacterStats().Agility != 0;
        }
    }
}
