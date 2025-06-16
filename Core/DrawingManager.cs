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
            var textures = entityManager.GetRenderables();

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            foreach (var texture in textures)
            {
                // поворачиваем пулю по направлению движения
                if (texture is Bullet)
                {
                    spriteBatch.Draw(
                        texture: textureStore.Get(texture.TextureName),
                        position: texture.TexturePosition,
                        sourceRectangle: null,
                        color: Color.White,
                        rotation: (texture as Bullet)._rotation,
                        origin: new Vector2(512, 512), // центр исходного спрайта
                        scale: 96f / 1024f,
                        effects: SpriteEffects.None,
                        layerDepth: 0f
                    );
                } else
                {
                    spriteBatch.Draw(
                        textureStore.Get(texture.TextureName),
                        texture.TexturePosition,
                        Color.White
                    );
                }
            }
            spriteBatch.End();
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
                            (int)(texture.TexturePosition.X * 64), // TODO сделать так, чтобы 64 приходило из параметров
                            (int)(texture.TexturePosition.Y * 64),
                            64,
                            64
                            ),
                    Color.White);
            }
            spriteBatch.End();
        }
    }
}
