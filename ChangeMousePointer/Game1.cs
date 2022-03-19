using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChangeMousePointer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _mouseHand;
        private Texture2D _goblin;
        private Vector2 _goblinCoordinates;
        private int _goblinLength;
        private bool _handVisible;
        private MouseState _mouseState;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _goblinCoordinates = new Vector2(300, 300);
            _goblinLength = 72;
            _handVisible = false;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _mouseHand = Content.Load<Texture2D>("mouseCursor");
            _goblin = Content.Load<Texture2D>("Goblin2");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _mouseState = Mouse.GetState();
            HandleInput();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(SpriteSortMode.FrontToBack);
            _spriteBatch.Draw(_goblin, _goblinCoordinates, null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.1f);

            if (_handVisible)
                _spriteBatch.Draw(_mouseHand, new Vector2(_mouseState.X, _mouseState.Y), null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 1.0f);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void HandleInput()
        {
            if (_mouseState.X >= _goblinCoordinates.X && _mouseState.X < _goblinCoordinates.X + _goblinLength
                && _mouseState.Y >= _goblinCoordinates.Y && _mouseState.Y < _goblinCoordinates.Y + _goblinLength)
            {
                _handVisible = true;
                IsMouseVisible = false;
            }

            else
            {
                _handVisible = false;
                IsMouseVisible = true;
            }
        }
    }
}
