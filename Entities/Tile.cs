using Microsoft.Xna.Framework;
using Squence.Core.Interfaces;
using System;

namespace Squence.Entities
{
    public enum TileType
    {
        Grass,
        Road,
        BuildZone,
    }

    internal class Tile(TileType tileType, Vector2 tilePosition, int tileSize): IRenderable
    {
        private readonly TileType _tileType = tileType;
        public Guid Guid { get; } = Guid.NewGuid();
        public string TextureName { get => GetTileTextureName(); }
        public Vector2 TexturePosition { get; private set; } = tilePosition;
        public int TextureWidth { get; } = tileSize;
        public int TextureHeight { get; } = tileSize;
        public float Scale { get => TextureWidth / 972f; }

        protected virtual string GetTileTextureName()
        {
            return _tileType switch
            {
                TileType.Grass => "Content/Tiles/tile_grass.png",
                TileType.Road => "Content/Tiles/tile_road.png",
                TileType.BuildZone => "Content/Tiles/tile_build_zone.png",
                _ => "Content/Tiles/Grass_Middle.png",
            };
        }
    }
}
