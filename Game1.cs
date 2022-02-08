using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TestGame
{
    public class Game1 : Game
    {
        //Boilerplate
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        static MouseState mouseState;
        static MouseState oldMouseState;

        //Objects
        Ball ball1 = new Ball();
        Ball button1 = new Ball();
        Ball ball2 = new Ball();

        //Input

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ball1.position = new Vector2(0, 0);
            button1.position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            ball2.position = new Vector2(200, 0);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ball1.texture = Content.Load<Texture2D>("ball");
            ball2.texture = Content.Load<Texture2D>("ball");
            button1.texture = Content.Load<Texture2D>("pinkBox");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            // TODO: Add your update logic here
            mouseState = Mouse.GetState();

            button1.isPicked = button1.CheckIfPicked(mouseState, oldMouseState);
            ball2.isPicked = ball2.CheckIfPicked(mouseState, oldMouseState);
            ball1.isPicked = ball1.CheckIfPicked(mouseState, oldMouseState);

            if (button1.isPicked)
            { 
                button1.position = Methods.MoveWithMouse();
            }

            if (ball2.isPicked)
            {
                ball2.position = Methods.MoveWithMouse();
            }

            if (ball1.isPicked)
            {
                ball1.position = Methods.MoveWithMouse();
            }

            oldMouseState = mouseState;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LavenderBlush);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw
            (
                button1.texture, 
                button1.position, 
                null, 
                Color.White,
                0f,
                new Vector2(button1.texture.Width / 2, button1.texture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );
            _spriteBatch.Draw
            (
                ball2.texture,
                ball2.position,
                null,
                Color.White,
                0f,
                new Vector2(ball2.texture.Width / 2, ball2.texture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );
            _spriteBatch.Draw
            (
                ball1.texture,
                ball1.position,
                null,
                Color.White,
                0f,
                new Vector2(ball1.texture.Width / 2, ball1.texture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
