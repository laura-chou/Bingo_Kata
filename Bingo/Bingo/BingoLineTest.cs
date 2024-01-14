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
        [TestCase(new string[] { "B2", "I16", "N45", "G52", "O69" }, 0)]
        public void A01_BingoNoLine(string[] bingoNumber, int bingoLine)
        {
            AssertResultShouldReturn(bingoNumber.ToList(), bingoLine);
        }

        [Test]
        [TestCase(new string[] { "B15", "B10", "B1", "B9", "B12" }, 1)]
        [TestCase(new string[] { "I25", "I17", "I20", "I19", "I29" }, 1)]
        [TestCase(new string[] { "N40", "N42", "N39", "N35", "N31" }, 1)]
        [TestCase(new string[] { "G50", "G46", "G59", "G51", "G60" }, 1)]
        [TestCase(new string[] { "O75", "O65", "O68", "O71", "O63" }, 1)]
        [TestCase(new string[] { "G50", "G46", "G59", "G51", "G60", "N40", "N42", "N35", "N31" }, 1)]
        [TestCase(new string[] { "B9", "B10", "B12", "B1", "B15", 
                                "I20", "I25", "I19", "I29", "I17" }, 2)]
        [TestCase(new string[] { "B9", "B10", "B12", "B1", "B15", 
                                "I20", "I25", "I19", "I29", "I17", 
                                "N40", "N42", "N32", "N35", "N31" }, 3)]
        [TestCase(new string[] { "B9", "B10", "B12", "B1", "B15",
                                "I20", "I25", "I19", "I29", "I17",
                                "N40", "N42", "N32", "N35", "N31",
                                "G50", "G46", "G59", "G51", "G60"}, 4)]
        [TestCase(new string[] { "B9", "B10", "B12", "B1", "B15",
                                "I20", "I25", "I19", "I29", "I17",
                                "N40", "N42", "N32", "N35", "N31",
                                "G50", "G46", "G59", "G51", "G60",
                                "O75", "O65", "O68", "O71", "O63"}, 5)]
        public void A02_BingoVerticalLine(string[] bingoNumber, int bingoLine)
        {
            AssertResultShouldReturn(bingoNumber.ToList(), bingoLine);
        }

        private void AssertResultShouldReturn(List<string> bingoNumber, int result)
        {
            var actual = _bingoLine.GetBingoLine(GenerateBingoCard(), bingoNumber);
            actual.Should().Be(result);
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
