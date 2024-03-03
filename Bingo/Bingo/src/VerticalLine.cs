namespace Bingo.src
{
    public class VerticalLine : LineBase
    {
        public VerticalLine(bool[,] isBingoArray)
        {
            IsBingo = isBingoArray;
        }

        public override List<string> GetBingoLine()
        {
            var bingoLines = new List<string>();

            for (int col = 0; col < TotalColumn; col++)
            {
                if (IsBingo[0, col] &&
                    IsBingo[1, col] &&
                    IsBingo[2, col] &&
                    IsBingo[3, col] &&
                    IsBingo[4, col])
                {
                    bingoLines.Add("V" + (col + 1));
                }
            }

            return bingoLines;
        }
    }
}