using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EjerciciosBootcampNet
{
    public class Snake
    {
        class Position
        {
            public int positionY;
            public int positionX;

            public Position(int snakeY, int snakeX)
            {
                this.positionY = snakeY;
                this.positionX = snakeX;
            }
        }

        public static eDirection currentDirection = eDirection.Right;
        private static List<Position> snakeBody = new List<Position>();
        private static int snakeActualX;
        private static int snakeActualY;
        
        public static void InicializeSnake()
        {
            snakeActualX = (Board.panelSnake.GetLength(1) - 1) / 2;
            snakeActualY = (Board.panelSnake.GetLength(0) - 1) / 2;
            snakeBody.Add(new Position(snakeActualY, snakeActualX));

            Board.panelSnake[snakeActualY, snakeActualX] = 'O';
        }

        public static void Controls()
        {
            switch (currentDirection)
            {
                case eDirection.Up:
                    RemoveSnakeBack();
                    snakeActualY--;
                    MoveSnake();
                    break;
                case eDirection.Down:
                    RemoveSnakeBack();
                    snakeActualY++;
                    MoveSnake();
                    break;
                case eDirection.Right:
                    RemoveSnakeBack();
                    snakeActualX++;
                    MoveSnake();
                    break;
                case eDirection.Left:
                    RemoveSnakeBack();
                    snakeActualX--;
                    MoveSnake();
                    break;
            }
        }

        public static void MoveSnake()
        {
            CollisionFood();
            snakeBody.Add(new Position(snakeActualY, snakeActualX));

            foreach (var body in snakeBody)
            {
                Board.panelSnake[body.positionY, body.positionX] = 'O';
            }
        }

        public static void RemoveSnakeBack()
        {
            Position body = snakeBody.Last();
            Board.panelSnake[body.positionY, body.positionX] = ' ';

            snakeBody.RemoveAt(snakeBody.Count-1);
        }

        public static bool CollisionWalls()
        {
            if(snakeActualX == Board.panelSnake.GetLength(1) - 1 || snakeActualX == 0)
                return true;
            else if(snakeActualY == Board.panelSnake.GetLength(0) - 1 || snakeActualY == 0)
                return true;
            else
                return false;
        }

        public static void CollisionFood()
        {
            if (Board.panelSnake[snakeActualY, snakeActualX] == '8')
            {
                Board.GenerateRandomFood();
            }

        }

        public static bool CollisionPoison()
        {
            if (Board.panelSnake[snakeActualY, snakeActualX] == 'X')
                return true;
            else
                return false;

        }
    }
}
