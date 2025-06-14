using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Squence.Core
{
    internal class DrawingManager(SpriteBatch spriteBatch, TextureStore textureStore)
    {
        // отрисовка текстур, расположенных в EntityManager
        public void Draw(IEnumerable<IRenderable> textures)
        {
            spriteBatch.Begin();
            foreach (var texture in textures)
            {
                spriteBatch.Draw(textureStore.Get(texture.TextureName), texture.TexturePosition, Color.White);
            }
            spriteBatch.End();
        }
    }
}
