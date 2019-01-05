using System;
using System.Linq;

namespace MazeGen {
    public class Tile {
        public TileWall Walls { get; set; }
        public bool IsVisited { get; set; }
        public int X { get; }
        public int Y { get; }
        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool HasWall(TileWall wall) {
            return (Walls & wall) == wall;
        }

        public bool HasAnyWall(params TileWall[] walls)
        {
            return walls.Any(w => HasWall(w));
        }
    }
}