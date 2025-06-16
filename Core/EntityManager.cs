using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Squence.Entities;
using System;
using System.Collections.Generic;

namespace Squence.Core
{
    internal class EntityManager
    {
        private Hero _hero;
        private readonly Dictionary<Guid, IRenderable> _entities = [];

        // при создании происходит создание стартовых сущностей
        public EntityManager(GraphicsDevice graphicsDevice)
        {
            InitEntityManager(graphicsDevice);
        }

        public void InitEntityManager(GraphicsDevice graphicsDevice)
        {
            _hero = new Hero(graphicsDevice);
            _entities.Add(_hero.Guid, _hero);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var entity in _entities)
            {
                if (entity.Value is IUpdatable updateable)
                {
                    updateable.Update(gameTime);
                }
            }
        }

        public void AddEntity(IRenderable entity)
        {
            _entities[entity.Guid] = entity;
        }

        public void RemoveEntity(Guid guid)
        {
            _entities.Remove(guid);
        }

        public IEnumerable<IRenderable> GetRenderables()
        {
            return _entities.Values;
        }

        public void MoveHero(Vector2 direction, GameTime gameTime)
        {
            if (direction != Vector2.Zero)
            {
                direction.Normalize();
                _hero.Move(direction, gameTime);
            }
        }

        public Vector2 GetHeroPosition()
        {
            return _hero.TexturePosition;
        }
    }
}
