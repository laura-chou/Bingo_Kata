namespace Bingo.src
{
    public class BingoCard
    {
        public Column CreateColumnB()
        {
            Random random = new Random();
            var randomNumberList = Enumerable.Range(1, 15)
                .OrderBy(x => random.Next())
                .Take(5)
                .ToList();

            return new Column
            {
                Column1 = randomNumberList[0],
                Column2 = randomNumberList[1],
                Column3 = randomNumberList[2],
                Column4 = randomNumberList[3],
                Column5 = randomNumberList[4]
            };
        }
        public Column CreateColumnI()
        {
            Random random = new Random();
            var randomNumberList = Enumerable.Range(16, 15)
                .OrderBy(x => random.Next())
                .Take(5)
                .ToList();

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