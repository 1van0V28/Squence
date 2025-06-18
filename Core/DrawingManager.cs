using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Squence.Core
{
    internal class DrawingManager(SpriteBatch spriteBatch, TextureStore textureStore)
    {
        private readonly SpriteBatch _spriteBatch = spriteBatch;
        private readonly TextureStore _textureStore = textureStore;

        // отрисовка сущностей, расположенных в EntityManager
        public void DrawEntities(EntityManager entityManager)
        {
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            DrawHero(entityManager);
            DrawBullets(entityManager);
            DrawEnemies(entityManager);
            _spriteBatch.End();
        }

        private void DrawHero(EntityManager entityManager)
        {
            _spriteBatch.Draw(
                _textureStore.Get(entityManager.Hero.TextureName),
                entityManager.Hero.TexturePosition,
                Color.White
                );
        }

        private void DrawBullets(EntityManager entityManager)
        {
            foreach (var bullet in entityManager.Bullets.Values)
            {
                _spriteBatch.Draw(
                    texture: _textureStore.Get(bullet.TextureName),
                    position: bullet.TexturePosition,
                    sourceRectangle: null,
                    color: Color.White,
                    rotation: bullet.Rotation, // поворачиваем пулю по направлению движения
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
                _spriteBatch.Draw(
                    _textureStore.Get(enemy.TextureName),
                    enemy.TexturePosition,
                    Color.White
                    );
            }
        }

        // отрисовка клеток, расположенных в TileMapManager
        public void DrawTileMap(TileMapManager tileMapManager)
        {
            var textures = tileMapManager.GetRenderables();

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            foreach (var texture in textures)
            {
                _spriteBatch.Draw(
                    texture: _textureStore.Get(texture.TextureName),
                    destinationRectangle: new Rectangle(
                            (int)(texture.TexturePosition.X * tileMapManager.TileMapDefinition.TileSize),
                            (int)(texture.TexturePosition.Y * tileMapManager.TileMapDefinition.TileSize),
                            tileMapManager.TileMapDefinition.TileSize,
                            tileMapManager.TileMapDefinition.TileSize
                            ),
                    Color.White);
            }
            _spriteBatch.End();
        }
    }
}
