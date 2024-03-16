namespace Bingo.src
{
    public class BingoCard
    {
        public string PlayerName { get; set; }
        public int[,] Card { get; set; }
        public bool[,] IsBingo { get; set; }
        public List<string> BingoLines { get; set; }
    }
}