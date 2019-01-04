namespace MazeGen
{
    public class Maze
    {
        public int Width { get; }
        public int Height { get; }

        public Tile[,] Tiles { get; }

        public Maze(int width, int height)
        {
            Tiles = new Tile[height,width];
            Width = width;
            Height = height;

            for(int y=0; y < height; y++) {
                for(int x=0; x < width; x++) {
                    var tile = new Tile();
                    tile.Walls = TileWall.All;
                    tile.IsVisited = false;
                    Tiles[y,x] = tile;
                }
            }
        }
    }
}