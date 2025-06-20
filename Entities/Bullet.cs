using Microsoft.Xna.Framework;
using Squence.Core.Interfaces;
using System;

namespace Squence.Entities
{
    enum BulletType
    {
        None,
        Fire,
        Ice,
        Lightning
    }

    internal class Bullet(Vector2 bulletPosition, Vector2 direction, BulletType bulletType) : IRenderable, IUpdatable, ICollidable
    {
        public Guid Guid { get; } = Guid.NewGuid();
        public string TextureName { get; } = GetBulletTextureName(bulletType);
        public Vector2 TexturePosition { get => _texturePosition; }
        private Vector2 _texturePosition = bulletPosition;
        public int TextureWidth { get; } = 64;
        public int TextureHeight { get; } = 64;
        public float Rotation { get => (float)Math.Atan2(direction.Y, direction.X) + MathF.PI / -2f; }
        public Vector2 Origin { get => new(1024f / 2f, 1024f / 2f); }
        public float Scale { get => TextureWidth / 1024f; }

        public Vector2 Center { get => new(_texturePosition.X + TextureWidth / 2, _texturePosition.Y + TextureHeight / 2); }
        public float Radius { get; } = 16;

        private readonly BulletType _bulletType = bulletType;
        private readonly float _bulletSpeed = 500f;

        private static string GetBulletTextureName(BulletType bulletType)
        {
            return bulletType switch
            {
                BulletType.Fire => "Content/Bullets/bullet_fire.png",
                BulletType.Ice => "Content/Bullets/bullet_ice.png",
                BulletType.Lightning => "Content/Bullets/bullet_lightning.png",
                _ => "Content/Bullets/bullet_fire.png"
            };
        }

        public void Update(GameTime gameTime)
        {
            Move(gameTime);
        }

        private void Move(GameTime gameTime)
        {
            var updatedHeroSpeed = _bulletSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _texturePosition += direction * updatedHeroSpeed;
        }
    }
}
