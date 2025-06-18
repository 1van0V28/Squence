using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Squence.Entities;
using System;
using System.Collections.Generic;

namespace Squence.Core
{
    internal class EntityManager
    {
        public Hero Hero { get; private set; }
        public readonly Dictionary<Guid, Bullet> Bullets = [];
        public readonly Dictionary<Guid, Enemy> Enemies = [];

        private readonly GameState _gameState;

        // при создании происходит создание стартовых сущностей
        public EntityManager(GameState gameState, GraphicsDevice graphicsDevice)
        {
            _gameState = gameState;
            InitEntityManager(graphicsDevice);
        }

        public void InitEntityManager(GraphicsDevice graphicsDevice)
        {
            Hero = new Hero(graphicsDevice);
        }

        public void Update(GameTime gameTime)
        {
            UpdateBullets(gameTime);
            UpdateEnemies(gameTime);
        }

        private void UpdateBullets(GameTime gameTime)
        {
            foreach (var bullet in Bullets.Values)
            {
                bullet.Update(gameTime);
            }
        }

        private void UpdateEnemies(GameTime gameTime)
        {
            foreach (var enemy in Enemies.Values)
            {
                if (enemy.HealthPoints <= 0)
                {
                    RemoveEnemy(enemy.Guid);
                }
                else if (enemy.IsReachGoal) {
                    RemoveEnemy(enemy.Guid);
                    _gameState.HandleEnemyBreakthrough();
                }
                else
                {
                    enemy.Update(gameTime);
                } 
            }
        }

        public void AddBullet(Bullet bullet)
        {
            Bullets[bullet.Guid] = bullet;
        }

        public void AddEnemy(Enemy enemy)
        {
            Enemies[enemy.Guid] = enemy;
        }

        public void RemoveBullet(Guid guid)
        {
            Bullets.Remove(guid);
        }

        public void RemoveEnemy(Guid guid)
        {
            Enemies.Remove(guid);
        }

        public void MoveHero(Vector2 direction, GameTime gameTime)
        {
            if (direction != Vector2.Zero)
            {
                direction.Normalize();
                Hero.Move(direction, gameTime);
            }
        }

        // TODO учитывать тип атаки и тип врага
        public void HitEnemy(Guid guid)
        {
            Enemies[guid].Hit();
        }
    }
}
