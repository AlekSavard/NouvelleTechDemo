using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDemo
{
    /// <summary>
    /// Classe qui représente un joueur du jeu
    /// </summary>
    class Player : Character
    {
        public const char VISUAL = 'E';

        public char CurrentVisual { get; private set; }

        /// <summary>
        /// Cconstructeur du joueur.
        /// </summary>
        /// <param name="posX">La position d'apparition du joueur en X</param>
        /// <param name="posY">La position d'apparition du joueur en Y</param>
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

        /// <summary>
        /// Condition de fin du jeu.
        /// </summary>
        public void Collided()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Méthode de mouvement du joueur
        /// </summary>
        /// <param name="direction">La direction dans laquelle le joueur doit bouger</param>
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
