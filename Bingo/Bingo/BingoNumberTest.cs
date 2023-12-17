using Bingo.src;
using FluentAssertions;
using NUnit.Framework;

namespace Bingo
{
    [TestFixture]
    public class BingoNumberTest
    {
        private BingoNumber _bingoNumber;

        [SetUp]
        public void A00_SetUp()
        {
            _bingoNumber = new BingoNumber();
        }

        [Test]
        public void A01_CreateBRandomNumber()
        {
            var actual = _bingoNumber.CreateBRandomNumber();
            var expected = ValidateColumnNumber("B", actual) ? actual : 0;
            actual.Should().Be(expected);
        }
        
        [Test]
        public void A02_CreateIRandomNumber()
        {
            var actual = _bingoNumber.CreateIRandomNumber();
            var expected = ValidateColumnNumber("I", actual) ? actual : 0;
            actual.Should().Be(expected);
        }

        private bool ValidateColumnNumber(string columnName, int columnNumber)
        {
            var columnRange = new Dictionary<string, Tuple<int, int>>
            {
                { "B", new Tuple<int, int>( 1, 15 ) },
                { "I", new Tuple<int, int>( 16, 30 ) }
            };

            if (columnNumber >= columnRange[columnName].Item1 
                && columnNumber <= columnRange[columnName].Item2)
            {
                return true;

            }
            return false;
        }
    }
}
