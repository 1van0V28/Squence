using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Squence.Core;

namespace Squence
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        private EntityManager _entityManager;
        private TextureStore _textureStore;
        private SpriteBatch _spriteBatch;
        private DrawingManager _drawingManager;
        private InputManager _inputManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _entityManager = new EntityManager();
            _entityManager.InitStartEntities(GraphicsDevice);

            _textureStore = new TextureStore(GraphicsDevice);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _drawingManager = new DrawingManager(_spriteBatch, _textureStore);
            _inputManager = new InputManager(_entityManager.Hero);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            _inputManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _drawingManager.Draw(_entityManager.GetRenderables());

            base.Draw(gameTime);
        }
    }
}
