using NUnit.Framework;
using FluentAssertions;
using Bingo.src;

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
        [TestCase(new int[] { 36, 11, 5, 75, 40 }, "no winner. player A get 0 line, player B get 0 line.")]
        public void A01_NoLine(int[] fakePickBallNumbers, string output)
        {
            AssertResultShouldReturn(fakePickBallNumbers, output);
        }
        
        [Test]
        [TestCase(new int[] { 10, 2, 1, 11, 15 }, "player A wins. player A get 1 line (V1), player B get 0 line.")]
        [TestCase(new int[] { 46, 51, 48, 57, 59 }, "player B wins. player A get 0 line, player B get 1 line (V4).")]
        [TestCase(new int[] { 55, 59, 51, 48, 54, 32, 44, 35, 42 }, "no winner. player A get 1 line (V4), player B get 1 line (V3).")]
        public void A02_VerticalLine(int[] fakePickBallNumbers, string output)
        {
            AssertResultShouldReturn(fakePickBallNumbers, output);
        }

        private List<BingoCard> GenerateBingoCard()
        {
            return new List<BingoCard>
            {
                new BingoCard
                {
                    PlayerName = "player A",
                    Card = new int[5, 5]
                    {
                        { 10, 28, 31, 55, 61 },
                        { 2, 17, 45, 59, 70 },
                        { 1, 29, 0, 51, 74 },
                        { 11, 16, 35, 48, 67 },
                        { 15, 22, 41, 54, 77 }
                    },
                    IsBingo = new bool[5, 5]
                },
                new BingoCard
                {
                    PlayerName = "player B",
                    Card = new int[5, 5]
                    {
                        { 10, 16, 32, 46, 65 },
                        { 14, 22, 44, 51, 74 },
                        { 2, 29, 0, 48, 62 },
                        { 8, 18, 35, 57, 66 },
                        { 6, 25, 42, 59, 71 }
                    },
                    IsBingo = new bool[5, 5]
                }
            };
        }

        private void AssertResultShouldReturn(int[] fakePickBallNumbers, string output)
        {
            FakePickBallNumbers(fakePickBallNumbers);
            var actual = _bingoGame.GameResult();
            actual.Should().Be(output);
        }

        private void FakePickBallNumbers(int[] fakePickBallNumbers)
        {
            foreach (var number in fakePickBallNumbers)
            {
                _bingoGame.PickBall(number);
            }
        }
    }
}