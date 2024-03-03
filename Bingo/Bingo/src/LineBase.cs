using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.src
{
    public abstract class LineBase
    {
        internal bool[,] IsBingo { get; set; }
        internal int TotalRow => IsBingo.GetLength(0);
        internal int TotalColumn => IsBingo.GetLength(1);
        public abstract List<string> GetBingoLine();
    }
}
