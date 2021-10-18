using System;
using System.Threading;

namespace TheGameOfLife
{
    class Program
    {
        static Random random = new Random();

        const int cols = 100;
        const int rows = 30;

        static void Main(string[] args)
        {
            // make cursor invisable
            Console.CursorVisible = false;

            // init the starting grid
            string[,] grid = new string[cols, rows];

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    // generate a random number per x,y coord if the number 1 make the x,y coord alive, else the xy coord is dead
                    int rnd = random.Next(11);
                    if (rnd == 1) grid[x, y] = "█";
                    else grid[x, y] = " ";
                }
            }

            int genCount = 1;

            while (true)
            {
                // every 50 gens create some new live cells on random location to keep the sim going
                if (genCount % 5 == 0)
                {
                    for (int x = 0; x < cols; x++)
                    {
                        for (int y = 0; y < rows; y++)
                        {
                            int chance = random.Next(301);
                            if (chance == 1) grid[x, y] = "█";
                        }
                    }
                }

                // init the next gen
                string[,] nextGen = new string[cols, rows];

                for (int x = 0; x < cols; x++)
                {
                    for (int y = 0; y < rows; y++)
                    {
                        // count the surounding tiles
                        int liveNeihbors = countLiveNeihborTiles(grid, x, y);
                        string state = grid[x, y];

                        if (state == "█" && liveNeihbors == 2 || liveNeihbors == 3)
                        {
                            nextGen[x, y] = "█";
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (state == " " && liveNeihbors == 3)
                        {
                            nextGen[x, y] = "█";
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            nextGen[x, y] = " ";
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        
                        // draw the current grid/ gen
                        Console.SetCursorPosition(x, y);
                        Console.Write(grid[x, y]);
                    }
                }

                // set the grid to the next gen
                grid = nextGen;
                // increase gen count per gen
                genCount++;
                Thread.Sleep(50);
            }
        }

        static int countLiveNeihborTiles(string[,] grid, int x, int y)
        {
            int sum = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int c = (x + i + cols) % cols;
                    int r = (y + j + rows) % rows;
                    if (grid[c, r] == "█") sum++;
                }
            }

            if (grid[x, y] == "█") sum -= 1;
            return sum;
        }
    }
}
