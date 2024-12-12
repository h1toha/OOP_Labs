using Lab3.GameAccounts;

namespace Lab3.Games
{
    public enum GameType
    {
        StandardGame,
        TrainingGame,
        OnePlayerGame
    }
    public abstract class Game
    {
        private static int _id = 0;
        public int Id { get; }
        public GameAccount Player1 { get; }
        public GameAccount Player2 { get; }
        public bool IsPlayer1Win { get; }
        public int Rating { get; }
        public GameType Type { get; }

        public Game(GameAccount player1, GameAccount player2, GameType gameType, int rating, bool isPlayer1Win)
        {
            Id = ++_id;
            Player1 = player1;
            Player2 = player2;
            Type = gameType;
            Rating = rating;
            IsPlayer1Win = isPlayer1Win;
        }

        public int CalculateRating()
        {
            return Rating;
        }
        public virtual void ProcessGame()
        {
            if (IsPlayer1Win)
            {
                Player1.WinGame(this);
                Player2.LoseGame(this);
            }
            else
            {
                Player1.LoseGame(this);
                Player2.WinGame(this);
            }
        }
    }
}
