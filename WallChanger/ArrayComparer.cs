using System;
using System.Collections.Generic;

namespace WallChanger
{
    class ArrayComparer<T> : IComparer<T[]> where T : IComparable
    {
        /// <summary>
        /// Compares two single dimension arrays for equality.
        /// </summary>
        /// <param name="array1">The first array to compare.</param>
        /// <param name="array2">The second array to compare.</param>
        /// <returns>Relative sort order of the arrays.</returns>
        public int Compare(T[] array1, T[] array2)
        {
            int comparisonResult = array1.GetLength(0).CompareTo(array2.GetLength(0));
            if (comparisonResult != 0)
                return comparisonResult;
            for (int i = 0; i < array1.GetLength(0); i++)
            {
                comparisonResult = array1[i].CompareTo(array2[i]);
                if (comparisonResult != 0)
                    return comparisonResult;
            }
            return 0;
        }
    }
}
