using System.Collections.Generic;

namespace WallChanger
{
    public class LibraryItem
    {
        private string category;
        private List<string> characterNames;
        private string filename;
        private string showName;
        private List<string> tags;

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

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                this.category = value;
            }
        }

        public List<string> CharacterNames
        {
            get
            {
                return characterNames;
            }

            set
            {
                this.characterNames = value;
            }
        }

        public string Filename
        {
            get
            {
                return filename;
            }

            set
            {
                this.filename = value;
            }
        }

        public string ShowName
        {
            get
            {
                return showName;
            }

            set
            {
                this.showName = value;
            }
        }

        public List<string> Tags
        {
            get
            {
                return tags;
            }

            set
            {
                this.tags = value;
            }
        }
    }
}
