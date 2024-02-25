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
        public void A01_VerticalLine(int[] pickNumbers, string[] bingoLines)
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
                    { 15, 22, 41, 54, 77 }
                },
                IsBingo = new bool[5, 5]
            };
        }
    }
}