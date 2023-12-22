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
            var actual = _bingoNumber.CreateRandomNumber("B");
            var expected = ValidateColumnNumber("B", actual) ? actual : 0;
            actual.Should().Be(expected);
        }
        
        [Test]
        public void A02_CreateIRandomNumber()
        {
            var actual = _bingoNumber.CreateRandomNumber("I");
            var expected = ValidateColumnNumber("I", actual) ? actual : 0;
            actual.Should().Be(expected);
        }
        
        [Test]
        public void A03_CreateNRandomNumber()
        {
            var actual = _bingoNumber.CreateRandomNumber("N");
            var expected = ValidateColumnNumber("N", actual) ? actual : 0;
            actual.Should().Be(expected);
        }

        private bool ValidateColumnNumber(string columnName, int columnNumber)
        {
            var columnRange = new Dictionary<string, Tuple<int, int>>
            {
                { "B", new Tuple<int, int>((int)Minimum.B, (int)Maximum.B) },
                { "I", new Tuple<int, int>((int)Minimum.I, (int)Maximum.I) },
                { "N", new Tuple<int, int>((int)Minimum.N, (int)Maximum.N) }
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
