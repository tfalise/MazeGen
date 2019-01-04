using System;

namespace MazeGen
{
    [Flags]
    public enum TileWall
    {
        None = 0,
        North = 1,
        East = 2,
        South = 4,
        West = 8,
        All = 15
    }
}