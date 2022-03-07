using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.BinarySearch
{
    class FindElementInSortedArray
    {
        public static int FindFirstOccurrence(List<int> arr, int target)
        {
            var left = 0;
            var right = arr.Count - 1;
            var result = -1;
            while(left<=right)
            {
                var middle = (left + right) / 2;
                if (arr[middle] == target)
                {
                    result = middle;
                    right = middle - 1;
                }
                else if (arr[middle] < target)
                {
                    left = middle + 1;
                }
                else if (arr[middle] > target)
                {
                    right = middle - 1;
                }
            }
            return result;
        }
    }
}
