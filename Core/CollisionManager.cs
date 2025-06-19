using Microsoft.Xna.Framework;

namespace Squence.Core
{
    internal class CollisionManager(EntityManager entityManager, GameState gameState)
    {
        private readonly EntityManager _entityManager = entityManager;
        private readonly GameState _gameState = gameState;

        public void Update()
        {
            HandleBulletEnemyCollisions();
            HandleHeroCoinCollisions();
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

        private void HandleHeroCoinCollisions()
        {
            foreach (var coin in _entityManager.Coins.Values)
            {
                if (IsRadiusColliding(_entityManager.Hero, coin))
                {
                    _entityManager.RemoveCoin(coin.Guid);
                    _gameState.HandleCoinCollection();
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
