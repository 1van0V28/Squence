using Microsoft.Xna.Framework;
using Squence.Core;
using System;

namespace Squence.Entities
{
    public enum TileType
    {
        Grass,
        Road,
        BuildZone
    }

    internal class Tile(TileType tileType, Vector2 tilePosition): IRenderable
    {
        public TileType TileType = tileType;
        public Guid Guid { get; } = Guid.NewGuid();
        public string TextureName { get; } = GetTileTextureName(tileType);
        public Vector2 TexturePosition { get; private set; } = tilePosition;

        private static string GetTileTextureName(TileType tileType)
        {
            return tileType switch
            {
                TileType.Grass => "Content/tile_grass.png",
                TileType.Road => "Content/tile_road.png",
                TileType.BuildZone => "Content/tile_build_zone.png",
                _ => "Content/Grass_Middle.png",
            };
        }
    }
}
