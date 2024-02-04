namespace Bingo.src
{
    public class BingoGame
    {
        private List<int> pickNumbers = new List<int>();
        public BingoCard BingoCard { get; set; }

        public List<string> GetLine()
        {
            var bingoLines = new List<string>();
            pickNumbers.ForEach(number =>
            {
                var column = GetColumnCategory(number);
                if (column == ColumnCategory.B)
                {
                    BingoCard.B.ForEach(cardNumber =>
                    {
                        if (cardNumber.Number == number)
                        {
                            cardNumber.IsBingo = true;
                        }
                    });
                }
                if (column == ColumnCategory.I)
                {
                    BingoCard.I.ForEach(cardNumber =>
                    {
                        if (cardNumber.Number == number)
                        {
                            cardNumber.IsBingo = true;
                        }
                    });
                }
            });
            if (BingoCard.B.Count(number => number.IsBingo) == 5)
            {
                bingoLines.Add("V1");
            }
            if (BingoCard.I.Count(number => number.IsBingo) == 5)
            {
                bingoLines.Add("V2");
            }
            return bingoLines;
        }

        private ColumnCategory GetColumnCategory(int number)
        {
            if (number >= 16)
            {
                return ColumnCategory.I;
            }
            return ColumnCategory.B;
        }

        internal void PickBall(int number)
        {
            pickNumbers.Add(number);
        }
    }
}