namespace WallChanger
{
    public class ImageEntry
    {

        /// <summary>
        /// Automatically convert wrapper to base string.
        /// </summary>
        /// <param name="Entry">The path entry to unwrap.</param>
        public static implicit operator string (ImageEntry Entry)
        {
            return Entry.Path;
        }
        public readonly bool Highlight;
        public readonly string Path;

        /// <summary>
        /// Creates a new image entry wrapper.
        /// </summary>
        /// <param name="Path">The path to the image.</param>
        /// <param name="Highlight">Whether the item is the currently selected item.</param>
        public ImageEntry(string Path, bool Highlight)
        {
            this.Path = Path;
            this.Highlight = Highlight;
        }

        /// <summary>
        /// Display the path.
        /// </summary>
        /// <returns>The path to the image.</returns>
        public override string ToString()
        {
            return Path;
        }

    }
}
