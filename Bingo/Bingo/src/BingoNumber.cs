using System;

namespace Bingo.src
{
    public class BingoNumber
    {
        private readonly Random _random = new();
        private readonly Dictionary<string, Tuple<int, int>> _columnRange = new Dictionary<string, Tuple<int, int>>
        {
            { "B", new Tuple<int, int>((int)Minimum.B, (int)Maximum.B) },
            { "I", new Tuple<int, int>((int)Minimum.I, (int)Maximum.I) },
            { "N", new Tuple<int, int>((int)Minimum.N, (int)Maximum.N) },
            { "G", new Tuple<int, int>((int)Minimum.G, (int)Maximum.G) },
            { "O", new Tuple<int, int>((int)Minimum.O, (int)Maximum.O) }
        };

        public int CreateRandomNumber(string columnName)
        {
            return _random.Next(_columnRange[columnName].Item1, _columnRange[columnName].Item2);
        }

        public List<string> GetBingoNumber()
        {
            var columnNameList = new List<string> { "B", "I", "N", "G", "O" };
            var bingoNumber = new List<string>();
            while (bingoNumber.Count != 5)
            {
                var index = _random.Next(0, columnNameList.Count);
                var number = CreateRandomNumber(columnNameList[index]);
                var bingoNumberName = columnNameList[index] + number;
                if (!bingoNumber.Contains(bingoNumberName))
                {
                    bingoNumber.Add(bingoNumberName);
                }
            }
            return bingoNumber;
        }
    }
}