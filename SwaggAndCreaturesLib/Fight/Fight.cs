using SwaggAndCreaturesLib.User;
using System;
using System.Linq;

namespace SwaggAndCreaturesLib.Fight {
    public struct Fight {
        private const int LIMIT_INITIATIVE = 1000;

        private readonly IUser Computer;
        private readonly IUser Player;

        public Fight(IUser computer, IUser player) {
            Computer = computer;
            Player = player;
        }

        private void DisplayCharacter() {
            for (int i = 0; i < Computer.Team.Count; ++i) {
                Computer.Team[i].Display();
                Player.Team[i].Display();
            }
        }

        public bool StartFight() {
            Console.CursorVisible = false;
            DisplayCharacter();
            while (!GameOver()) {
                NextTurn();
            }
            return YouWon();
        }

        private void NextTurn() {
            while (!AtLeastOneCanPlay()) {
                IncreaseAllInitiative();
            }
            NextToPlay();
        }

        private void IncreaseAllInitiative() {
            Computer.IncreaseAllInitiative();
            Player.IncreaseAllInitiative();
        }

        private bool AtLeastOneCanPlay() {
            int computerCharInit = Computer.GetNextToAttack().Initiative;
            int playerCharInit = Player.GetNextToAttack().Initiative;
            return computerCharInit >= LIMIT_INITIATIVE || playerCharInit >= LIMIT_INITIATIVE;
        }

        private void NextToPlay() {
            int computerCharInit = Computer.GetNextToAttack().Initiative;
            int playerCharInit = Player.GetNextToAttack().Initiative;
            if (computerCharInit > playerCharInit) {
                Computer.Play(Player.Team);
            } else {
                Player.Play(Computer.Team);
            }
        }

        private bool GameOver() {
            int playerCount = Player.Team.Where(character => !character.IsDead()).ToList().Count;
            int computerCount = Computer.Team.Where(character => !character.IsDead()).ToList().Count;
            return playerCount == 0 || computerCount == 0;
        }

        private bool YouWon() {
            int playerCount = Player.Team.Where(character => !character.IsDead()).ToList().Count;
            return playerCount != 0;
        }
    }
}