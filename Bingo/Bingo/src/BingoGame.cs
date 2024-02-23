namespace Bingo.src
{
    public class BingoGame
    {
        private List<int> pickNumbers = new List<int>();

        public BingoCard BingoCard { get; set; }

        public List<string> GetLine()
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