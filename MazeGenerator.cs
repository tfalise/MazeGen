using System;
using System.Linq;
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

            var shuffledNeighbours = GetAvailableNeighbours(maze, currentTile).OrderBy(t => Guid.NewGuid());

            foreach(var neighbour in shuffledNeighbours)
            {
                if (neighbour.IsVisited) continue;
                if(neighbour.X == currentTile.X)
                {
                    if(neighbour.Y > currentTile.Y)
                    {
                        currentTile.Walls -= TileWall.South;
                        neighbour.Walls -= TileWall.North;
                        Dig(maze, x, y + 1);
                    }
                    else
                    {
                        currentTile.Walls -= TileWall.North;
                        neighbour.Walls -= TileWall.South;
                        Dig(maze, x, y - 1);
                    }
                }
                else
                {
                    if (neighbour.X > currentTile.X)
                    {
                        currentTile.Walls -= TileWall.East;
                        neighbour.Walls -= TileWall.West;
                        Dig(maze, x + 1, y);
                    }
                    else
                    {
                        currentTile.Walls -= TileWall.West;
                        neighbour.Walls -= TileWall.East;
                        Dig(maze, x - 1, y);
                    }
                }
            }
        }

        private IList<Tile> GetAvailableNeighbours(Maze maze, Tile tile)
        {
            var neighbours = new List<Tile>();
            if (tile.X > 0 && !maze.Tiles[tile.Y, tile.X - 1].IsVisited) neighbours.Add(maze.Tiles[tile.Y, tile.X - 1]);
            if (tile.X < maze.Width - 1 && !maze.Tiles[tile.Y, tile.X + 1].IsVisited) neighbours.Add(maze.Tiles[tile.Y, tile.X + 1]);
            if (tile.Y > 0 && !maze.Tiles[tile.Y - 1, tile.X].IsVisited) neighbours.Add(maze.Tiles[tile.Y - 1, tile.X]);
            if (tile.Y < maze.Height - 1 && !maze.Tiles[tile.Y + 1, tile.X].IsVisited) neighbours.Add(maze.Tiles[tile.Y + 1, tile.X]);
            return neighbours;
        }
    }

    internal interface IMazeGenerator
    {
        Maze GenerateMaze(int width, int height);
    }
}