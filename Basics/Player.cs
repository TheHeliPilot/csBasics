using Basics.Properties;

namespace Basics
{
    public class Player : Damagable
    {
        public int health;
        public Vector2 position;
        public char image = '#';
        private Vector2 _moveBounds;

        public Player(Vector2 moveBounds)
        {
            position = new Vector2(0, 0);
            health = 100;
            this._moveBounds = moveBounds;
        }

        public Player(int startHealth, Vector2 startPos, Vector2 moveBounds)
        {
            health = startHealth;
            position = startPos;
            this._moveBounds = moveBounds;
        }

        public void Heal(int amount)
        {
            if (amount <= 0)
                return;
            health += amount;
        }

        public void Damage(int amount)
        {
            if (amount <= 0)
                return;
            health -= amount;
        }

        public void Move(Vector2 amount)
        {
            Vector2 newPos = CustomMath.Add(position, amount);
            if (newPos.x < 0 || newPos.x >= _moveBounds.x || newPos.y < 0 || newPos.y >= _moveBounds.y)
                return;
            position = newPos;
        }
    }
}