using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Squence.Core
{
    internal class TextureStore(GraphicsDevice graphicsDevice)
    {
        private readonly Dictionary<string, Texture2D> _textures = [];

        // ленивая загрузка текстур
        public Texture2D Get(string textureName)
        {
            if (!_textures.ContainsKey(textureName))
            {
                // чтение изображения из файла
                using var stream = File.OpenRead(textureName);
                _textures[textureName] = Texture2D.FromStream(graphicsDevice, stream);
            }

            return _textures[textureName];
        }
    }
}
