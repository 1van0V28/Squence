using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Squence.Core;
using System;


namespace Squence.Entities
{
    internal class Hero(GraphicsDevice graphicsDevice) : IRenderable
    {
        public Guid Guid { get; } = Guid.NewGuid();
        public string TextureName { get; } = "Content/ball.png";
        public Vector2 TexturePosition { get => _texturePosition; }

        private Vector2 _texturePosition = new(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2);
        public readonly float HeroSpeed = 100f;

        public void MoveUp(float updatedHeroSpeed)
        {
            _texturePosition.Y -= updatedHeroSpeed;
        }
        public void MoveDown(float updatedHeroSpeed)
        {
            _texturePosition.Y += updatedHeroSpeed;
        }

        public void MoveLeft(float updatedHeroSpeed)
        {
            _texturePosition.X -= updatedHeroSpeed;
        }

        public void MoveRight(float updatedHeroSpeed)
        {
            _texturePosition.X += updatedHeroSpeed;
        }
    }
}
