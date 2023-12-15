using System;

namespace Bingo.src
{
    public class BingoNumber
    {
        public int CreateBRandomNumber()
        {
            var random = new Random();
            return random.Next(1, 15);
        }
    }
}