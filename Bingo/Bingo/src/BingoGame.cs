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
            for (int col = 0; col < _totalColumns; col++)
            {
                if (isBingo[0, col] &&
                    isBingo[1, col] &&
                    isBingo[2, col] &&
                    isBingo[3, col] &&
                    isBingo[4, col])
                {
                    bingoLines.Add("V" + (col + 1));
                }
            }

            // 檢查橫線
            for (int row = 0; row < _totalRows; row++)
            {
                if (isBingo[row, 0] &&
                    isBingo[row, 1] &&
                    isBingo[row, 2] &&
                    isBingo[row, 3] &&
                    isBingo[row, 4])
                {
                    bingoLines.Add("H" + (row + 1));
                }
            }

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