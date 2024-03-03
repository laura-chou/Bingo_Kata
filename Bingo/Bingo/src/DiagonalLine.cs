namespace Bingo.src
{
    public class DiagonalLine : LineBase
    {
        public DiagonalLine(bool[,] isBingo)
        {
            IsBingo = isBingo;
        }

        public override List<string> GetBingoLine()
        {
            var bingoLines = new List<string>();
            var countD1 = 0;
            var countD2 = 0;
            
            for (int col = 0; col < TotalColumn; col++)
            {
                for (int row = 0; row < TotalRow; row++)
                {
                    if (IsBingo[row, col])
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