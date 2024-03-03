namespace Bingo.src
{
    public class BingoGame
    {
        private readonly BingoCard _bingoCard;
        private readonly List<int> _pickNumbers;
        private readonly int _totalColumns;
        private readonly int _totalRows;
        public BingoGame(BingoCard bingoCard)
        {
            _bingoCard = bingoCard;
            _totalRows = bingoCard.Card.GetLength(0);
            _totalColumns = bingoCard.Card.GetLength(1);
            _pickNumbers = new List<int>();
        }

        public List<string> GetLine()
        {
            var bingoLines = new List<string>();
            var isBingo = _bingoCard.IsBingo;
          
            // 檢查直線
            var vl = new VerticalLine(isBingo);
            bingoLines.AddRange(vl.GetBingoLine());

            // 檢查橫線
            var hl = new HorizontalLine(isBingo);
            bingoLines.AddRange(hl.GetBingoLine());

            // 檢查對角線
            var dl = new DiagonalLine(isBingo);
            bingoLines.AddRange(dl.GetBingoLine());

            return bingoLines;
        }

        public void PickBall()
        {
            var random = new Random();
            var number = random.Next(1, 75);
            if (!_pickNumbers.Contains(number))
            {
                _pickNumbers.Add(number);
            }
        }

        internal void PickBall(int number)
        {
            _pickNumbers.Add(number);
            _pickNumbers.ForEach(number =>
            {
                for (int row = 0; row < _totalRows; row++)
                {
                    for (int col = 0; col < _totalColumns; col++)
                    {
                        if (_bingoCard.Card[row, col] == number)
                        {
                            _bingoCard.IsBingo[row, col] = true;
                        }
                    }
                }
            });

            _bingoCard.IsBingo[_totalRows / 2, _totalColumns / 2] = true;
        }
    }
}