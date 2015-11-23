using System.Drawing;

namespace WallChanger
{
    /// <summary>
    /// Wrapper class that provides auto size calculation.
    /// </summary>
    class Duplicate
    {
        public readonly string Path;
        public readonly string Title;
        private Size size;

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

        public override string ToString()
        {
            return $"({Size.Width}x{Size.Height}) {Title}";
        }
    }
}
