using SwaggAndCreaturesLib.User;
using System;
using System.Linq;

namespace SwaggAndCreaturesLib.Fight {
    public struct Fight {
        private readonly IUserImpl Computer;
        private readonly IUserImpl Player;

        public Fight(IUserImpl computer, IUserImpl player) {
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
            return computerCharInit >= FightConsts.InitiativeLimit || playerCharInit >= FightConsts.InitiativeLimit;
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
            return playerCount == FightConsts.NoCharacterLeft || computerCount == FightConsts.NoCharacterLeft;
        }

        private bool YouWon() {
            int playerCount = Player.Team.Where(character => !character.IsDead()).ToList().Count;
            return playerCount != FightConsts.NoCharacterLeft;
        }
    }
}