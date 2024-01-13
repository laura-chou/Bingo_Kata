using FluentAssertions;
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
            BingLineList = GenerateLineList(bingoCard);

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

        private List<Line> GenerateLineList(BingoCard bingoCard)
        {
            return new List<Line>
            {
                new Line
                {
                    LineList = new List<CheckBingoNumber>
                    {
                        new CheckBingoNumber { BingoNumber = "B" + bingoCard.B.Column1.ToString() },
                        new CheckBingoNumber { BingoNumber = "B" + bingoCard.B.Column2.ToString() },
                        new CheckBingoNumber { BingoNumber = "B" + bingoCard.B.Column3.ToString() },
                        new CheckBingoNumber { BingoNumber = "B" + bingoCard.B.Column4.ToString() },
                        new CheckBingoNumber { BingoNumber = "B" + bingoCard.B.Column5.ToString() }
                    }
                },
                new Line
                {
                    LineList = new List<CheckBingoNumber>
                    {
                        new CheckBingoNumber { BingoNumber = "I" + bingoCard.I.Column1.ToString() },
                        new CheckBingoNumber { BingoNumber = "I" + bingoCard.I.Column2.ToString() },
                        new CheckBingoNumber { BingoNumber = "I" + bingoCard.I.Column3.ToString() },
                        new CheckBingoNumber { BingoNumber = "I" + bingoCard.I.Column4.ToString() },
                        new CheckBingoNumber { BingoNumber = "I" + bingoCard.I.Column5.ToString() }
                    }
                }
            };
        }
    }
}