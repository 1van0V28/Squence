using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Squence.Data
{
    // данные окружения уровня
    internal record class TileMapDefinition(
        int tileSize,
        int width,
        int height,
        List<Point> RoadTiles, 
        List<Point> BuildZoneTiles,
        List<List<Point>> EnemyPathesList
    )
    {}
}
