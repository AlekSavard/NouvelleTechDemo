using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDemo
{
    class Bullet : GameObject
    {
        private const char VISUAL_BULLET = '¤';
        private Direction direction;

        public Bullet(Direction bulletDirection)
        {
            direction = bulletDirection;
        }

        public void Update()
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
