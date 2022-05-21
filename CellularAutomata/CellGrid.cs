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
    internal class CellGrid : GameObject
    {
        public int width = 1;
        public int height = 1;
        public int cellWidth = 1;
        public int cellHeight = 1;

        public Cell[][] grid;
        public Cell[][] nextGrid;

        private int keyDelay;
        private const int maxKeyDelay = 4;

        public CellGrid(Texture2D sprite, Vector2 position) : base(sprite, position)
        {
            grid = new Cell[width][];
            nextGrid = new Cell[width][];
            for (int i = 0; i < width; i++)
            {
                grid[i] = new Cell[height];
                nextGrid[i] = new Cell[height];
            }
        }

        public void initGrid(int width, int height, int cellWidth, int cellHeight)
        {
            Random random = new Random();

            this.width = width;
            this.height = height;
            this.cellWidth = cellWidth;
            this.cellHeight = cellHeight;

            grid = new Cell[width][];
            nextGrid = new Cell[width][];
            for (int i = 0; i < width; i++)
            {
                grid[i] = new Cell[height];
                nextGrid[i] = new Cell[height];
                for (int j = 0; j < height; j++)
                {
                    grid[i][j] = new Cell(GlobalAssets.Dot, new Vector2(i * cellWidth, j * cellHeight));
                    nextGrid[i][j] = new Cell(GlobalAssets.Dot, new Vector2(i * cellWidth, j * cellHeight));
                    grid[i][j].cellValue = random.Next(2) == 0 ? 1 : 0;
                    nextGrid[i][j].cellValue = grid[i][j].cellValue;
                    grid[i][j].parentGrid = this;
                    nextGrid[i][j].parentGrid = this;
                    grid[i][j].x = i;
                    nextGrid[i][j].x = i;
                    grid[i][j].y = j;
                    nextGrid[i][j].y = j;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            Random random = new Random();

            if (keyDelay > 0) keyDelay -= 1;

            if (Input.KeyDown(Keys.Space) && (keyDelay == 0))
            {
                keyDelay = maxKeyDelay;

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        int neighbors = countNeighbors(i, j);
                        nextGrid[i][j].cellValue = grid[i][j].cellValue;
                        if (neighbors < 2) nextGrid[i][j].cellValue = 0;
                        if (neighbors == 3) nextGrid[i][j].cellValue = 1;
                        if (neighbors > 3) nextGrid[i][j].cellValue = 0;

                        /*if ((grid[i][j].cellValue == 0) && (nextGrid[i][j].cellValue == 0))
                        {
                            nextGrid[i][j].cellValue = random.Next(2000) == 0 ? 1 : 0;
                        }*/
                    }
                }

                Cell[][] temp = grid;
                grid = nextGrid;
                nextGrid = temp;
                //swapGrids(ref grid, ref nextGrid);
            }

            base.Update(gameTime);
        }

        public int countNeighbors(int x, int y)
        {
            int left = x == 0 ? width - 1 : x - 1;
            int right = x == width - 1 ? 0 : x + 1;
            int up = y == 0 ? height - 1 : y - 1;
            int down = y == height - 1 ? 0 : y + 1;

            int count = grid[left][up].cellValue   + grid[x][up].cellValue   + grid[right][up].cellValue
                      + grid[left][y].cellValue    + 0                       + grid[right][y].cellValue
                      + grid[left][down].cellValue + grid[x][down].cellValue + grid[right][down].cellValue;

            return count;
        }

        public static void swapGrids(ref Cell[][] grid1, ref Cell[][] grid2)
        {
            Cell[][] temp = grid1;
            grid1 = grid2;
            grid2 = temp;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    grid[i][j].Draw(gameTime, spriteBatch);
                }
            }

            base.Draw(gameTime, spriteBatch);
        }

        public static Cell[][] copy(Cell[][] grid)
        {
            Cell[][] cells = new Cell[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                cells[i] = new Cell[grid[i].Length];
                for (int j = 0; j < grid[i].Length; j++)
                {
                    cells[i][j] = new Cell(grid[i][j].sprite, grid[i][j].position);
                    cells[i][j].cellValue = grid[i][j].cellValue;
                    cells[i][j].x = grid[i][j].x;
                    cells[i][j].y = grid[i][j].y;
                    cells[i][j].parentGrid = grid[i][j].parentGrid;
                }
            }

            return cells;
        }
    }
}
