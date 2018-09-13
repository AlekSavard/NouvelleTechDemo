using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDemo
{
    class Wall : GameObject
    {
        public const char VISUAL = '#';
        public Wall(int positionX, int positionY)
        {
            this.positionX = positionX;
            this.positionY = positionY;
        }
    }
}
