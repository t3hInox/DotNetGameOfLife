using Engine.Game;

namespace Engine.Rules
{
    internal class Survive : IGameRule
    {
        public bool ExecuteRule(Grid grid, int x, int y)
        {
            var cell = grid.GetCell(x, y);

            if (cell.IsAlive)
            {
                var aliveNeighbours = grid.GetCellAliveNeighbours(cell);

                if (new[] { 2, 3 }.Contains(aliveNeighbours))
                {
                    return false;
                }
            }

            return false;
        }
    }
}
