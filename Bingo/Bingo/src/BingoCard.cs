namespace Bingo.src
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class BingoCard
    {
        private Random _random = new Random();
        public NormalColumn B { get; set; }
        public NormalColumn G { get; set; }
        public NormalColumn I { get; set; }
        public SpecialColumn N { get; set; }
        public NormalColumn O { get; set; }

        public BingoCard CreateBingoCard()
        {
            return new BingoCard
            {
                B = (NormalColumn)CreateColumn("B"),
                I = (NormalColumn)CreateColumn("I"),
                N = (SpecialColumn)CreateColumn("N"),
                G = (NormalColumn)CreateColumn("G"),
                O = (NormalColumn)CreateColumn("O"),
            };
        }

        public IColumn CreateColumn(string columnName)
        {
            var minNumberMapper = new Dictionary<string, int>
            {
                { "B", (int)Minimum.B },
                { "I", (int)Minimum.I },
                { "N", (int)Minimum.N },
                { "G", (int)Minimum.G },
                { "O", (int)Minimum.O }
            };

            var randomNumberList = Enumerable.Range(minNumberMapper[columnName], 15)
                .OrderBy(x => _random.Next())
                .Take(IsSpecialColumn(columnName) ? 4 : 5)
                .ToList();

            if (IsSpecialColumn(columnName))
            {
                return GetSpecialColumn(randomNumberList);
            }

            return GetColumn(randomNumberList);
        }

        private IColumn GetColumn(List<int> randomNumberList)
        {
            return new NormalColumn
            {
                Column1 = randomNumberList[0],
                Column2 = randomNumberList[1],
                Column3 = randomNumberList[2],
                Column4 = randomNumberList[3],
                Column5 = randomNumberList[4]
            };
        }

        private SpecialColumn GetSpecialColumn(List<int> randomNumberList)
        {
            return new SpecialColumn
            {
                Column1 = randomNumberList[0],
                Column2 = randomNumberList[1],
                Column4 = randomNumberList[2],
                Column5 = randomNumberList[3]
            };
        }

        private bool IsSpecialColumn(string columnName)
        {
            return columnName == "N";
        }
    }
}