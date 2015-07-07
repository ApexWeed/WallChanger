using System.Collections.Generic;

namespace WallChanger
{
    public class LibraryItem
    {
        public string Filename;
        public string Category;
        public string ShowName;
        public List<string> CharacterNames;
        public List<string> Tags;

        /// <summary>
        /// Initialises a new blank library item.
        /// </summary>
        public LibraryItem()
        {
            this.Tags = new List<string>();
            this.Filename = "";
            this.Category = "";
            this.ShowName = "";
            this.CharacterNames = new List<string>();
        }

        /// <summary>
        /// Initialises a blank library item for the specified filename.
        /// </summary>
        /// <param name="Filename">The filename of the image.</param>
        public LibraryItem(string Filename)
        {
            this.Tags = new List<string>();
            this.Filename = Filename;
            this.Category = "";
            this.ShowName = "";
            this.CharacterNames = new List<string>();
        }
    }
}
