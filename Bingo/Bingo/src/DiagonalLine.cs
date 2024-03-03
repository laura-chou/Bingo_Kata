namespace Bingo.src
{
    public class DiagonalLine
    {
        private readonly bool[,] _isBingo;

        public DiagonalLine(bool[,] isBingo)
        {
            this._isBingo = isBingo;
        }

        public List<string> GetBingoLine()
        {
            var bingoLines = new List<string>();
            var countD1 = 0;
            var countD2 = 0;
            
            for (int col = 0; col < _isBingo.GetLength(1); col++)
            {
                for (int row = 0; row < _isBingo.GetLength(0); row++)
                {
                    if (_isBingo[row, col])
                    {
                        if (col == row)
                        {
                            countD1++;
                        }

                        if (col + row == 4)
                        {
                            countD2++;
                        }
                    }
                }
            }

            if (countD1 == 5)
            {
                bingoLines.Add("D1");
            }

            if (countD2 == 5)
            {
                bingoLines.Add("D2");
            }

            return bingoLines;
        }
    }
}