using System;

namespace Bingo.src
{
    public class BingoNumber
    {
        private Random _random = new Random();

        public int CreateBRandomNumber()
        {
            return _random.Next((int)Minimum.B, (int)Maximum.B);
        }

        public int CreateIRandomNumber()
        {
            return _random.Next((int)Minimum.C, (int)Maximum.C);
        }
    }
}