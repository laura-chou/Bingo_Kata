using Bingo.src;
using FluentAssertions;
using NUnit.Framework;

namespace Bingo
{
    [TestFixture]
    public class BingoGameTest
    {
        [Test]
        public void A01_VerticalLine()
        {
            var bingoGame = new BingoGame();
            bingoGame.BingoCard = new BingoCard
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
            bingoGame.PickBall(10);
            bingoGame.PickBall(2);
            bingoGame.PickBall(1);
            bingoGame.PickBall(11);
            bingoGame.PickBall(15);
            var actual = bingoGame.GetLine();
            actual.Should().BeEquivalentTo(new List<string>{ "V1" });
        }
    }
}