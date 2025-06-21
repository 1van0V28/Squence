using Microsoft.Xna.Framework;

namespace Squence.Entities
{
    internal class TileBuildZone(Vector2 tilePosition, int tileSize): Tile(TileType.BuildZone, tilePosition, tileSize)
    {
        public BulletType BulletType { get; private set; } = BulletType.None;
        public int LevelBuilding { get; private set; } = 0;

        public void BuildZone(BulletType bulletType, int levelBuilding)
        {
            BulletType = bulletType;
            LevelBuilding = levelBuilding;
        }

        public void DestroyZone()
        {
            BulletType = BulletType.None;
            LevelBuilding = 0;
        }

        protected override string GetTileTextureName()
        {
            return BulletType switch
            {
                BulletType.None => "Content/Tiles/Building/tile_build_zone.png",
                BulletType.Fire => "Content/Tiles/Building/fire_zone.png",
                BulletType.Ice => "Content/tile_road.png", // заменить
                BulletType.Lightning => "Content/tile_build_zone.png", // заменить
                _ => "Content/Tiles/Building/tile_build_zone.png",
            };
        }
    }
}
