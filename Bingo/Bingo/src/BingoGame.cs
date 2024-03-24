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

            var player1LinesCount = GetLines(player1Info.IsBingo).Count;
            var player2LinesCount = GetLines(player2Info.IsBingo).Count;

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

            var index = 0;
            bingoCards.ForEach(bingoCard =>
            {
                result.Append($"{bingoCard.PlayerName}{GetLineCountMsg(bingoCard.IsBingo)}{GetLineDetail(GetLines(bingoCard.IsBingo))}");
                result.Append(index == 0 ? ", " : ".");
                index++;
            });

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

        private string GetLineCountMsg(bool[,] isBingo)
        {
            var lineCount = GetLines(isBingo).Count;
            var isPlural = lineCount > 1 ? "s" : string.Empty;
            return $" get {lineCount} line{isPlural}";
        }
        private string GetLineDetail(List<string> playerBingoLines)
        {
            return playerBingoLines.Count > 0
                ? $" ({string.Join(",", playerBingoLines)})"
                : string.Empty;
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
    }
}