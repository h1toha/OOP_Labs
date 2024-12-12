using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.GameAccounts;

namespace Lab3.Games
{
    public class StandardGame : Game
    {
        public StandardGame(GameAccount player1, GameAccount player2, GameType gameType, int rating, bool isWin) : base(player1, player2, gameType, rating, isWin)
        {
            gameType = GameType.StandardGame;
        }
    }
}
