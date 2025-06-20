using Microsoft.Xna.Framework;

namespace Squence.Entities
{
    internal class TileBuildZone(Vector2 tilePosition, int tileSize): Tile(TileType.BuildZone, tilePosition, tileSize)
    {
        private BulletType _bulletType = BulletType.None;

        public void ChangeBulletType(BulletType bulletType)
        {
            _bulletType = bulletType;
        }

        protected override string GetTileTextureName()
        {
            return _bulletType switch
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
