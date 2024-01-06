﻿using Bingo.src;
using FluentAssertions;
using NUnit.Framework;

namespace Bingo
{
    [TestFixture]
    public class BingoLineTest
    {
        private BingoLine _bingoLine;
        
        [SetUp]
        public void A00_SetUp()
        {
            _bingoLine = new BingoLine();
        }

        [Test]
        public void A01_BingoNoLine()
        {
            var bingoCard = GenerateBingoCard();
            var bingoNumber = new List<string>
            {
                "B2", "I16", "N45", "G52", "O69"
            };
            var actual = _bingoLine.GetBingoLine(bingoCard, bingoNumber);
            actual.Should().Be(0);
        }

        private BingoCard GenerateBingoCard()
        {
            return new BingoCard
            {
                B = new NormalColumn
                {
                    Column1 = 15,
                    Column2 = 10,
                    Column3 = 1,
                    Column4 = 9,
                    Column5 = 12
                },
                I = new NormalColumn
                {
                    Column1 = 25,
                    Column2 = 17,
                    Column3 = 20,
                    Column4 = 19,
                    Column5 = 29
                },
                N = new SpecialColumn
                {
                    Column1 = 40,
                    Column2 = 42,
                    Column4 = 35,
                    Column5 = 31
                },
                G = new NormalColumn
                {
                    Column1 = 50,
                    Column2 = 46,
                    Column3 = 59,
                    Column4 = 51,
                    Column5 = 60
                },
                O = new NormalColumn
                {
                    Column1 = 75,
                    Column2 = 65,
                    Column3 = 68,
                    Column4 = 71,
                    Column5 = 63
                }
            };
        }
    }
}
