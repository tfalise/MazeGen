using System;

namespace MazeGen {
    public class Tile {
        public TileWall Walls { get; set; }
        public bool IsVisited { get; set; }
        public Tile()
        {
        }

        public bool HasWall(TileWall wall) {
            return (Walls & wall) == wall;
        }
    }
}