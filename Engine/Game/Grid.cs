using Engine.Util;
using System.Text;

namespace Engine.Game
{
    internal class Grid
    {
        private Cell[,] grid;

        public Grid(Grid template)
        {
            grid = new Cell[Consts.GRID_MAX_X,Consts.GRID_MAX_Y];
        }

        public Grid()
        {
            grid = new Cell[Consts.GRID_MAX_X, Consts.GRID_MAX_Y];
            InitializeCells();
        }

        public int GetCellAliveNeighbours(Cell cell)
        {
            var neighbours = GetCellNeighbours(cell);
            return neighbours.Count(x => x.IsAlive);
        }

        public void CreateCell(bool isAlive, int x, int y)
        {
            var cell = new Cell(x, y);
            cell.IsAlive = isAlive;
            grid[x, y] = cell;
        }

        public Cell GetCell(int x, int y)
        {
            if (x >= Consts.GRID_MAX_X)
                x = 0;
            else if(x < 0)
                x = Consts.GRID_MAX_X - 1;

            if (y >= Consts.GRID_MAX_Y)
                y = 0;
            else if (y < 0)
                y = Consts.GRID_MAX_Y - 1;

            return grid[x, y];
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            GridHelper.Iterate((x, y) => 
            {
                var symbol = GetCell(x, y).IsAlive ? "*" : " ";
                sb.Append(symbol);

                if (x >= Consts.GRID_MAX_X - 1)
                {
                    sb.Append(Environment.NewLine);
                }
            });

            return sb.ToString();
        }

        private void InitializeCells()
        {
            GridHelper.Iterate((x, y) => 
            {
                grid[x, y] = new Cell(x, y);
            });
        }

        private IEnumerable<Cell> GetCellNeighbours(Cell cell)
        {
            var cellX = cell.PosX;
            var cellY = cell.PosY;

            var top = GetCell(cellX, cellY + 1);
            var bottom = GetCell(cellX, cellY - 1);

            var left = GetCell(cellX - 1, cellY);
            var right = GetCell(cellX + 1, cellY);

            var topRight = GetCell(cellX + 1, cellY + 1);
            var topLeft = GetCell(cellX - 1, cellY + 1);

            var bottomRight = GetCell(cellX + 1, cellY - 1);
            var bottomLeft = GetCell(cellX - 1, cellY - 1);

            return new List<Cell>(6)
            {
                top, bottom, left, right, topRight, topLeft, bottomRight, bottomLeft
            };
        }
    }
}
