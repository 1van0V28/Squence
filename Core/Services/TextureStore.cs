using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.BitmapFonts;
using MonoGame.Extended.Content.BitmapFonts;
using System.Collections.Generic;
using System.IO;

namespace Squence.Core.Services
{
    internal class TextureStore
    {
        public BitmapFont BitmapFont { get; private set; }
        private readonly GraphicsDevice _graphicsDevice;
        private readonly Dictionary<string, Texture2D> _textures = [];

        public TextureStore(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
            InitTextureStore(graphicsDevice);
        }

        private void InitTextureStore(GraphicsDevice graphicsDevice)
        {
            var fontFile = BitmapFontFileReader.Read("Content/Font/Nudge Orb.fnt");

            // Загрузка текстуры, которая используется в этом .fnt
            var fontTexture = Texture2D.FromFile(graphicsDevice, "Content/Font/Nudge Orb_0.png");

            // Преобразование CharacterBlock → BitmapFontCharacter
            var characters = new List<BitmapFontCharacter>();
            foreach (var c in fontFile.Characters)
            {
                var character = new BitmapFontCharacter(
                    (int)c.ID,                                       
                    new Texture2DRegion(fontTexture, c.X, c.Y, c.Width, c.Height),
                    c.XOffset,
                    c.YOffset,
                    c.XAdvance                                        
                );

                characters.Add(character);
            }

            // Создание BitmapFont вручную (используем Info.FontSize и Common.LineHeight)
            BitmapFont = new BitmapFont(
                fontFile.FontName ?? "Unknown",
                fontFile.Info.FontSize,
                fontFile.Common.LineHeight,
                characters
            );
        }

        // ленивая загрузка текстур
        public Texture2D Get(string textureName)
        {
            if (!_textures.ContainsKey(textureName))
            {
                // чтение изображения из файла
                using var stream = File.OpenRead(textureName);
                _textures[textureName] = Texture2D.FromStream(_graphicsDevice, stream);
            }

            return _textures[textureName];
        }
    }
}
