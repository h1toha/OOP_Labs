using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.GameAccounts;

namespace Lab3.Games
{
    public class TrainingGame : Game
    {
        public TrainingGame(GameAccount player1, GameAccount player2, GameType gameType, bool isWin) : base(player1, player2,gameType, 0, isWin)
        {
            gameType = GameType.TrainingGame;
        }
    }
}
