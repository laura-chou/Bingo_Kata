namespace Bingo.src
{
    public class BingoGame
    {
        private List<int> pickNumbers = new List<int>();

        public BingoCard BingoCard = new BingoCard();

        public List<string> GetLine()
        {
            return new List<string> { "V1" };
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
                int totalColumns = BingoCard.Card.GetLength(0);
                int totalRows = BingoCard.Card.GetLength(1);

                for (int row = 0; row < totalRows; row++)
                {
                    for (int col = 0; col < totalColumns; col++)
                    {
                        if (BingoCard.Card[row, col] == number)
                        {
                            BingoCard.IsBingo[row, col] = true;
                        }
                    }
                }
            });
        }
    }
}