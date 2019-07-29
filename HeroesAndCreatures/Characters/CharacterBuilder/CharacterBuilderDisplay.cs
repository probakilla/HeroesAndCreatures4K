using ConsoleDisplay.Extensions;
using ConsoleDisplay.Screens;
using HeroesAndCreatures.Weapons;
using System;
using System.Collections.Generic;

namespace HeroesAndCreatures.Characters.CharacterBuilder {
    public class CharacterBuilderDisplay {
        private readonly ICharacterBuilder Builder;
        private Dictionary<ConsoleKey, Action> KeyAssociation;
        private bool IsBuilding = true;
        private readonly Random Rand = new Random();

        public CharacterBuilderDisplay() {
            Builder = new HumanBuilder();
            InitKeyAssociations();
        }

        public CharacterBuilderDisplay(AbstractCharacter character) {
            Builder = new HumanBuilder(character);
            InitKeyAssociations();
        }

        private void InitKeyAssociations() {
            KeyAssociation = new Dictionary<ConsoleKey, Action> {
                { ConsoleKey.A, delegate() { AskUserForAgility(); } },
                { ConsoleKey.H, delegate() { AskUserForHealth(); } },
                { ConsoleKey.W, delegate() { AskUserForWeaponPower(); } },
                { ConsoleKey.R, delegate() { CreateRandomCharacter(); } },
                { ConsoleKey.F, delegate() { AskIfNotFinished(); } }
            };
        }

        public AbstractCharacter CharacterBuilderHome() {
            Console.Clear();
            do {
                GameDisplay.WriteRow(CharacterBuilderConsts.Title, CharacterBuilderConsts.TitleRow);
                DisplayCharacterStatistics();
                DisplayUserText();
                AskUserForKey();
            } while (IsBuilding);
            return Builder.GetCharacter();
        }

        private void DisplayCharacterStatistics() {
            DisplayCharacterHealth();
            DisplayCharacterAgility();
            DisplayCharacterWeapon();
        }

        private void DisplayUserText() {
            DisplayUserDialog(CharacterBuilderConsts.QuestionString);
            DisplayUserInfo(CharacterBuilderConsts.OptionsString);
        }

        private void DisplayCharacterHealth() {
            string health = GetHealthString();
            GameDisplay.ClearAndDisplayRow(health, CharacterBuilderConsts.HealthRow);
        }

        private string GetHealthString() {
            try {
                CharacterStats stats = Builder.GetCharacterStats();
                int health = Convert.ToInt32(stats.Health);
                return $"   Health: {health.ToString()}";
            } catch {
                return CharacterBuilderConsts.NotAllocated;
            }
        }

        private void DisplayCharacterAgility() {
            string agility = GetAgilityString();
            GameDisplay.ClearAndDisplayRow(agility, CharacterBuilderConsts.AgilityRow);
        }

        private string GetAgilityString() {
            try {
                CharacterStats stats = Builder.GetCharacterStats();
                return $"   Agility: {stats.Agility.ToString()}";
            } catch {
                return CharacterBuilderConsts.NotAllocated;
            }
        }

        private void DisplayCharacterWeapon() {
            string power = GetWeaponString();
            GameDisplay.ClearAndDisplayRow(power, CharacterBuilderConsts.WeaponRow);
        }

        private string GetWeaponString() {
            float? power = Builder.WeaponPower;
            if (power.HasValue) {
                int powerConverted = Convert.ToInt32(power);
                return $"   Weapon power: {powerConverted.ToString()}";
            }
            return CharacterBuilderConsts.NotAllocated;
        }

        private void DisplayUserDialog(string message) {
            GameDisplay.ClearAndDisplayRow(message, CharacterBuilderConsts.DialogRow);
        }

        private void DisplayUserInfo(string message) {
            GameDisplay.ClearAndDisplayRow(message, CharacterBuilderConsts.SecongDialogRow);
        }

        private void AskUserForKey() {
            bool continueFlag = true;
            ConsoleKeyInfo keyInfo;
            do {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.IsInList(CharacterBuilderConsts.BuilderOptions)) {
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
            DisplayUserDialog($"{CharacterBuilderConsts.ValuesLimitString} (Health)");
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
            DisplayUserDialog($"{CharacterBuilderConsts.ValuesLimitString} (Agility)");
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
            DisplayUserDialog($"{CharacterBuilderConsts.ValuesLimitString} (Weapon power)");
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
            GameDisplay.ClearRow(CharacterBuilderConsts.SecongDialogRow);
            Console.SetCursorPosition(3, CharacterBuilderConsts.SecongDialogRow);
        }

        private void FinishCreateCharacter() {
            IsBuilding = false;
        }

        private void AskIfNotFinished() {
            if (!IsCharacterFinished()) {
                DisplayAbortText();
                IsBuilding = AskAbort();
            } else {
                FinishCreateCharacter();
            }
        }

        private void DisplayAbortText() {
            DisplayUserDialog(CharacterBuilderConsts.AbortWarningString);
            DisplayUserInfo(CharacterBuilderConsts.YesNoString);
        }

        private bool AskAbort() {
            do {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.IsInList(CharacterBuilderConsts.AbortOptions)) {
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

        private void CreateRandomCharacter() {
            Builder.SetAgility(RandomInt());
            Builder.SetHealth(RandomFloat());
            IWeapon weapon = new SimpleWeapon(RandomFloat());
            Builder.GiveWeapon(weapon);
            IsBuilding = false;
        }

        private int RandomInt() {
            return Rand.Next(CharacterBuilderConsts.MinStat, CharacterBuilderConsts.MaxStat);
        }

        private float RandomFloat() {
            double next = Rand.NextDouble();
            return (float)(CharacterBuilderConsts.MinStat +
                (next * (CharacterBuilderConsts.MaxStat - CharacterBuilderConsts.MinStat)));
        }
    }
}
