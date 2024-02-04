namespace Bingo.src
{
    public class BingoGame
    {
        private List<int> pickNumbers = new List<int>();
        public BingoCard BingoCard { get; set; }

        public List<string> GetLine()
        {
            var bingoLines = new List<string>();
            var bingoCardColumnMapper = new Dictionary<ColumnCategory, List<CardNumber>> 
            {
                { ColumnCategory.B, BingoCard.B },
                { ColumnCategory.I, BingoCard.I }
            };

            pickNumbers.ForEach(number =>
            {
                var column = GetColumnCategory(number);
                bingoCardColumnMapper[column].ForEach(cardNumber =>
                {
                    if (cardNumber.Number == number)
                    {
                        cardNumber.IsBingo = true;
                    }
                });
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

        internal void PickBall(int number)
        {
            pickNumbers.Add(number);
        }

        private ColumnCategory GetColumnCategory(int number)
        {
            if (number >= 16)
            {
                return ColumnCategory.I;
            }
            return ColumnCategory.B;
        }
    }
}