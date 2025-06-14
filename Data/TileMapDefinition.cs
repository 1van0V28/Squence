using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Squence.Data
{
    // данные окружения уровня
    internal record class TileMapDefinition(
        int width,
        int height,
        List<Point> RoadTiles, 
        List<Point> BuildZoneTiles,
        List<List<Point>> EnemyPathesList
    )
    {
        public int width = width;
        public int height = height;
        public List<Point> RoadTiles = RoadTiles;
        public List<Point> BuildZoneTiles = BuildZoneTiles;
        public List<List<Point>> EnemyPathesList = EnemyPathesList;
    }
}
