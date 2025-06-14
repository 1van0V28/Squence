using Microsoft.Xna.Framework;
using Squence.Core;
using System;
using System.Collections.Generic;

namespace Squence.Entities
{
    internal class Enemy(List<Point> enemyPath, int tileSize): IRenderable, IUpdatable
    {
        public Guid Guid { get; } = Guid.NewGuid();
        public string TextureName { get; } = "Content/ball.png";
        public Vector2 TexturePosition { get => _texturePosition; }

        private Vector2 _texturePosition = new Vector2(enemyPath[0].X, enemyPath[0].Y) * tileSize;
        private int _currentTargetIndex = 1;
        public readonly float EnemySpeed = 100f;

        public void Update(GameTime gameTime)
        {
            // если враг пришёл к цели, то завершаем движение
            if (_currentTargetIndex >= enemyPath.Count)
            {
                return;
            }

            Vector2 target = new Vector2(enemyPath[_currentTargetIndex].X, enemyPath[_currentTargetIndex].Y) * tileSize;
            Vector2 direction = target - _texturePosition;
            float distanceToTarget = direction.Length();

            // если дистанция до цели минимальна, то переключаемся на следующую
            if (distanceToTarget < 0.1f)
            {
                _currentTargetIndex++;
                if (_currentTargetIndex >= enemyPath.Count)
                    return;
                target = new Vector2(enemyPath[_currentTargetIndex].X, enemyPath[_currentTargetIndex].Y) * tileSize;
                direction = target - _texturePosition;
                distanceToTarget = direction.Length();
            }

            direction.Normalize();
            float distanceToMove = EnemySpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // чтобы не перескочить точку
            if (distanceToMove > distanceToTarget)
                distanceToMove = distanceToTarget;

            _texturePosition += direction * distanceToMove;
        }
    }
}
