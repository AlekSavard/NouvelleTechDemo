using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDemo
{
    class Player : Character
    {
        public const char VISUAL = 'E';

        public char CurrentVisual { get; private set; }

        public Player(int posX, int posY)
        {
            positionX = posX;
            positionY = posY;
            CurrentVisual = VISUAL;
        }

        public void Update(Direction directionMove)
        {
            Move(directionMove);
        }

        public void Collided()
        {
            Environment.Exit(0);
        }

        public ConsoleKeyInfo GetInput()
        {
            return Console.ReadKey(Console.KeyAvailable);
        }

        private void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.DOWN:
                    positionY++;
                    break;
                case Direction.LEFT:
                    positionX--;
                    break;
                case Direction.RIGHT:
                    positionX++;
                    break;
                case Direction.UP:
                    positionY--;
                    break;
                case Direction.NONE:
                    break;
            }
        }
    }
}
