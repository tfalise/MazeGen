using System;
using System.Collections.Generic;

namespace MazeGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var generator = new MazeGenerator();
            var maze = generator.GenerateMaze(10,10);

            for(int y=0; y < maze.Height; y++) {
                for(int x=0; x < maze.Width; x++) {
                    PrintTile(maze.Tiles[y,x]);
                }
                Console.WriteLine(String.Empty);
            }
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
