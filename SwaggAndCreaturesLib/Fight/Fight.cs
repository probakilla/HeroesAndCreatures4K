using SwaggAndCreaturesLib.User;
using System.Linq;

namespace SwaggAndCreaturesLib.Fight {
    public struct Fight {
        private const int LIMIT_INITIATIVE = 1000;

        private readonly IUser Computer;
        private readonly IUser Player;

        public Fight(IUser computer, IUser player) {
            Computer = computer;
            Player = player;
            DisplayCharacter();
        }

        public void DisplayCharacter() {
            for (int i = 0; i < Computer.Team.Count; ++i) {
                Computer.Team[i].DrawCharacter();
                Player.Team[i].DrawCharacter();
            }
        }

        public void StartFight() {
            while (!GameOver()) {
                NextTurn();
            }
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
    }
}