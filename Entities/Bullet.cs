using Microsoft.Xna.Framework;
using Squence.Core;
using System;

namespace Squence.Entities
{
    enum BulletType
    {
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
        public int TextureWidth { get; } = 96;
        public int TextureHeight { get; } = 96;
       
        public Vector2 Center { get => new(_texturePosition.X + 96 / 2, _texturePosition.Y + 96 / 2); }
        public float Radius { get; } = 96 / 2;

        private readonly BulletType _bulletType = bulletType;
        private readonly float _bulletSpeed = 500f;
        public readonly float Rotation = (float)Math.Atan2(direction.Y, direction.X) + MathF.PI / -2f;

        private static string GetBulletTextureName(BulletType bulletType)
        {
            return bulletType switch
            {
                BulletType.Fire => "Content/bullet_fire.png",
                BulletType.Ice => "Content/bullet_ice.png",
                BulletType.Lightning => "Content/bullet_lightning.png",
                _ => "Content/bullet_fire.png"
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
