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
        private readonly Dictionary<Guid, IRenderable> _entities = [];

        public void InitStartEntities(GraphicsDevice graphicsDevice)
        {
            Hero = new Hero(graphicsDevice);
            _entities.Add(Hero.Guid, Hero);
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
    }
}
