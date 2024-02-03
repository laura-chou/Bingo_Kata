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
            bingoGame.BingoCard = GenerateBingoCard();
            bingoGame.PickBall(10);
            bingoGame.PickBall(2);
            bingoGame.PickBall(1);
            bingoGame.PickBall(11);
            bingoGame.PickBall(15);
            var actual = bingoGame.GetLine();
            actual.Should().BeEquivalentTo(new List<string> { "V1" });
        }

        private BingoCard GenerateBingoCard()
        {
            return new BingoCard
            {
                B = new List<CardNumber>
                {
                    new CardNumber {Number = 10, IsBingo = false},
                    new CardNumber {Number = 2, IsBingo = false},
                    new CardNumber {Number = 1, IsBingo = false},
                    new CardNumber {Number = 11, IsBingo = false},
                    new CardNumber {Number = 15, IsBingo = false}
                },
                I = new List<CardNumber>
                {
                    new CardNumber {Number = 28, IsBingo = false},
                    new CardNumber {Number = 17, IsBingo = false},
                    new CardNumber {Number = 29, IsBingo = false},
                    new CardNumber {Number = 16, IsBingo = false},
                    new CardNumber {Number = 22, IsBingo = false}
                },
                N = new List<CardNumber>
                {
                    new CardNumber {Number = 31, IsBingo = false},
                    new CardNumber {Number = 45, IsBingo = false},
                    new CardNumber {Number = 35, IsBingo = false},
                    new CardNumber {Number = 41, IsBingo = false},
                },
                G = new List<CardNumber>
                {
                    new CardNumber {Number = 55, IsBingo = false},
                    new CardNumber {Number = 59, IsBingo = false},
                    new CardNumber {Number = 51, IsBingo = false},
                    new CardNumber {Number = 48, IsBingo = false},
                    new CardNumber {Number = 54, IsBingo = false}
                },
                O = new List<CardNumber>
                {
                    new CardNumber {Number = 61, IsBingo = false},
                    new CardNumber {Number = 70, IsBingo = false},
                    new CardNumber {Number = 74, IsBingo = false},
                    new CardNumber {Number = 67, IsBingo = false},
                    new CardNumber {Number = 66, IsBingo = false}
                }
            };
        }
    }
}
