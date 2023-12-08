using Bingo.src;
using FluentAssertions;
using NUnit.Framework;

namespace Bingo
{
    [TestFixture]
    public class BingoCardTest
    {
        private BingoCard _bingoCard;

        [SetUp]
        public void A00_SetUp()
        {
            _bingoCard = new BingoCard();
        }

        [Test]
        public void A01_CreateColumnB()
        {
            var actual = _bingoCard.CreateColumnB();
            var expected = new NormalColumn
            {
                Column1 = ValidateColumnNumber("B", actual.Column1) ? actual.Column1 : 0,
                Column2 = ValidateColumnNumber("B", actual.Column2) ? actual.Column2 : 0,
                Column3 = ValidateColumnNumber("B", actual.Column3) ? actual.Column3 : 0,
                Column4 = ValidateColumnNumber("B", actual.Column4) ? actual.Column4 : 0,
                Column5 = ValidateColumnNumber("B", actual.Column5) ? actual.Column5 : 0
            };
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void A02_CreateColumnI()
        {
            var actual = _bingoCard.CreateColumnI();
            var expected = new NormalColumn
            {
                Column1 = ValidateColumnNumber("I", actual.Column1) ? actual.Column1 : 0,
                Column2 = ValidateColumnNumber("I", actual.Column2) ? actual.Column2 : 0,
                Column3 = ValidateColumnNumber("I", actual.Column3) ? actual.Column3 : 0,
                Column4 = ValidateColumnNumber("I", actual.Column4) ? actual.Column4 : 0,
                Column5 = ValidateColumnNumber("I", actual.Column5) ? actual.Column5 : 0
            };
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void A03_CreateColumnN()
        {
            var actual = _bingoCard.CreateColumnN();
            var expected = new SpecialColumn
            {
                Column1 = ValidateColumnNumber("N", actual.Column1) ? actual.Column1 : 0,
                Column2 = ValidateColumnNumber("N", actual.Column2) ? actual.Column2 : 0,
                Column4 = ValidateColumnNumber("N", actual.Column4) ? actual.Column4 : 0,
                Column5 = ValidateColumnNumber("N", actual.Column5) ? actual.Column5 : 0
            };
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void A04_CreateColumnG()
        {
            var actual = _bingoCard.CreateColumnG();
            var expected = new NormalColumn
            {
                Column1 = ValidateColumnNumber("G", actual.Column1) ? actual.Column1 : 0,
                Column2 = ValidateColumnNumber("G", actual.Column2) ? actual.Column2 : 0,
                Column3 = ValidateColumnNumber("G", actual.Column3) ? actual.Column3 : 0,
                Column4 = ValidateColumnNumber("G", actual.Column4) ? actual.Column4 : 0,
                Column5 = ValidateColumnNumber("G", actual.Column5) ? actual.Column5 : 0
            };
            actual.Should().BeEquivalentTo(expected);
        }
        
        [Test]
        public void A05_CreateColumnO()
        {
            var actual = _bingoCard.CreateColumnO();
            var expected = new NormalColumn
            {
                Column1 = ValidateColumnNumber("O", actual.Column1) ? actual.Column1 : 0,
                Column2 = ValidateColumnNumber("O", actual.Column2) ? actual.Column2 : 0,
                Column3 = ValidateColumnNumber("O", actual.Column3) ? actual.Column3 : 0,
                Column4 = ValidateColumnNumber("O", actual.Column4) ? actual.Column4 : 0,
                Column5 = ValidateColumnNumber("O", actual.Column5) ? actual.Column5 : 0
            };
            actual.Should().BeEquivalentTo(expected);
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
                case "I":
                    min = 16;
                    max = 30;
                    break;
                case "N":
                    min = 31;
                    max = 45;
                    break;
                case "G":
                    min = 46;
                    max = 60;
                    break;
                case "O":
                    min = 61;
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
