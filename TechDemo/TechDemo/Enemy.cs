using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDemo
{
    /// <summary>
    /// Classe des ennemis du monde.
    /// </summary>
    class Enemy : Character
    {
        public const char VISUAL_ALIVE = 'B';
        public const char VISUAL_DEAD = 'X';

        private BaseStrategy strategy;

        public char CurrentVisual { get; private set; }

        /// <summary>
        /// Constructeur des ennemies
        /// </summary>
        /// <param name="posX">La position d'apparition en X</param>
        /// <param name="posY">La position d'apparition en Y</param>
        public Enemy(int posX, int posY)
        {
            positionX = posX;
            positionY = posY;
            strategy = new EnemyStrategy();
            CurrentVisual = VISUAL_ALIVE;
        }

        /// <summary>
        /// La méthode d'update d'un ennemi
        /// </summary>
        /// <returns></returns>
        public Direction Update()
        {
            return strategy.Act();
        }

        /// <summary>
        /// Méthode de mouvement de l'ennemi.
        /// Un ennemi bouge d'un unité dans la direction imposée
        /// </summary>
        /// <param name="direction">Direction à bouger</param>
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
