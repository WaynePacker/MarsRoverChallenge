namespace Mars.Rover
{
    public enum Direction
    {
        N = 0,
        E = 1,
        S = 2,
        W = 3
    }

    public class Position
    {
        public Position(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        public override string ToString()
        {
            return $"{X} {Y} {Direction}";
        }

        public override bool Equals(object other)
        {
            if(other is Position otherPosition)
            {
                return X == otherPosition.X && Y == otherPosition.Y;
            }
            else
            {
               return base.Equals(other);
            } 
        }

        public override int GetHashCode()
        {
            //To override Equals() this method must be overidden to keep the complier happy.
            return base.GetHashCode();
        }
    }
}
