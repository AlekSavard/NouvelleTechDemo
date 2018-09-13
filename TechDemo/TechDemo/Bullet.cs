using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDemo
{
    class Bullet : GameObject
    {
        public const char VISUAL_BULLET = '¤';
        private Direction direction;

        /// <summary>
        /// Constructeur de base d'une balle
        /// </summary>
        /// <param name="posX">La position d'apparition en X</param>
        /// <param name="posY">La position d'apparition en Y</param>
        /// <param name="bulletDirection">La direction dans laquelle la balle doit se diriger</param>
        public Bullet(int posX, int posY, Direction bulletDirection)
        {
            positionX = posX;
            positionY = posY;
            direction = bulletDirection;
        }

        /// <summary>
        /// Méthode appelée à chaque frame logique
        /// Pour une balle, cette méthode fera avancer la balle d'un unité dans la direction qu'elle s'est fait attribué
        /// lors de sa création.
        /// </summary>
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
