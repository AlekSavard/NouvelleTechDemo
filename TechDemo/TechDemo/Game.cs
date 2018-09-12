using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TechDemo
{
    class Game
    {
        private const int NB_ENEMY = 8;
        private static readonly int[] ENEMY_POSITIONX = { 20, 40, 60, 80 };
        private static readonly int[] ENEMY_POSITIONY = { 5, 15 };
        private const int PLAYER_POSITIONX = 50;
        private const int PLAYER_POSITIONY = 10;
        private const int GAME_WIDTH = 100;
        private const int GAME_HEIGHT = 20;

        private Enemy[] enemies;
        private List<Bullet> bullets = new List<Bullet>();
        private Queue<Bullet> bulletsToDestroy = new Queue<Bullet>();
        private Wall[] walls;
        private Player player;
        private int frameRate = 0;
        private Thread threadMove;
        private Thread threadShoot;

        public Game()
        {
            walls = new Wall[GAME_WIDTH * 2 + GAME_HEIGHT * 2 - 2];
            for (int i = 0; i < GAME_WIDTH; i++)
            {
                walls[i] = new Wall(i, 0);
                Console.SetCursorPosition(walls[i].positionX, walls[i].positionY);
                Console.Write(Wall.VISUAL);
            }

            for (int i = 0; i < GAME_WIDTH; i++)
            {
                int temp = i + GAME_WIDTH;
                walls[temp] = new Wall(i, GAME_HEIGHT);
                Console.SetCursorPosition(walls[temp].positionX, walls[temp].positionY);
                Console.Write(Wall.VISUAL);
            }

            for (int i = 0; i < GAME_HEIGHT - 1; i++)
            {
                int temp = i + GAME_WIDTH + GAME_WIDTH;
                walls[temp] = new Wall(0, i + 1);
                Console.SetCursorPosition(walls[temp].positionX, walls[temp].positionY);
                Console.Write(Wall.VISUAL);
            }

            for (int i = 0; i < GAME_HEIGHT - 1; i++)
            {
                int temp = i + GAME_WIDTH + GAME_WIDTH + GAME_HEIGHT - 1;
                walls[temp] = new Wall(GAME_WIDTH - 1, i + 1);
                Console.SetCursorPosition(walls[temp].positionX, walls[temp].positionY);
                Console.Write(Wall.VISUAL);
            }
            enemies = new Enemy[NB_ENEMY];
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new Enemy(ENEMY_POSITIONX[i % 4], ENEMY_POSITIONY[i < 4 ? 0 : 1]);
            }
            player = new Player(PLAYER_POSITIONX, PLAYER_POSITIONY);
        }

        public void Run()
        {
            while (true)
            {
                Update();
            }
        }

        private void Update()
        {
            if (frameRate++ == 600)
            {
                EnemyUpdate();
                BulletUpdate();
                Draw();
                frameRate = 0;
            }

            if (Console.KeyAvailable)
            {
                ReadInput();
            }
        }

        private void EnemyUpdate()
        {
            foreach (var enemy in enemies)
            {
                Direction direction = enemy.Update();
                bool canMove = true;
                switch (direction)
                {
                    case Direction.UP:
                        foreach (var wall in walls)
                        {
                            if (enemy.positionY - 1 == wall.positionY && enemy.positionX == wall.positionX)
                            {
                                canMove = false;
                                break;
                            }
                        }

                        if (canMove)
                        {
                            enemy.Move(Direction.UP);
                        }
                        break;
                    case Direction.RIGHT:
                        foreach (var wall in walls)
                        {
                            if (enemy.positionX + 1 == wall.positionX && enemy.positionY == wall.positionY)
                            {
                                canMove = false;
                                break;
                            }
                        }

                        if (canMove)
                        {
                            enemy.Move(Direction.RIGHT);
                        }
                        break;
                    case Direction.DOWN:
                        foreach (var wall in walls)
                        {
                            if (enemy.positionY + 1 == wall.positionY && enemy.positionX == wall.positionX)
                            {
                                canMove = false;
                                break;
                            }
                        }

                        if (canMove)
                        {
                            enemy.Move(Direction.DOWN);
                        }
                        break;
                    case Direction.LEFT:
                        foreach (var wall in walls)
                        {
                            if (enemy.positionX - 1 == wall.positionX && enemy.positionY == wall.positionY)
                            {
                                canMove = false;
                                break;
                            }
                        }

                        if (canMove)
                        {
                            enemy.Move(Direction.LEFT);
                        }
                        break;
                }
                if (enemy.positionY == player.positionY && enemy.positionX == player.positionX)
                {
                    enemy.Collide();
                    player.Collided();
                }
            }
        }

        private void BulletUpdate()
        {
            lock (bullets)
            {
                foreach (var bullet in bullets)
                {
                    bullet.Update();
                    foreach (var wall in walls)
                    {
                        if (bullet.positionX == wall.positionX && bullet.positionY == wall.positionY)
                        {
                            bulletsToDestroy.Enqueue(bullet);
                        }
                    }

                    foreach (var enemy in enemies)
                    {
                        if (bullet.positionX == enemy.positionX && bullet.positionY == enemy.positionY)
                        {
                            bulletsToDestroy.Enqueue(bullet);
                            enemy.Collide();
                        }
                    }
                }

                foreach (var bulletToDestroy in bulletsToDestroy)
                {
                    bullets.Remove(bulletToDestroy);
                }
                bulletsToDestroy.Clear();
            }
        }

        private void Draw()
        {
            Console.Clear();
            foreach (var enemy in enemies)
            {
                Console.SetCursorPosition(enemy.positionX, enemy.positionY);
                Console.Write(enemy.CurrentVisual);
            }
            foreach (var bullet in bullets)
            {
                Console.SetCursorPosition(bullet.positionX, bullet.positionY);
                Console.Write(Bullet.VISUAL_BULLET);
            }
            foreach (var wall in walls)
            {
                Console.SetCursorPosition(wall.positionX, wall.positionY);
                Console.Write(Wall.VISUAL);
            }
            Console.SetCursorPosition(player.positionX, player.positionY);
            Console.Write(Player.VISUAL_ALIVE);
        }

        private void ReadInput()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            bool canMove = true;
            switch (key)
            {
                case ConsoleKey.W:
                    foreach (var wall in walls)
                    {
                        if (player.positionY - 1 == wall.positionY && player.positionX == wall.positionX)
                        {
                            canMove = false;
                            break;
                        }
                    }

                    if (canMove)
                    {
                        player.Update(Direction.UP);
                    }
                    break;
                case ConsoleKey.D:
                    foreach (var wall in walls)
                    {
                        if (player.positionX + 1 == wall.positionX && player.positionY == wall.positionY)
                        {
                            canMove = false;
                            break;
                        }
                    }

                    if (canMove)
                    {
                        player.Update(Direction.RIGHT);
                    }
                    break;
                case ConsoleKey.S:
                    foreach (var wall in walls)
                    {
                        if (player.positionY + 1 == wall.positionY && player.positionX == wall.positionX)
                        {
                            canMove = false;
                            break;
                        }
                    }

                    if (canMove)
                    {
                        player.Update(Direction.DOWN);
                    }
                    break;
                case ConsoleKey.A:
                    foreach (var wall in walls)
                    {
                        if (player.positionX - 1 == wall.positionX && player.positionY == wall.positionY)
                        {
                            canMove = false;
                            break;
                        }
                    }

                    if (canMove)
                    {
                        player.Update(Direction.LEFT);
                    }
                    break;

                //Gestion de shoot
                case ConsoleKey.UpArrow:
                    bullets.Add(new Bullet(player.positionX, player.positionY, Direction.UP));
                    break;
                case ConsoleKey.RightArrow:
                    bullets.Add(new Bullet(player.positionX, player.positionY, Direction.RIGHT));
                    break;
                case ConsoleKey.DownArrow:
                    bullets.Add(new Bullet(player.positionX, player.positionY, Direction.DOWN));
                    break;
                case ConsoleKey.LeftArrow:
                    bullets.Add(new Bullet(player.positionX, player.positionY, Direction.LEFT));
                    break;
            }
            foreach (var enemy in enemies)
            {
                if (player.positionY == enemy.positionY && player.positionX == enemy.positionX)
                {
                    player.Collided();
                    enemy.Collide();
                }
            }
        }
    }
}