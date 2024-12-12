using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Lab3.GameAccounts;

namespace Lab3.Games
{
    public class OnePlayerGame : Game
    {
        public OnePlayerGame(GameAccount player1, GameType gameType, int rating, bool isWin) : base(player1,null, gameType, rating, isWin)
        {
            gameType = GameType.OnePlayerGame;
        }

        public override void ProcessGame()
        {
            if (IsPlayer1Win)
            {
                Player1.WinGame(this);
            }
            else
            {
                Player1.LoseGame(this);
            }
        }
    }
}
