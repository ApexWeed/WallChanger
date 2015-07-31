using System.Collections.Generic;

namespace WallChanger
{
    class DuplicateList
    {
        public readonly string Title;
        public readonly List<Duplicate> Duplicates;

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
            return $"{Title} ({Duplicates.Count} images)";
        }
    }
}
