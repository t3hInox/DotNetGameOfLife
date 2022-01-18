namespace Engine.Game
{
    internal class Cell
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public bool IsAlive { get; set; } = false;

        public Cell(int x, int y)
        {
            PosX = x;
            PosY = y;
        }
    }
}
