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
                Column1 = actual.Column1,
                Column2 = actual.Column2,
                Column3 = actual.Column3,
                Column4 = actual.Column4,
                Column5 = actual.Column5
            };
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
