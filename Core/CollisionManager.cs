using Microsoft.Xna.Framework;
using System;

namespace Squence.Core
{
    internal class CollisionManager(EntityManager entityManager)
    {
        public void Update()
        {
            HandleBulletEnemyCollisions();
        }

        private void HandleBulletEnemyCollisions()
        {
            foreach (var bullet in entityManager.Bullets.Values)
            {
                foreach (var enemy in entityManager.Enemies.Values)
                {
                    if (isColliding(bullet, enemy))
                    {
                        entityManager.RemoveBullet(bullet.Guid);
                        entityManager.HitEnemy(enemy.Guid);
                    }
                }
            }
        }

        private bool isColliding(ICollidable aEntity, ICollidable bEntity)
        {
            var posA = aEntity.Center;
            var posB = bEntity.Center;
            var radiusA = aEntity.Radius;
            var radiusB = bEntity.Radius;

            return Vector2.Distance(posA, posB) < (radiusA + radiusB);
        }
    }
}
