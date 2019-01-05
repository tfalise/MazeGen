using System;
using System.Collections.Generic;

namespace MazeGen
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new MazeGenerator();
            var maze = generator.GenerateMaze(30,8);
            
            for (int y = 0; y < maze.Height*3; y++)
            {
                for (int x = 0; x < maze.Width*3; x+=3)
                {
                    int realY = y / 3;
                    int realX = x / 3;
                    int line = y % 3;

                    switch (line)
                    {
                        case 0:
                            Console.Write("▓");
                            if (maze.Tiles[realY, realX].HasAnyWall(TileWall.North)) { Console.Write("▓"); } else { Console.Write(" "); }
                            Console.Write("▓");
                            break;
                        case 1:
                            if (maze.Tiles[realY, realX].HasAnyWall(TileWall.West)) { Console.Write("▓"); } else { Console.Write(" "); }
                            Console.Write(" ");
                            if (maze.Tiles[realY, realX].HasAnyWall(TileWall.East)) { Console.Write("▓"); } else { Console.Write(" "); }
                            break;
                        case 2:
                            Console.Write("▓");
                            if (maze.Tiles[realY, realX].HasAnyWall(TileWall.South)) { Console.Write("▓"); } else { Console.Write(" "); }
                            Console.Write("▓");
                            break;
                    }
                    
                }
                Console.WriteLine();
            }


            //for(int y=0; y < maze.Height; y++) {
            //    for(int x=0; x < maze.Width; x++) {
            //        PrintTile(maze.Tiles[y,x]);
            //    }
            //    Console.WriteLine(String.Empty);
            //}

            Console.ReadLine();
        }

        private static readonly Dictionary<TileWall, string> WallDisplay = new Dictionary<TileWall, string>{
            [TileWall.None] = "╬",
            [TileWall.North] = "╦",
            [TileWall.East] = "╣",
            [TileWall.North | TileWall.East] = "╗",
            [TileWall.South] = "╩",
            [TileWall.South | TileWall.North] = "═",
            [TileWall.South | TileWall.East] = "╝",
            [TileWall.South | TileWall.North | TileWall.East] = "╡",
            [TileWall.West] = "╠",
            [TileWall.West | TileWall.North] = "╔",
            [TileWall.West | TileWall.East] = "║",
            [TileWall.West | TileWall.North | TileWall.East] = "╥",
            [TileWall.West | TileWall.South] = "╚",
            [TileWall.West | TileWall.South | TileWall.North] = "╞",
            [TileWall.West | TileWall.South | TileWall.East] = "╨",
            [TileWall.All] = " ",
        };

        private static void PrintTile(Tile tile)
        {
            Console.Write(WallDisplay[tile.Walls]);
        }
    }
}
