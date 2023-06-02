namespace Basics.Properties
{
    public struct Vector2
    {
        public int x { get; }
        public int y { get; }

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public string VectorToString()
        {
            return "{" + x.ToString() + ", " + y.ToString() + "}";
        }
    }
}