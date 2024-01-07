namespace Bingo.src
{
    public class BingoLine
    {
        public int GetBingoLine(BingoCard bingoCard, List<string> bingoNumber)
        {
            var verticalLineList = new List<string>
            {
                "B" + bingoCard.B.Column1.ToString(),
                "B" + bingoCard.B.Column2.ToString(),
                "B" + bingoCard.B.Column3.ToString(),
                "B" + bingoCard.B.Column4.ToString(),
                "B" + bingoCard.B.Column5.ToString(),
            };
            if (bingoNumber.SequenceEqual(verticalLineList))
            {
                return 1;
            }
            return 0;
        }
    }
}