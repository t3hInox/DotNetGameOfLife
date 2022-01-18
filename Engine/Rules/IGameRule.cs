using Engine.Game;

namespace Engine.Rules
{
    internal interface IGameRule
    {
        bool ExecuteRule(Grid grid, int x, int y);
    }
}
