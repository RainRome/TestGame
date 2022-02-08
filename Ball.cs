using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestGame
{
    class Ball
    {
        public Texture2D texture;
        public Vector2 position;
        public bool isPicked;

        public bool MouseIsInBounds()
        {
            MouseState state = Mouse.GetState();
            if (
                state.X >= this.position.X - this.texture.Width &&
                state.X <= this.position.X + this.texture.Width &&
                state.Y >= this.position.Y - this.texture.Height &&
                state.Y <= this.position.Y + this.texture.Height )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckIfPicked(MouseState mouseState, MouseState oldMouseState)
        {
            if (oldMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released && this.MouseIsInBounds())
            {
                this.isPicked = !this.isPicked;
            }
            return this.isPicked;
        }
    }
}