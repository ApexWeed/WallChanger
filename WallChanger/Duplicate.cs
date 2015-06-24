using System.Drawing;

namespace WallChanger
{
    class Duplicate
    {
        public string Path;
        public string Title;
        private Size size;
        public Size Size
        {
            get
            {
                if (size == new Size(0, 0))
                {
                    size = Imaging.GetDimensions(Path);
                }
                return size;
            }
        }

        public Duplicate(string Path, string Title)
        {
            this.Path = Path;
            this.Title = Title;
        }

        public override string ToString()
        {
            return string.Format("({1}x{2}) {0}", Title, Size.Width, Size.Height);
        }
    }
}
