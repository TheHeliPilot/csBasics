using Basics.Properties;

namespace Basics
{
    public static class CustomMath
    {
        public static int Add(int a, int b)
        {
            return (a + b);
        }

        public static Vector2 Add(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }

        public static bool VectorEquals(Vector2 a, Vector2 b)
        {
            return a.x == b.x && a.y == b.y;
        }
    }
}