namespace TidalLibrary
{
    public class Color
    {
        private string _colorName;

        public string ColorName
        {
            get { return _colorName; }
            set { _colorName = value; }
        }

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _r;

        public int R
        {
            get { return _r; }
            set { _r = value; }
        }

        private int _g;

        public int G
        {
            get { return _g; }
            set { _g = value; }
        }

        private int _b;

        public int B
        {
            get { return _b; }
            set { _b = value; }
        }

        private int _a;

        public int A
        {
            get { return _a; }
            set { _a = value; }
        }

        public Color(string name, int id, int r, int g, int b, int a)
        {
            ColorName = name;
            Id = id;
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public Color()
        {

        }
    }
}