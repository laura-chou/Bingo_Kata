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
            { "G", new Tuple<int, int>((int)Minimum.G, (int)Maximum.G) }
        };

        public int CreateRandomNumber(string columnName)
        {
            return _random.Next(_columnRange[columnName].Item1, _columnRange[columnName].Item1);
        }
    }
}