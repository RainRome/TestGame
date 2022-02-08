using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestGame
{
    abstract class Methods
    {
        public static Vector2 MoveWithKeys(Vector2 position,  float speed, Texture2D texture, GameTime gameTime, GraphicsDeviceManager graphics)
        {
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
                position.Y -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Down))
                position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Left))
                position.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(kstate.IsKeyDown(Keys.Right))
                position.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(position.X > graphics.PreferredBackBufferWidth - texture.Width / 2)
                position.X = graphics.PreferredBackBufferWidth - texture.Width / 2;
            else if(position.X < texture.Width / 2)
                position.X = texture.Width / 2;

            if(position.Y > graphics.PreferredBackBufferHeight - texture.Height / 2)
                position.Y = graphics.PreferredBackBufferHeight - texture.Height / 2;
            else if(position.Y < texture.Height / 2)
                position.Y = texture.Height / 2;

            return position;
        }

        public static Vector2 MoveWithMouse()
        {
            Vector2 position = new Vector2();
            MouseState state = Mouse.GetState();

            position.X = state.X;
            position.Y = state.Y;

            return position;
        }

    }
}