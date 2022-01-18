using Engine.Game;

namespace Engine.Util
{
    internal static class GridHelper
    {
        public static void Iterate(Action<int, int> action)
        {
            for(var y = 0; y < Consts.GRID_MAX_Y; y++)
            {
                for(var x = 0; x < Consts.GRID_MAX_X; x++)
                {
                    action(x, y);
                }
            }
        }
    }
}
