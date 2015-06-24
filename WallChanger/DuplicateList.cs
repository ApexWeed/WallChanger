using System.Collections.Generic;

namespace WallChanger
{
    class DuplicateList
    {
        public string Title;
        public List<Duplicate> Duplicates;

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
