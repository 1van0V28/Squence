using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Squence.Entities;

namespace Squence.Core
{
    internal class DrawingManager(SpriteBatch spriteBatch, TextureStore textureStore)
    {
        // отрисовка сущностей, расположенных в EntityManager
        public void DrawEntities(EntityManager entityManager)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            DrawHero(entityManager);
            DrawBullets(entityManager);
            DrawEnemies(entityManager);
            spriteBatch.End();
        }

        private void DrawHero(EntityManager entityManager)
        {
            spriteBatch.Draw(
                textureStore.Get(entityManager.Hero.TextureName),
                entityManager.Hero.TexturePosition,
                Color.White
                );
        }

        private void DrawBullets(EntityManager entityManager)
        {
            foreach (var bullet in entityManager.Bullets.Values)
            {
                spriteBatch.Draw(
                    texture: textureStore.Get(bullet.TextureName),
                    position: bullet.TexturePosition,
                    sourceRectangle: null,
                    color: Color.White,
                    rotation: (bullet as Bullet).Rotation, // поворачиваем пулю по направлению движения
                    origin: new Vector2(1024f / 2f, 1024f / 2f), // центр исходного спрайта
                    scale: bullet.TextureWidth / 1024f,
                    effects: SpriteEffects.None,
                    layerDepth: 0f
                    );
            }
        }

        private void DrawEnemies(EntityManager entityManager)
        {
            foreach (var enemy in entityManager.Enemies.Values)
            {
                spriteBatch.Draw(
                    textureStore.Get(enemy.TextureName),
                    enemy.TexturePosition,
                    Color.White
                    );
            }
        }

        // отрисовка клеток, расположенных в TileMapManager
        public void DrawTileMap(TileMapManager tileMapManager)
        {
            var textures = tileMapManager.GetRenderables();

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            foreach (var texture in textures)
            {
                spriteBatch.Draw(
                    texture: textureStore.Get(texture.TextureName),
                    destinationRectangle: new Rectangle(
                            (int)(texture.TexturePosition.X * tileMapManager.TileMapDefinition.tileSize),
                            (int)(texture.TexturePosition.Y * tileMapManager.TileMapDefinition.tileSize),
                            tileMapManager.TileMapDefinition.tileSize,
                            tileMapManager.TileMapDefinition.tileSize
                            ),
                    Color.White);
            }
            spriteBatch.End();
        }
    }
}
