using Bingo.src;
using FluentAssertions;
using NUnit.Framework;

namespace Bingo
{
    [TestFixture]
    public class BingoCardTest
    {
        [Test]
        public void A01_CreateColumnB()
        {
            var bingoCard = new BingoCard();
            var actual = bingoCard.CreateColumnB();
            var expected = new Column
            {
                Column1 = ValidateColumnBNumber(actual.Column1) ? actual.Column1 : 0,
                Column2 = ValidateColumnBNumber(actual.Column2) ? actual.Column2 : 0,
                Column3 = ValidateColumnBNumber(actual.Column3) ? actual.Column3 : 0,
                Column4 = ValidateColumnBNumber(actual.Column4) ? actual.Column4 : 0,
                Column5 = ValidateColumnBNumber(actual.Column5) ? actual.Column5 : 0
            };
            actual.Should().BeEquivalentTo(expected);
        }

        private bool ValidateColumnBNumber(int columnNumber)
        {
            if (columnNumber >= 1 && columnNumber <= 15)
            {
                return true;
            }
            return false;
        }
    }
}
