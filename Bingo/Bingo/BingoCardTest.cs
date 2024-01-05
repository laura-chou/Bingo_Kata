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
            var columnRange = new Dictionary<string, Tuple<int, int>>
            {
                { "B", new Tuple<int, int>((int)Minimum.B, (int)Maximum.B) },
                { "I", new Tuple<int, int>((int)Minimum.I, (int)Maximum.I) },
                { "N", new Tuple<int, int>((int)Minimum.N, (int)Maximum.N) },
                { "G", new Tuple<int, int>((int)Minimum.G, (int)Maximum.G) },
                { "O", new Tuple<int, int>((int)Minimum.O, (int)Maximum.O) }
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
