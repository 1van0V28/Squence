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
