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
            return "no winner. player A get 0 line, player B get 0 line.";
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