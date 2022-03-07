using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.BinarySearch
{
    class FindingBoundary
    {
        public static int FindBoundary(List<bool> arr)
        {
            var left = 0;
            var right = arr.Count - 1;
            while (left <= right)
            {
                var middle = (left + right) / 2;
                if (arr[middle] == false)
                {
                    left = middle + 1;
                }
                else
                {
                    if (middle == 0 || arr[middle - 1] == false) return middle;
                    right = middle - 1;
                }
            }
            return -1;
        }
    }
}
