using System;
using Basics.Properties;

namespace Basics
{
    internal class Program
    {
        private Vector2 _mapSize = new Vector2(5, 5);

        private bool _isPlaying = true;
        
        public static void Main(string[] args)
        {
            Random random = new Random();
            Program program = new Program();
            Player player = new Player(program._mapSize);
            char[,] map = new char[program._mapSize.y, program._mapSize.x];
            for (int i = 0; i < program._mapSize.y; i++)
            {
                for (int j = 0; j < program._mapSize.x; j++)
                {
                    if (random.Next(0, 6) == 5 && !CustomMath.VectorEquals(new Vector2(j, i), player.position))
                        map[j, i] = '%';
                    else 
                        map[j,i] = '0';
                }
            }

            while (program._isPlaying)
            {
                RegenMap(program, player, map);
                
                if(player.health <= 0)
                    break;
                
                char input = Console.ReadKey().KeyChar;

                Vector2 moveInput = new Vector2(0, 0);
                switch (input)
                {
                    case 'w':
                        moveInput = new Vector2(0, -1);
                        break;
                    case 's':
                        moveInput = new Vector2(0, 1);
                        break;
                    case 'a':
                        moveInput = new Vector2(-1, 0);
                        break;
                    case 'd':
                        moveInput = new Vector2(1, 0);
                        break;
                    case 'p':
                        program._isPlaying = false;
                        break;
                }
                player.Move(moveInput);
            }
            
            Console.Clear();
            Console.WriteLine("end");
        }

        private static void RegenMap(Program program, Player player, char[,] map)
        {
            Console.Clear();
            //newMap[player.position.y, player.position.x] = player.image;
            for (int i = 0; i < program._mapSize.y; i++)
            {
                for (int j = 0; j < program._mapSize.x; j++)
                {
                    Console.Write(CustomMath.VectorEquals(new Vector2(j, i), player.position) ? player.image : map[i, j]);
                }
                Console.Write("\n");
            }
            if(map[player.position.y, player.position.x] == '%')
                player.Damage(50);
        }
    }
}