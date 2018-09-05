using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDemo
{
    class Game
    {
        private Enemy[] ennemies;
        private Bullet[] bullets;
        private Wall[] walls;
        private Player player;
        private const int GAME_WIDTH = 50;
        private const int GAME_HEIGHT = 30;


        public Game()
        {
            walls = new Wall[GAME_WIDTH * 2 + GAME_HEIGHT * 2 - 4];
            for (int i = 0; i < GAME_WIDTH; i++)
            {
                walls[i] = new Wall(i, 0);
            }
            for (int i = 0; i < GAME_HEIGHT - 1; i++)
            {
                walls[i] = new Wall(0, i + 1);
            }
        }

        public void Run()
        {

        }
    }
}
