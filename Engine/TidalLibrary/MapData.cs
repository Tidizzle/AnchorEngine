namespace TidalLibrary
{
    public class MapData
    {
        public TileInfo[] Data;

        public int Width { get; set; }

        public int Height { get; set; }

        public int SquareHeight { get; set; }

        public int SquareWidth { get; set; }

        public MapData(int width, int height, int sqht, int sqwd)
        {
            Width = width;
            Height = height;
            SquareHeight = sqht;
            SquareWidth = sqwd;
            var rows = Height / sqht;
            var columns = Width / sqwd;
            var cells = rows * columns;
            Data = new TileInfo[cells];
        }

        public MapData()
        {
        }
    }
}