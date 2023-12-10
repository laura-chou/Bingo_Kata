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
            var actual = _bingoCard.CreateColumn("B");
            var expected = GetNormalColumn((NormalColumn)actual, "B");
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void A02_CreateColumnI()
        {
            var actual = _bingoCard.CreateColumn("I");
            var expected = GetNormalColumn((NormalColumn)actual, "I");
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void A03_CreateColumnN()
        {
            var actual = _bingoCard.CreateColumn("N");
            var expected = GetSpecialColumn((SpecialColumn)actual, "N");
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void A04_CreateColumnG()
        {
            var actual = _bingoCard.CreateColumn("G");
            var expected = GetNormalColumn((NormalColumn)actual, "G");
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void A05_CreateColumnO()
        {
            var actual = _bingoCard.CreateColumn("O");
            var expected = GetNormalColumn((NormalColumn)actual, "O");
            actual.Should().BeEquivalentTo(expected);
        }
        
        [Test]
        public void A06_CreateBingoCard()
        {
            var actual = _bingoCard.CreateBingoCard();
            var expected = new BingoCard
            {
                B = GetNormalColumn(actual.B, "B"),
                I = GetNormalColumn(actual.I, "I"),
                N = GetSpecialColumn(actual.N, "N"),
                G = GetNormalColumn(actual.G, "G"),
                O = GetNormalColumn(actual.O, "O"),
            };
            actual.Should().BeEquivalentTo(expected);
        }

        private NormalColumn GetNormalColumn(NormalColumn actual, string columnName)
        {
            return new NormalColumn
            {
                Column1 = ValidateColumnNumber(columnName, actual.Column1) ? actual.Column1 : 0,
                Column2 = ValidateColumnNumber(columnName, actual.Column2) ? actual.Column2 : 0,
                Column3 = ValidateColumnNumber(columnName, actual.Column3) ? actual.Column3 : 0,
                Column4 = ValidateColumnNumber(columnName, actual.Column4) ? actual.Column4 : 0,
                Column5 = ValidateColumnNumber(columnName, actual.Column5) ? actual.Column5 : 0
            };
        }

        private SpecialColumn GetSpecialColumn(SpecialColumn actual, string columnName)
        {
            return new SpecialColumn
            {
                Column1 = ValidateColumnNumber(columnName, actual.Column1) ? actual.Column1 : 0,
                Column2 = ValidateColumnNumber(columnName, actual.Column2) ? actual.Column2 : 0,
                Column4 = ValidateColumnNumber(columnName, actual.Column4) ? actual.Column4 : 0,
                Column5 = ValidateColumnNumber(columnName, actual.Column5) ? actual.Column5 : 0
            };
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
