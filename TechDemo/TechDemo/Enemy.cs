using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDemo
{
    class Enemy : Character
    {
        public const char VISUAL_ALIVE = 'B';
        public const char VISUAL_DEAD = 'X';

        private BaseStrategy strategy;

        public char CurrentVisual { get; private set; }

        public Enemy(int posX, int posY)
        {
            positionX = posX;
            positionY = posY;
            strategy = new EnemyStrategy();
            CurrentVisual = VISUAL_ALIVE;
        }

        public Direction Update()
        {
            return strategy.Act();
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.DOWN :
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

        public void Die()
        {
            CurrentVisual = VISUAL_DEAD;
            strategy = new BaseStrategy.NullStrategy();
        }
    }
}
