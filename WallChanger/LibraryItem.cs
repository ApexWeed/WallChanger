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

        public LibraryItem()
        {
            this.Tags = new List<string>();
            this.Filename = "";
            this.Category = "";
            this.ShowName = "";
            this.CharacterNames = new List<string>();
        }

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
