using Engine.Game;

namespace Engine.Rules
{
    internal class Overpopulation : IGameRule
    {
        public bool ExecuteRule(Grid grid, int x, int y)
        {
            var cell = grid.GetCell(x, y);

            if (cell.IsAlive)
            {
                var aliveNeighbours = grid.GetCellAliveNeighbours(cell);

                if (aliveNeighbours > 3)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
