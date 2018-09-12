using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDemo
{
    class Player : Character
    {
        public const char VISUAL_ALIVE = 'E';
        public const char VISUAL_DEAD = 'X';

        public char CurrentVisual { get; private set; }

        public Player(int posX, int posY)
        {
            positionX = posX;
            positionY = posY;
            CurrentVisual = VISUAL_ALIVE;
        }

        public void Update(Direction directionMove)
        {
            Move(directionMove);
        }

        public void Collided()
        {
            isDead = true;
            CurrentVisual = VISUAL_DEAD;
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
