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
        private readonly float _heroSpeed = 100f;

        public void Move(Vector2 direction, GameTime gameTime)
        {
            var updatedHeroSpeed = _heroSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _texturePosition += direction * updatedHeroSpeed;
        }
    }
}
