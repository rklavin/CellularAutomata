using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CellularAutomata
{
    internal class Cell : GameObject
    {
        public int x;
        public int y;
        public int cellValue;

        public CellGrid? parentGrid;

        public Cell(Texture2D sprite, Vector2 position) : base(sprite, position)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Vector2 pos = position;

            Rectangle rect = new Rectangle((int)pos.X, (int)pos.Y, 1, 1);
            if (parentGrid != null)
            {
                rect.Width = parentGrid.cellWidth;
                rect.Height = parentGrid.cellHeight;
            }

            boundingBox = rect;

            //if (cellValue != 0)
                //spriteBatch.Draw(sprite, pos, rect, Color.White);

            if (cellValue != 0)
                CellularAutomataGame.camera?.DrawSprite(gameTime, spriteBatch, sprite, pos, rect.Width);

            //base.Draw(gameTime, spriteBatch);
        }
    }
}
