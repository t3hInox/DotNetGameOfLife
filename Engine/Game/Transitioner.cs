using Engine.Rules;
using Engine.Util;

namespace Engine.Game
{
    internal class Transitioner
    {
        private List<IGameRule> _rules;

        public Transitioner()
        {
            _rules = new List<IGameRule> 
            { 
                new Underpopulation(),
                new Overpopulation(),
                new Reproduction(),
                new Survive()
            };
        }

        public Grid ExecuteNextCycle(Grid currentState)
        {
            var nextState = new Grid(currentState);
            CreateNextState(currentState, nextState);
            return nextState;
        }

        private void CreateNextState(Grid currentState, Grid nextState)
        {
            GridHelper.Iterate((x, y) => 
            {
                var processedCell = currentState.GetCell(x, y);
                var cellStateChanged = false;
                foreach (var rule in _rules)
                {
                    cellStateChanged = rule.ExecuteRule(currentState, x, y);

                    if (cellStateChanged)
                    {
                        break;
                    }
                }

                var willBeAlive = false;

                if(cellStateChanged)
                {
                    willBeAlive = !processedCell.IsAlive;
                }
                else
                {
                    willBeAlive = processedCell.IsAlive;
                }

                nextState.CreateCell(willBeAlive, x, y);
            });
        }
    }
}
