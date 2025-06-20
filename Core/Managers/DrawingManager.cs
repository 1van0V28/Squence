using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Squence.Core.Interfaces;
using Squence.Core.Services;
using System.Collections.Generic;

namespace Squence.Core.Managers
{
    internal class DrawingManager(SpriteBatch spriteBatch, TextureStore textureStore)
    {
        private readonly SpriteBatch _spriteBatch = spriteBatch;
        private readonly TextureStore _textureStore = textureStore;

        public void DrawRenderableEntities(IEnumerable<IRenderable> renderableEntities)
        {
            foreach (var renderableEntity in renderableEntities)
            {
                DrawRenderableEntity(renderableEntity);
            }
        }
        
        public void DrawRenderableEntity(IRenderable entity)
        {
            _spriteBatch.Draw(
                texture: _textureStore.Get(entity.TextureName),
                position: entity.TexturePosition,
                sourceRectangle: null,
                color: Color.White,
                rotation: entity.Rotation,
                origin: entity.Origin,
                scale: entity.Scale,
                effects: SpriteEffects.None,
                layerDepth: 0f
            );
        }
        
        public void DrawIconWithValue(Vector2 iconPosition, int iconSize, string iconName, string value)
        {
            Vector2 valuePosition = new (iconPosition.X + iconSize + 10, iconPosition.Y + 20);

            DrawIcon(iconPosition, iconSize, iconName);
            DrawBitmapText(value, valuePosition, Color.White);
        }

        public void DrawIcon(Vector2 iconPosition, int iconSize, string iconName)
        {
            _spriteBatch.Draw(
                texture: _textureStore.Get(iconName),
                destinationRectangle: new Rectangle(
                    (int)iconPosition.X,
                    (int)iconPosition.Y,
                    iconSize,
                    iconSize
                    ),
                Color.White
                );
        }

        public void DrawBitmapText(string text, Vector2 position, Color color)
        {
            foreach (var glyph in _textureStore.BitmapFont.GetGlyphs(text, position))
            {
                if (glyph.Character == null)
                {
                    continue;
                }
                var region = glyph.Character.TextureRegion;
                _spriteBatch.Draw(region.Texture, glyph.Position, region.Bounds, color);
            }
        }
    }
}
