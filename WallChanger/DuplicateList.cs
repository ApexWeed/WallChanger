using System.Collections.Generic;

namespace WallChanger
{
    class DuplicateList
    {
        public string Title;
        public List<Duplicate> Duplicates;

        /// <summary>
        /// Initialises a new duplicate list.
        /// </summary>
        /// <param name="Title">The title for this list.</param>
        /// <param name="Duplicates">The list of duplicates to add.</param>
        public DuplicateList(string Title, List<Duplicate> Duplicates)
        {
            this.Title = Title;
            this.Duplicates = Duplicates;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1} images)", Title, Duplicates.Count);
        }
    }
}
