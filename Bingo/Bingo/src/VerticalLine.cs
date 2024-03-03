namespace Bingo.src
{
    public class VerticalLine
    {
        private readonly bool[,] _isBingo;
        
        public VerticalLine(bool[,] isBingoArray)
        {
            _isBingo = isBingoArray;
        }

        public List<string> GetBingoLine()
        {
            var bingoLines = new List<string>();

            for (int col = 0; col < _isBingo.GetLength(1); col++)
            {
                if (_isBingo[0, col] &&
                    _isBingo[1, col] &&
                    _isBingo[2, col] &&
                    _isBingo[3, col] &&
                    _isBingo[4, col])
                {
                    bingoLines.Add("V" + (col + 1));
                }
            }

            return bingoLines;
        }
    }
}