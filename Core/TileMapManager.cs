using Microsoft.Xna.Framework;
using Squence.Data;
using Squence.Entities;
using System.Collections.Generic;

namespace Squence.Core
{
    // обработка данных уровня
    internal class TileMapManager
    {
        public TileMapDefinition TileMapDefinition { get; private set; }
        private readonly Tile[,] _tiles;

        public TileMapManager(TileMapDefinition tileMapDefinition)
        {
            TileMapDefinition = tileMapDefinition;
            _tiles = new Tile[tileMapDefinition.Width, tileMapDefinition.Height];

            InitTileMap(tileMapDefinition);
        }

        public void InitTileMap(TileMapDefinition tileMapDefinition)
        {
            FillTiles(tileMapDefinition.RoadTiles, TileType.Road, tileMapDefinition); // заполняем дороги
            FillTiles(tileMapDefinition.BuildZoneTiles, TileType.BuildZone, tileMapDefinition); // заполняем зоны строительства

            // заполняем остальные пустые клетки травой
            for (var x = 0; x < tileMapDefinition.Width; x++)
            {
                for (var y = 0; y < tileMapDefinition.Height; y++)
                {
                    if (_tiles[x, y] == null)
                    {
                        _tiles[x, y] = new Tile(TileType.Grass, new Vector2(x, y), tileMapDefinition.TileSize);
                    }
                }
            }
        }

        private void FillTiles(List<Point> tilesList, TileType tileType, TileMapDefinition tileMapDefinition)
        {
            foreach (var tile in tilesList)
            {
                _tiles[tile.X, tile.Y] = new Tile(tileType, new Vector2(tile.X, tile.Y), tileMapDefinition.TileSize);
            }
        }

        public IEnumerable<IRenderable> GetRenderables()
        {
            List<IRenderable> renderableTiles = [];

            for (var i = 0; i < _tiles.GetLength(0); i++)
            {
                for (var j = 0; j < _tiles.GetLength(1); j++)
                {
                    renderableTiles.Add(_tiles[i, j]);
                }
            }

            return renderableTiles;
        }
    }
}
