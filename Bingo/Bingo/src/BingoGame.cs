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

        internal void PickBall(int number)
        {
            pickNumbers.Add(number);
        }
    }
}