﻿using Bingo.src;
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
            var expected = new Column
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
            var expected = new Column
            {
                Column1 = ValidateColumnNumber("I", actual.Column1) ? actual.Column1 : 0,
                Column2 = ValidateColumnNumber("I", actual.Column2) ? actual.Column2 : 0,
                Column3 = ValidateColumnNumber("I", actual.Column3) ? actual.Column3 : 0,
                Column4 = ValidateColumnNumber("I", actual.Column4) ? actual.Column4 : 0,
                Column5 = ValidateColumnNumber("I", actual.Column5) ? actual.Column5 : 0
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
            }

            if (columnNumber >= min && columnNumber <= max)
            {
                return true;

            }
            return false;
        }
    }
}
