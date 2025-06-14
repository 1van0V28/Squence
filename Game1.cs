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
        private readonly int _tileSize = 64;
        private readonly TileMapDefinition _tileMapDefinition = LevelMap.GetTileMapDefinition();

        private GraphicsDeviceManager _graphics;

        private EntityManager _entityManager;
        private TextureStore _textureStore;
        private SpriteBatch _spriteBatch;
        private DrawingManager _drawingManager;
        private InputManager _inputManager;
        private TileMapManager _tileMapManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = _tileMapDefinition.width * _tileSize;
            _graphics.PreferredBackBufferHeight = _tileMapDefinition.height * _tileSize;
            _graphics.ApplyChanges();
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

            _tileMapManager = new TileMapManager(_tileMapDefinition);
            _tileMapManager.InitTileMap();

            // тестирование передвижение врага
            var enemyPath = _tileMapDefinition.EnemyPathesList[0];
            _entityManager.AddEntity(new Enemy(_tileMapDefinition.EnemyPathesList[0], _tileSize));

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
