using Engine.Game;

namespace Engine.Rules
{
    internal class Underpopulation : IGameRule
    {
        public bool ExecuteRule(Grid grid, int x, int y)
        {
            var cell = grid.GetCell(x, y);

            if (cell.IsAlive)
            {
                var aliveNeighbours = grid.GetCellAliveNeighbours(cell);

                if(aliveNeighbours < 2)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
