using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Squence.Entities;

namespace Squence.Core
{
    // создаём новые сущности и обновляем параметры существующих
    internal class InputManager(Hero hero)
    {
        public void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            UpdateHero(gameTime, keyboardState);
        }

        private void UpdateHero(GameTime gameTime, KeyboardState keyboardState)
        {
            var updatedHeroSpeed = hero.HeroSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            MoveHero(keyboardState, updatedHeroSpeed);
        }

        private void MoveHero(KeyboardState keyboardState, float updatedHeroSpeed)
        {
            if (keyboardState.IsKeyDown(Keys.W)) 
            {
                hero.MoveUp(updatedHeroSpeed);
            } 

            if (keyboardState.IsKeyDown(Keys.S))
            {
                hero.MoveDown(updatedHeroSpeed);
            }

            if (keyboardState.IsKeyDown(Keys.A))
            {
                hero.MoveLeft(updatedHeroSpeed);
            }

            if (keyboardState.IsKeyDown(Keys.D))
            {
                hero.MoveRight(updatedHeroSpeed);
            }
        }
    }
}
