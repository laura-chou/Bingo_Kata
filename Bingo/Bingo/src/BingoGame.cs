using System.Text;

namespace Bingo.src
{
    public class BingoGame
    {
        private List<BingoCard> bingoCards;
        private List<int> pickNumbers = new List<int>();
        public BingoGame(List<BingoCard> bingoCards)
        {
            this.bingoCards = bingoCards;
        }

        public string GameResult()
        {
            var result = new StringBuilder();

            var player1Info = bingoCards[0];
            var player2Info = bingoCards[1];

            var player1BingoLines = GetLines(player1Info.IsBingo);
            var player2BingoLines = GetLines(player2Info.IsBingo);

            var player1LinesCount = player1BingoLines.Count;
            var player2LinesCount = player2BingoLines.Count;

            if (player1LinesCount == player2LinesCount)
            {
                result.Append("no winner. ");
            }
            else
            {
                var winner = player1LinesCount > player2LinesCount
                    ? player1Info.PlayerName
                    : player2Info.PlayerName;

                result.Append(winner + " wins. ");
            }

            result.Append($"{player1Info.PlayerName}{GetLineCountMsg(player1LinesCount)}{GetPlayerLineDetail(player1BingoLines)}, ");
            result.Append($"{player2Info.PlayerName}{GetLineCountMsg(player2LinesCount)}{GetPlayerLineDetail(player2BingoLines)}.");

            return result.ToString();
        }

        public void PickBall()
        {
            var random = new Random();
            var number = random.Next(1, 75);
            if (!pickNumbers.Contains(number))
            {
                pickNumbers.Add(number);
            }
        }

        internal void PickBall(int number)
        {
            pickNumbers.Add(number);
            pickNumbers.ForEach(number =>
            {
                var player1Card = bingoCards[0].Card;
                var player2Card = bingoCards[1].Card;

                var totalColumns = player1Card.GetLength(0);
                var totalRows = player1Card.GetLength(1);

                for (int row = 0; row < totalRows; row++)
                {
                    for (int col = 0; col < totalColumns; col++)
                    {
                        if (player1Card[row, col] == number || player1Card[row, col] == 0)
                        {
                            bingoCards[0].IsBingo[row, col] = true;
                        }
                        if (player2Card[row, col] == number || player2Card[row, col] == 0)
                        {
                            bingoCards[1].IsBingo[row, col] = true;
                        }
                    }
                }
            });
        }

        private string GetLineCountMsg(int playerLinesCount)
        {
            var isPlural = playerLinesCount > 1 ? "s" : string.Empty;
            return $" get {playerLinesCount} line{isPlural}";
        }
        private List<string> GetLines(bool[,] isBingo)
        {
            var bingoLines = new List<string>();

            for (int col = 0; col < 5; col++)
            {
                if (isBingo[0, col] &&
                    isBingo[1, col] &&
                    isBingo[2, col] &&
                    isBingo[3, col] &&
                    isBingo[4, col])
                {
                    bingoLines.Add("V" + (col + 1));
                }
            }

            return bingoLines;
        }

        private string GetPlayerLineDetail(List<string> playerBingoLines)
        {
            return playerBingoLines.Count > 0
                ? $" ({string.Join(",", playerBingoLines)})"
                : string.Empty;
        }
    }
}