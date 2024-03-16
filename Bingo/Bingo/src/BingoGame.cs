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

            var player1Name = bingoCards[0].PlayerName;
            var player2Name = bingoCards[1].PlayerName;
            
            bingoCards[0].BingoLines = new List<string>();
            bingoCards[1].BingoLines = new List<string>();
            
            var player1BingoLines = bingoCards[0].BingoLines;
            var player2BingoLines = bingoCards[1].BingoLines;

            if (player1BingoLines.Count == player2BingoLines.Count)
            {
                result.Append("no winner. ");
            }

            result.Append($"{player1Name} get {player1BingoLines.Count} line, ");
            result.Append($"{player2Name} get {player2BingoLines.Count} line.");

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
        }
    }
}