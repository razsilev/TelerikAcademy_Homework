namespace GameFifteen
{
    public class Position
    {
        public Position(int row = 0, int column = 0)
        {
            this.Row = row;
            this.Column = column;
        }

        public int Row { get; set; }
        public int Column { get; set; }
    }
}
