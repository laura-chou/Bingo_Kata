namespace Bingo.src
{
    internal class HorizontalLine
    {
        private readonly bool[,] _isBingo;

        public HorizontalLine(bool[,] isBingo)
        {
            _isBingo = isBingo;
        }

        public List<string> GetBingoLine()
        {
            var bingoLines = new List<string>();

            for (int row = 0; row < _isBingo.GetLength(0); row++)
            {
                if (_isBingo[row, 0] &&
                    _isBingo[row, 1] &&
                    _isBingo[row, 2] &&
                    _isBingo[row, 3] &&
                    _isBingo[row, 4])
                {
                    bingoLines.Add("H" + (row + 1));
                }
            }

            return bingoLines;
        }
    }
}