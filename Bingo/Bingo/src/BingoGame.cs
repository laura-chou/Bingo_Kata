namespace Bingo.src
{
    public class BingoGame
    {
        private List<int> pickNumbers = new List<int>();
        public BingoCard BingoCard { get; set; }

        public List<string> GetLine()
        {
            return new List<string> { "V1" };
        }

        internal void PickBall(int number)
        {
            pickNumbers.Add(number);
        }
    }
}