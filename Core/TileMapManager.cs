using Microsoft.Xna.Framework;
using Squence.Data;
using Squence.Entities;
using System.Collections.Generic;

namespace Squence.Core
{
    // обработка данных уровня
    internal class TileMapManager(TileMapDefinition tileMapDefinition)
    {
        private readonly Tile[,] _tiles = new Tile[tileMapDefinition.width, tileMapDefinition.height];
        private List<List<Vector2>> _enemyPath; // TODO путей несколько

        public void InitTileMap()
        {
            FillTiles(tileMapDefinition.RoadTiles, TileType.Road); // заполняем дороги
            FillTiles(tileMapDefinition.BuildZoneTiles, TileType.BuildZone); // заполняем зоны строительства

            // заполняем остальные пустые клетки травой
            for (var x = 0; x < tileMapDefinition.width; x++)
            {
                for (var y = 0; y < tileMapDefinition.height; y++)
                {
                    if (_tiles[x, y] == null)
                    {
                        _tiles[x, y] = new Tile(TileType.Grass, new Vector2(x, y));
                    }
                }
            }
        }

        private void FillTiles(List<Point> tilesList, TileType tileType)
        {
            foreach (var tile in tilesList)
            {
                _tiles[tile.X, tile.Y] = new Tile(tileType, new Vector2(tile.X, tile.Y));
            }
        }

        public IEnumerable<IRenderable> GetRenderables()
        {
            List<IRenderable> renderableTiles = [];

            for (var i = 0; i < tileMapDefinition.width; i++)
            {
                for (var j = 0; j < tileMapDefinition.height; j++)
                {
                    renderableTiles.Add(_tiles[i, j]);
                }
            }

            return renderableTiles;
        }
    }
}
