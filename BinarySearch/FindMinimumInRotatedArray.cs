using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.BinarySearch
{
    class FindMinimumInRotatedArray
    {
        public static int FindMinRotated(List<int> arr)
        {
            var left = 0;
            var right = arr.Count - 1;
            var result = -1;
            while (left <= right)
            {
                var middle = (left + right) / 2;
                if (arr[middle] > arr[^1])
                {
                    left = middle + 1;
                }
                else
                {
                    result = middle;
                    right = middle - 1;
                }
            }
            return result;
        }
    }
}
