namespace TidalLibrary
{
    public class TileInfo
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Id { get; set; }

        public int Xmodifier { get; set; }

        public int Ymodifier { get; set; }

        public TileInfo(int xcoord, int ycoord, int colorId, int xmod, int ymod)
        {
            X = xcoord;
            Y = ycoord;
            Id = colorId;
            Xmodifier = xmod;
            Ymodifier = ymod;
        }

        public TileInfo()
        {
        }
    }
}