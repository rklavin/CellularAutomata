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
    internal class CellularAutomataGame : Game
    {
        private GraphicsDeviceManager? graphics;
        private SpriteBatch? spriteBatch;

        private CellGrid? cellGrid;
        public static Camera? camera;

        public CellularAutomataGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GlobalAssets.Load(Content);

            //currentRoom = new Rooms.MazeRoom(Services);
            cellGrid = new CellGrid(GlobalAssets.Null, Vector2.Zero);
            cellGrid.initGrid(400, 200, 40, 40);

            camera = new Camera(GlobalAssets.Null, Vector2.Zero);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            Input.Update();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //currentRoom.Update(gameTime);

            cellGrid?.Update(gameTime);
            camera?.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics?.GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            //currentRoom.Draw(gameTime, spriteBatch);
            spriteBatch.Begin();
            cellGrid?.Draw(gameTime, spriteBatch);
            camera?.Draw(gameTime, spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
