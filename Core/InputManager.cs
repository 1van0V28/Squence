using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Squence.Entities;

namespace Squence.Core
{
    // создаём новые сущности и обновляем параметры существующих
    internal class InputManager(EntityManager entityManager)
    {
        private bool _isMouseLeftPressed = false;
        public void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            var mouseState = Mouse.GetState();

            UpdateHero(gameTime, keyboardState);
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

            entityManager.MoveHero(direction, gameTime);
        }

        private void UpdateBullets(GameTime gameTime, MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed && !_isMouseLeftPressed)
            {
                var mousePosition = new Vector2(mouseState.X, mouseState.Y);
                var heroPosition = entityManager.Hero.TexturePosition;

                var direction = mousePosition - heroPosition;
                direction.Normalize();
                entityManager.AddBullet(new Bullet(heroPosition, direction, BulletType.Ice));

                _isMouseLeftPressed = true;
            }

            if (mouseState.LeftButton == ButtonState.Released)
            {
                _isMouseLeftPressed = false;
            }
        }
    }
}
