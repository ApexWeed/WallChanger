using System.Drawing;

namespace WallChanger
{
    /// <summary>
    /// Wrapper class that provides auto size calculation.
    /// </summary>
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

        /// <summary>
        /// Initialises a new duplicate entry.
        /// </summary>
        /// <param name="Path">The path to the image.</param>
        /// <param name="Title">The title of the image.</param>
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
