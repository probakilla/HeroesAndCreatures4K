using ConsoleDisplay.Extensions;
using ConsoleDisplay.Screens;
using HeroesAndCreatures.Characters.CharacterBuilder;
using System;
using System.Collections.Generic;

namespace HeroesAndCreatures.Team.TeamBuilder {
    public class TeamBuilderDisplay {
        private readonly ITeamBuilder Builder;
        private readonly Dictionary<ConsoleKey, Action> KeyAssociation;
        private bool IsBuilding = true;
        private readonly bool IsPlayerTeam;

        public TeamBuilderDisplay(bool isPlayerTeam) {
            IsPlayerTeam = isPlayerTeam;
            Builder = new CharacterTeamBuilder(isPlayerTeam);
            KeyAssociation = new Dictionary<ConsoleKey, Action> {
                { ConsoleKey.C, delegate() { CreateCharacter(); } },
                { ConsoleKey.F, delegate() { AskIfNotFinished(); } }
            };
        }

        public CharacterTeam TeamBuilderHome() {
            Console.Clear();
            do {
                DisplayTitle();
                DisplayTeamSummary();
                DisplayHomeText();
                AskUserOption();
            } while (IsBuilding);
            return Builder.GetTeam();
        }

        private void DisplayTitle() {
            if (IsPlayerTeam) {
                GameDisplay.WriteRow(TeamBuilderConsts.PlayerTitle, TeamBuilderConsts.TitleRow);
            } else {
                GameDisplay.WriteRow(TeamBuilderConsts.ComputerTitle, TeamBuilderConsts.TitleRow);
            }
        }

        private void DisplayTeamSummary() {
            string summary = Builder.GetSummary();
            GameDisplay.ClearAndDisplayRow(summary, TeamBuilderConsts.TeamSummaryRow);
        }

        private void DisplayHomeText() {
            GameDisplay.ClearAndDisplayRow(TeamBuilderConsts.QuestionString, TeamBuilderConsts.DialogRow);
            if (Builder.GetTeam().IsFull()) {
                GameDisplay.ClearAndDisplayRow(TeamBuilderConsts.EditCharacterString, TeamBuilderConsts.SecondDialogRow);
            } else {
                GameDisplay.ClearAndDisplayRow(TeamBuilderConsts.OptionsString, TeamBuilderConsts.SecondDialogRow);
            }
        }

        private void AskUserOption() {
            ConsoleKeyInfo keyInfo;
            do {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.IsInList(TeamBuilderConsts.BuilderOptions)) {
                    break;
                }
            } while (true);
            CallCorrepondingFunction(keyInfo.Key);
        }

        private void CallCorrepondingFunction(ConsoleKey key) {
            KeyAssociation[key]();
        }

        private void CreateCharacter() {
            if (!Builder.GetTeam().IsFull()) {
                AddNewCharacter();
            } else {
                AskWhichEdit();
            }
        }

        private void AddNewCharacter() {
            CharacterBuilderDisplay builder = new CharacterBuilderDisplay();
            Builder.AddCharacter(builder.CharacterBuilderHome());
            Console.Clear();
        }

        private void AskWhichEdit() {
            do {
                int place = AskUserTeamPlace();
                if (Builder.GetTeam().IsInTeamRange(place)) {
                    EditCharacter(place);
                    break;
                }
            } while (true);
        }

        private int AskUserTeamPlace() {
            DisplayPlaceQuestion();
            do {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.IsInList(TeamBuilderConsts.TeamPlaces)) {
                    return keyInfo.GetKeyInt();
                }
            } while (true);
        }

        private void DisplayPlaceQuestion() {
            GameDisplay.ClearAndDisplayRow(TeamBuilderConsts.PlaceSelectText, TeamBuilderConsts.DialogRow);
            GameDisplay.ClearAndDisplayRow(TeamBuilderConsts.AvailablePlaces, TeamBuilderConsts.SecondDialogRow);
        }

        private void EditCharacter(int place) {
            CharacterBuilderDisplay builder = new CharacterBuilderDisplay(Builder.GetTeam().Team[place]);
            Builder.ReplaceCharacter(builder.CharacterBuilderHome(), place);
            Console.Clear();
        }

        private void AskIfNotFinished() {
            if (!IsTeamFinished()) {
                DisplayAbortText();
                IsBuilding = AskAbort();
            } else {
                FinishEditTeam();
            }
        }

        private void DisplayAbortText() {
            GameDisplay.ClearAndDisplayRow(TeamBuilderConsts.NotFinisedString, TeamBuilderConsts.DialogRow);
            GameDisplay.ClearAndDisplayRow(CharacterBuilderConsts.YesNoString, TeamBuilderConsts.SecondDialogRow);
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

        private bool IsTeamFinished() {
            return Builder.GetTeam().IsFull();
        }

        private void FinishEditTeam() {
            IsBuilding = false;
        }
    }
}
