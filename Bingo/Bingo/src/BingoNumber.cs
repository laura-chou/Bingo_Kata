using System;

namespace Bingo.src
{
    public class BingoNumber
    {
        private Random _random = new Random();

        public int CreateBRandomNumber()
        {
            return _random.Next(1, 15);
        }
    }
}