using DataStructures;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SnakeGame
{
    internal class SnakeGame : Game
    {
        public bool isFinished = false;
        public TypeGrid<CellType> grid;
        public Direction nextDirection;
        List<Point> snakePositions;
        Point FoodPos;
        public int Score { get; private set; }
        public int eatenFood { get; private set; }

        bool hasEaten = false;
        int gridSize;
        int initialFoodDistance;

        public SnakeGame(int gridSize)
        {
            this.gridSize = gridSize;
            SetUp();
        }

        public override void SetUp()
        {
            initialFoodDistance = 0;
            Score = 0;
            eatenFood = 0;
            snakePositions = new List<Point>();
            gridSize = Math.Max(gridSize, 8);
            grid = new TypeGrid<CellType>(gridSize, gridSize, CellType.Empty);

            int xStart = 5, yStart = gridSize / 2;
            for (int i = 0; i <= 5; i++)
                snakePositions.Add(new Point(xStart - i, yStart));
            bool initialFoodPosSwitch = Convert.ToBoolean(Math.Round(new Random(DateTime.Now.Millisecond).NextDouble()));
            int x = Convert.ToInt32(gridSize / 2), y;
            if (initialFoodPosSwitch)
                y = 3;
            else
                y = gridSize - 3;
            grid.Columns[x].Cells[y].value = CellType.Food;
        }

        public override void Update()
        {
            Move(nextDirection);
        }

        public void Move(Direction direction)
        {
            Point deltaPos = ToPoint(direction);
            int nextX, nextY;
            nextX = snakePositions[0].X + deltaPos.X;
            nextY = snakePositions[0].Y + deltaPos.Y;

            Point nextPos = new Point(nextX, nextY);
            if (nextPos.X > gridSize || nextPos.Y > gridSize || nextX < 0 || nextY < 0)
            {
                isFinished = true;
                return;
            }

            CellType nextPosType = grid[nextX, nextY].value;
            switch (nextPosType)
            {
                case CellType.Empty:
                    snakePositions.Add(nextPos);
                    snakePositions.RemoveAt(snakePositions.Count - 1);
                    if (!hasEaten)
                    {
                        Point distanceToFood = new Point(Math.Abs(FoodPos.X - nextX), Math.Abs(FoodPos.Y - nextY));
                        int distance = (int)(Math.Sqrt(distanceToFood.X * distanceToFood.X + distanceToFood.Y * distanceToFood.Y));
                        if (initialFoodDistance == 0)
                            initialFoodDistance = distance;
                        Score = initialFoodDistance - distance;
                    }
                    break;
                case CellType.Food:
                    snakePositions.Add(nextPos);
                    UpdateBoard();
                    GenerateFoodPos();
                    Score++;
                    eatenFood++;
                    hasEaten = true;
                    return;
                case CellType.Head:
                    isFinished = true;
                    break;
                case CellType.Neck:
                    Point negativeDeltaPos = new Point(-deltaPos.X, -deltaPos.Y);
                    Move(ToDirection(negativeDeltaPos));
                    break;
                case CellType.Body:
                    isFinished = true;
                    break;
                default:
                    throw new NotImplementedException();
            }
            UpdateBoard();
        }

        public double[] GetBoardInfo()
        {
            double[] output = new double[gridSize * gridSize + 2];
            Point headDistance = new Point(snakePositions[0].X - FoodPos.X, snakePositions[0].Y - FoodPos.Y);
            output[0] = headDistance.X;
            output[1] = headDistance.Y;
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    double cellInfo;
                    switch (grid[x, y].value)
                    {
                        case CellType.Empty:
                            cellInfo = 0;
                            break;
                        case CellType.Food:
                            cellInfo = 4;
                            break;
                        case CellType.Head:
                            cellInfo = 3;
                            break;
                        case CellType.Neck:
                            cellInfo = 2;
                            break;
                        case CellType.Body:
                            cellInfo = 1;
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    output[y * gridSize + x + 2] = cellInfo;
                }
            }
            return output;
        }

        public string GetBoardString()
        {
            string s = string.Empty;
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    switch (grid[x, y].value)
                    {
                        case CellType.Empty:
                            s += " ";
                            break;
                        case CellType.Food:
                            s += "O";
                            break;
                        case CellType.Head:
                            s += "@";
                            break;
                        case CellType.Neck:
                            s += "&";
                            break;
                        case CellType.Body:
                            s += "#";
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
                s += "\n";
            }
            return s;
        }

        public void UpdateBoard()
        {
            grid = new TypeGrid<CellType>(gridSize, gridSize, CellType.Empty);
            grid.SetCell(FoodPos, CellType.Food);
            grid.SetCell(snakePositions[0], CellType.Head);
            grid.SetCell(snakePositions[1], CellType.Neck);

            for (int i = 2; i < snakePositions.Count; i++)
            {
                grid.SetCell(snakePositions[i], CellType.Body);
            }
        }

        void GenerateFoodPos()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int x = random.Next(gridSize), y = random.Next(gridSize);
            if (grid[x, y].value != CellType.Empty)
                GenerateFoodPos();
            grid.SetCell(x, y, CellType.Food);
            FoodPos = new Point(x, y);
        }

        Direction ToDirection(Point dir)
        {
            int sum = Math.Abs(dir.X + dir.Y);
            if (sum == 0 || sum > 1)
                throw new ArgumentException();

            if (dir.X != 0)
            {
                if (dir.X == 1)
                {
                    return Direction.Right;
                }
                else
                {
                    return Direction.Left;
                }
            }
            else
            {
                if (dir.Y == 1)
                {
                    return Direction.Up;
                }
                else
                {
                    return Direction.Down;
                }
            }
        }

        Point ToPoint(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    return new Point(-1, 0);
                case Direction.Up:
                    return new Point(0, -1);
                case Direction.Right:
                    return new Point(1, 0);
                case Direction.Down:
                    return new Point(0, 1);
                default:
                    throw new ArgumentException();
            }
        }

        public enum Direction
        {
            Left,
            Up,
            Right,
            Down
        }

        public enum CellType
        {
            Empty,
            Food,
            Head,
            Neck,
            Body
        }
    }
}
