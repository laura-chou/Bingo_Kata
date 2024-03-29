using Bingo.src;
using FluentAssertions;
using NUnit.Framework;

namespace Bingo
{
    [TestFixture]
    public class BingoGameTest
    {
        private BingoGame _bingoGame;

        [SetUp]
        public void A00_SetUp()
        {
            _bingoGame = new BingoGame(GenerateBingoCard());
        }

        [Test]
        [TestCase(new int[] { 10, 2, 1, 11, 15 }, new string[] { "V1" })]
        [TestCase(new int[] { 28, 17, 29, 16, 22 }, new string[] { "V2" })]
        [TestCase(new int[] { 31, 45, 35, 41 }, new string[] { "V3" })]
        [TestCase(new int[] { 55, 59, 51, 48, 54 }, new string[] { "V4" })]
        [TestCase(new int[] { 61, 70, 74, 67, 66 }, new string[] { "V5" })]
        public void A01_VerticalLine(int[] pickNumbers, string[] bingoLines)
        {
            AssertResultShouldReturn(pickNumbers, bingoLines);
        }
        
        [TestCase(new int[] { 10, 28, 31, 55, 61 }, new string[] { "H1" })]
        [TestCase(new int[] { 2, 17, 45, 59, 70 }, new string[] { "H2" })]
        [TestCase(new int[] { 1, 29, 51, 74 }, new string[] { "H3" })]
        [TestCase(new int[] { 11, 16, 35, 48, 67 }, new string[] { "H4" })]
        [TestCase(new int[] { 15, 22, 41, 54, 66 }, new string[] { "H5" })]
        public void A02_HorizontalLine(int[] pickNumbers, string[] bingoLines)
        {
            AssertResultShouldReturn(pickNumbers, bingoLines);
        }
        
        [TestCase(new int[] { 10, 17, 48, 66 }, new string[] { "D1" })]
        [TestCase(new int[] { 61, 59, 16, 15 }, new string[] { "D2" })]
        public void A03_DiagonalLine(int[] pickNumbers, string[] bingoLines)
        {
            AssertResultShouldReturn(pickNumbers, bingoLines);
        }
        
        [TestCase(new int[] { 31, 45, 35, 41, 1, 29, 51, 74 }, new string[] { "V3", "H3" })]
        [TestCase(new int[] { 10, 2, 1, 11, 15, 22, 41, 54, 66, 61, 59, 16, 15 }, new string[] { "V1", "H5", "D2" })]
        [TestCase(new int[] { 10, 17, 48, 66, 61, 59, 16, 15, 31, 45, 35, 41, 1, 29, 51, 74 }, new string[] { "V3", "H3", "D1", "D2" })]
        [TestCase(new int[] { 28, 17, 29, 16, 22, 55, 59, 51, 48, 54, 2, 45, 70, 11, 35, 67, 10, 66 }, new string[] { "V2", "V4", "H2", "H4", "D1" })]
        public void A04_MultipleLine(int[] pickNumbers, string[] bingoLines)
        {
            AssertResultShouldReturn(pickNumbers, bingoLines);
        }

        private void AssertResultShouldReturn(int[] pickNumbers, string[] bingoLines)
        {
            FakePickBallNumbers(pickNumbers);
            var actual = _bingoGame.GetLine();
            actual.Should().BeEquivalentTo(bingoLines);
        }

        private void FakePickBallNumbers(int[] pickNumbers)
        {
            foreach (var number in pickNumbers)
            {
                _bingoGame.PickBall(number);
            }
        }

        private BingoCard GenerateBingoCard()
        {
            return new BingoCard
            {
                Card = new int[5, 5] {
                    { 10, 28, 31, 55, 61 },
                    { 2, 17, 45, 59, 70 },
                    { 1, 29, 0, 51, 74 },
                    { 11, 16, 35, 48, 67 },
                    { 15, 22, 41, 54, 66 }
                },
                IsBingo = new bool[5, 5]
            };
        }
    }
}