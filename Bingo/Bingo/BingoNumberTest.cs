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

        private bool ValidateColumnNumber(string columnName, int columnNumber)
        {
            var min = 1;
            var max = 75;
            switch (columnName)
            {
                case "B":
                    max = 15;
                    break;
            }

            if (columnNumber >= min && columnNumber <= max)
            {
                return true;

            }
            return false;
        }
    }
}
