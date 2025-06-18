using Microsoft.Xna.Framework;

namespace Squence.Core
{
    internal class CollisionManager(EntityManager entityManager)
    {
        private readonly EntityManager _entityManager = entityManager;
        public void Update()
        {
            HandleBulletEnemyCollisions();
        }

        private void HandleBulletEnemyCollisions()
        {
            foreach (var bullet in _entityManager.Bullets.Values)
            {
                foreach (var enemy in _entityManager.Enemies.Values)
                {
                    if (IsRadiusColliding(bullet, enemy))
                    {
                        _entityManager.RemoveBullet(bullet.Guid);
                        _entityManager.HitEnemy(enemy.Guid);
                    }
                }
            }
        }

        private static bool IsRadiusColliding(ICollidable aEntity, ICollidable bEntity)
        {
            var posA = aEntity.Center;
            var posB = bEntity.Center;
            var radiusA = aEntity.Radius;
            var radiusB = bEntity.Radius;

            return Vector2.Distance(posA, posB) < (radiusA + radiusB);
        }
    }
}
