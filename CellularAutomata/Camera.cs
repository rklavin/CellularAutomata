using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace CellularAutomata
{
    internal class Camera : GameObject
    {
        private Point viewOrigin;
        private Point mouseOrigin;
        private Point mousePos;

        public float zoom;

        public Camera(Texture2D sprite, Vector2 position) : base(sprite, position)
        {
            zoom = 1f;
        }

        public override void Update(GameTime gameTime)
        {
            mousePos = Input.MouseCoordinates();

            if (Input.MouseLeftPressed())
            {
                mouseOrigin = Input.MouseCoordinates();
                viewOrigin = position.ToPoint();
            }

            if (Input.MouseLeftDown())
            {
                position.X = viewOrigin.X + (mousePos.X - mouseOrigin.X);
                position.Y = viewOrigin.Y + (mousePos.Y - mouseOrigin.Y);
            }

            if (Input.MouseWheelUp())
            {
                zoom += 0.05f;
            }

            if (Input.MouseWheelDown())
            {
                zoom -= 0.05f;
            }

            if (zoom <= 0.05f) zoom = 0.05f;

            base.Update(gameTime);
        }

        /*public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Vector2 pos = position;

            Rectangle rect = new Rectangle((int)pos.X, (int)pos.Y, 10, 10);

            boundingBox = rect;

            spriteBatch.Draw(sprite, pos, rect, Color.White);

            //base.Draw(gameTime, spriteBatch);
        }*/

        public void DrawSprite(GameTime gameTime, SpriteBatch spriteBatch, Texture2D sprite, Vector2 position, float scale)
        {
            Vector2 pos = this.position + (position * zoom);

            Rectangle rect = new Rectangle((int)pos.X, (int)pos.Y, (int)(sprite.Width * zoom * scale), (int)(sprite.Height * zoom * scale));

            spriteBatch.Draw(sprite, pos, rect, Color.White);
        }
    }
}
