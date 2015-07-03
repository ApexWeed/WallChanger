using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallChanger
{
    class ArrayComparer<T> : IComparer<T[]> where T : IComparable
    {
        public int Compare(T[] array1, T[] array2)
        {
            for (int i = 0; i < array1.GetLength(0); i++)
            {
                int commparisonResult = array1[i].CompareTo(array2[i]);
                if (commparisonResult != 0)
                    return commparisonResult;
            }
            return 0;
        }
    }
}
