using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDemo
{
    class EnemyStrategy : BaseStrategy
    {
        private Random rand = new Random();

        public override Direction Act()
        {
            int nextDirection = rand.Next(0, 4);

            switch (nextDirection)
            {
                case 0 :
                    return Direction.DOWN;
                case 1:
                    return Direction.LEFT;
                case 2:
                    return Direction.RIGHT;
                case 3:
                    return Direction.UP;
                default:
                    return Direction.NONE;
            }
        }
    }
}
