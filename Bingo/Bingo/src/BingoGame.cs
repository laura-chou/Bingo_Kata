namespace Bingo.src
{
    public class BingoGame
    {
        private List<int> pickNumbers = new List<int>();
        private List<BingoCard> bingoCards;

        public BingoGame(List<BingoCard> bingoCards)
        {
            this.bingoCards = bingoCards;
        }

        public string GameResult()
        {
            throw new NotImplementedException();
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