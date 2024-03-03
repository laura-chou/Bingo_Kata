namespace Bingo.src
{
    public class HorizontalLine : LineBase
    {
        public HorizontalLine(bool[,] isBingo)
        {
            IsBingo = isBingo;
        }

        public override List<string> GetBingoLine()
        {
            var bingoLines = new List<string>();

            for (int row = 0; row < TotalRow; row++)
            {
                if (IsBingo[row, 0] &&
                    IsBingo[row, 1] &&
                    IsBingo[row, 2] &&
                    IsBingo[row, 3] &&
                    IsBingo[row, 4])
                {
                    bingoLines.Add("H" + (row + 1));
                }
            }

            return bingoLines;
        }
    }
}