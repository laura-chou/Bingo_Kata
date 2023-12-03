namespace Bingo.src
{
    public class BingoCard
    {
        private Random _random = new Random();

        public Column CreateColumnB()
        {
            var randomNumberList = Enumerable.Range(1, 15)
                .OrderBy(x => _random.Next())
                .Take(5)
                .ToList();

            return GetColumn(randomNumberList);
        }

        public Column CreateColumnI()
        {
            var randomNumberList = Enumerable.Range(16, 15)
                .OrderBy(x => _random.Next())
                .Take(5)
                .ToList();

            return GetColumn(randomNumberList);
        }

        public SpecialColumn CreateColumnN()
        {
            var randomNumberList = Enumerable.Range(31, 15)
                .OrderBy(x => _random.Next())
                .Take(4)
                .ToList();

            return GetSpecialColumn(randomNumberList);
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

        private Column GetColumn(List<int> randomNumberList)
        {
            return new Column
            {
                Column1 = randomNumberList[0],
                Column2 = randomNumberList[1],
                Column3 = randomNumberList[2],
                Column4 = randomNumberList[3],
                Column5 = randomNumberList[4]
            };
        }
    }
}