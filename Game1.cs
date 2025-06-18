using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Squence.Core;
using Squence.Data;
using Squence.Entities;

namespace Squence
{
    public class Game1 : Game
    {
        private readonly TileMapDefinition _tileMapDefinition = LevelMap.GetTileMapDefinition();

        private readonly GraphicsDeviceManager _graphics;

        private EntityManager _entityManager;
        private TextureStore _textureStore;
        private SpriteBatch _spriteBatch;
        private DrawingManager _drawingManager;
        private InputManager _inputManager;
        private TileMapManager _tileMapManager;
        private CollisionManager _collisionManager;
        private WaveManager _waveManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = _tileMapDefinition.Width * _tileMapDefinition.TileSize;
            _graphics.PreferredBackBufferHeight = _tileMapDefinition.Height * _tileMapDefinition.TileSize;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _entityManager = new EntityManager(GraphicsDevice);
            _textureStore = new TextureStore(GraphicsDevice);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _drawingManager = new DrawingManager(_spriteBatch, _textureStore);
            _inputManager = new InputManager(_entityManager);
            _tileMapManager = new TileMapManager(_tileMapDefinition);
            _collisionManager = new CollisionManager(_entityManager);
            _waveManager = new WaveManager(_entityManager, _tileMapDefinition.WavesList);

            // тестирование передвижение врага
            _entityManager.AddEnemy(new Enemy(_tileMapDefinition.EnemyPathesList[0], _tileMapDefinition.TileSize));

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
            _entityManager.Update(gameTime);
            _collisionManager.Update();
            _waveManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _drawingManager.DrawTileMap(_tileMapManager);
            _drawingManager.DrawEntities(_entityManager);
            
            base.Draw(gameTime);
        }
    }
}
