using System.Collections.Generic;

namespace TidalLibrary
{
    public class Palette
    {
        private string _paletteName;

        public string PaletteName
        {
            get { return _paletteName; }
            set { _paletteName = value; }
        }

        private string _fileLocation;

        public string FileLocation
        {
            get { return _fileLocation; }
            set { _fileLocation = value; }
        }

        private int _colorCount;

        public int ColorCount
        {
            get { return _colorCount; }
            set { _colorCount = value; }
        }

        public List<Color> ColorList;
    }
}