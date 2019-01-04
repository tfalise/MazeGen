using System;
using System.Collections.Generic;

namespace MazeGen
{
    internal class MazeGenerator : IMazeGenerator
    {
        public MazeGenerator()
        {
        }

        public Maze GenerateMaze(int width, int height)
        {
            var maze = new Maze(width, height);

            var rand = new Random();

            var startX = rand.Next(0, maze.Width);
            var startY = rand.Next(0, maze.Height);

            Dig(maze, startX, startY);

            return maze;
        }

        private void Dig(Maze maze, int x, int y)
        {
            if(maze.Tiles[y,x].IsVisited) 
                return;

            var currentTile = maze.Tiles[y,x];
            currentTile.IsVisited = true;

            if(y > 0 && !maze.Tiles[y-1, x].IsVisited && currentTile.HasWall(TileWall.North)) {
                currentTile.Walls -= TileWall.North;
                maze.Tiles[y-1, x].Walls -= TileWall.South;

                Dig(maze, x, y-1);
            }
            if(y < maze.Height - 1 && !maze.Tiles[y+1, x].IsVisited && currentTile.HasWall(TileWall.South)) {
                currentTile.Walls -= TileWall.South;
                maze.Tiles[y+1, x].Walls -= TileWall.North;

                Dig(maze, x, y+1);
            }
            if(x > 0 && !maze.Tiles[y, x-1].IsVisited && currentTile.HasWall(TileWall.West)) {
                currentTile.Walls -= TileWall.West;
                maze.Tiles[y, x-1].Walls -= TileWall.East;

                Dig(maze, x-1, y);
            }
            if(x < maze.Width - 1 && !maze.Tiles[y, x+1].IsVisited && currentTile.HasWall(TileWall.East)) {
                currentTile.Walls -= TileWall.East;
                maze.Tiles[y, x+1].Walls -= TileWall.West;

                Dig(maze, x+1, y);
            }
        }
    }

    internal interface IMazeGenerator
    {
        Maze GenerateMaze(int width, int height);
    }
}