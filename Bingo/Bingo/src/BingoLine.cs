using System.Collections.Generic;
using System.Linq;

namespace Bingo.src
{
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class BingoLine
    {
        private List<Line> BingLineList { get; set; }
        public int GetBingoLine(BingoCard bingoCard, List<string> bingoNumber)
        {
            BingLineList = new List<Line>
            {
                new Line
                { 
                    LineList = new List<CheckBingoNumber> 
                    {
                        new CheckBingoNumber { BingoNumber = "B" + bingoCard.B.Column1.ToString(), IsBingo = false },
                        new CheckBingoNumber { BingoNumber = "B" + bingoCard.B.Column2.ToString(), IsBingo = false },
                        new CheckBingoNumber { BingoNumber = "B" + bingoCard.B.Column3.ToString(), IsBingo = false },
                        new CheckBingoNumber { BingoNumber = "B" + bingoCard.B.Column4.ToString(), IsBingo = false },
                        new CheckBingoNumber { BingoNumber = "B" + bingoCard.B.Column5.ToString(), IsBingo = false }
                    }
                },
            };
            BingLineList.ForEach(number =>
            {
                number.LineList.ForEach((line) =>
                {
                    if (bingoNumber.Contains(line.BingoNumber))
                    {
                        line.IsBingo = true;
                    }
                });
            });
            
            var checkBingoLine = BingLineList
                .Select(list => list.LineList
                .Count(line => line.IsBingo == true) == list.LineList.Count)
                .ToList();

            return checkBingoLine.Count(line => line == true);
        }
    }
}