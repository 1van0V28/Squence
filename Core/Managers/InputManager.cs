using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Squence.Core.Interfaces;
using Squence.Entities;

namespace Squence.Core.Managers
{
    // создаём новые сущности и обновляем параметры существующих
    internal class InputManager(EntityManager entityManager, BuildingManager buildingManager): IUpdatable
    {
        private readonly EntityManager _entityManager = entityManager;
        private readonly BuildingManager _buildingManager = buildingManager;

        private bool _isMouseLeftBulletPressed = false;
        private bool _isMouseLeftBuildingPressed = false;

        public void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            var mouseState = Mouse.GetState();

            UpdateHero(gameTime, keyboardState);
            UpdateBuilding(mouseState);
            UpdateBullets(gameTime, mouseState);
        }

        private void UpdateHero(GameTime gameTime, KeyboardState keyboardState)
        {
            MoveHero(gameTime, keyboardState);
        }

        private void MoveHero(GameTime gameTime, KeyboardState keyboardState)
        {
            var direction = Vector2.Zero;

            if (keyboardState.IsKeyDown(Keys.W)) 
            {
                direction.Y -= 1;
            } 
            if (keyboardState.IsKeyDown(Keys.S))
            {
                direction.Y += 1;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                direction.X -= 1;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                direction.X += 1;
            }

            _entityManager.MoveHero(direction, gameTime);
        }

        private void UpdateBullets(GameTime gameTime, MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed && !_isMouseLeftBulletPressed)
            {
                // TODO поместить вычисление направления движения в static-метод Bullet
                var mousePosition = new Vector2(mouseState.X, mouseState.Y);
                var heroPosition = _entityManager.Hero.TexturePosition;

                var direction = mousePosition - heroPosition;
                direction.Normalize();
                _entityManager.AddBullet(new Bullet(heroPosition, direction, BulletType.Ice));

                _isMouseLeftBulletPressed = true;
            }

            if (mouseState.LeftButton == ButtonState.Released)
            {
                _isMouseLeftBulletPressed = false;
            }
        }

        private void UpdateBuilding(MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed && !_isMouseLeftBuildingPressed)
            {
                _buildingManager.TryHandleTileClick(mouseState);
                _buildingManager.TryHandleUIClick(mouseState);
                _isMouseLeftBuildingPressed = true;
            }

            if (mouseState.LeftButton == ButtonState.Released)
            {
                _isMouseLeftBuildingPressed = false;
            }
        }
    }
}
