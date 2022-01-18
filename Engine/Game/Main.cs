namespace Engine.Game
{
    public class Main
    {
        private readonly Transitioner _transitioner = new Transitioner();
        private Grid _currentGrid = new Grid();

        public void StartGame(CancellationToken cancellationToken = default)
        {
            Seed(_currentGrid);

            while(!cancellationToken.IsCancellationRequested)
            {
                PrintGrid(_currentGrid = _transitioner.ExecuteNextCycle(_currentGrid));
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
            }
        }

        private void PrintGrid(Grid grid)
        {
            Console.Clear();

            for(var y = 0; y < Consts.GRID_MAX_Y; y++)
            {
                for(var x = 0; x < Consts.GRID_MAX_X; x++)
                {
                    var cell = grid.GetCell(x, y);
                    var symbol = cell.IsAlive ? "*" : " ";
                    Console.Write($" {symbol} ");
                }

                Console.WriteLine();
            }
        }

        private void Seed(Grid grid)
        {
            // Seeds glider
            var seedCells = new List<Cell>
            {
                _currentGrid.GetCell(0, 2),
                _currentGrid.GetCell(1, 3),
                _currentGrid.GetCell(2, 1),
                _currentGrid.GetCell(2, 2),
                _currentGrid.GetCell(2, 3)
            };

            foreach(var cell in seedCells)
            {
                cell.IsAlive = true;
            }
        }

    }
}
