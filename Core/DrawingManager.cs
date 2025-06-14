using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
                spriteBatch.Draw(
                    textureStore.Get(texture.TextureName),
                    texture.TexturePosition,
                    Color.White
                    );
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
                            (int)(texture.TexturePosition.X * 64),
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
