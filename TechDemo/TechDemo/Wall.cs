using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDemo
{
    /// <summary>
    /// Classe qui représente un mur dans la logique du jeu
    /// </summary>
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
