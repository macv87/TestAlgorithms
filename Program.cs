using System;
using System.Collections.Generic;

namespace LeetCode
{
    class Program
    {
        private static Random _random = new Random();

        static void Main(string[] args)
        {
            //TestBinarySearch();
            //TestDepthFirstSearch();
            //TestMiscellaneous();
            TestGreedy();
            Console.ReadKey();
        }

        static void TestBinarySearch()
        {
            //TestFindingBoundaries();
            //TestFindElementInSortedArray();
            TestFindMinimumInRotatedArray();
        }

        static void TestDepthFirstSearch()
        {
            //TestVisibleTreeNode();
            TestBalancedTree();
        }

        static void TestMiscellaneous()
        {
            TestBracketBalanced();
        }

        private static void TestVisibleTreeNode()
        {
            OutputTitle("Test visible tree node");

            var n5 = new Node<int>(8);
            var n4 = new Node<int>(3);
            var n3 = new Node<int>(6);
            var n2 = new Node<int>(9, n4,n5);
            var n1 = new Node<int>(5, n2, n3);

            var count = DepthFirstSearch.VisibleTreeNode.VisibleTreeNodeCount(n1);

            Console.WriteLine(count.ToString());
        }

        private static void TestBalancedTree()
        {
            OutputTitle("Test balanced tree");

            {
                var n7 = new Node<int>(7);
                var n6 = new Node<int>(6);
                var n5 = new Node<int>(5);
                var n4 = new Node<int>(4, null, n7);
                var n3 = new Node<int>(3, null, n6);
                var n2 = new Node<int>(2, n4, n5);
                var n1 = new Node<int>(1, n2, n3);

                var result = DepthFirstSearch.BalancedBinaryTree.IsBalanced(n1);
                Console.WriteLine(result.ToString());

            }
            {
                var n8 = new Node<int>(8);
                var n7 = new Node<int>(7);
                var n6 = new Node<int>(6, n8, null);
                var n5 = new Node<int>(5);
                var n4 = new Node<int>(4, null, n7);
                var n3 = new Node<int>(3, null, n6);
                var n2 = new Node<int>(2, n4, n5);
                var n1 = new Node<int>(1, n2, n3);

                var result = DepthFirstSearch.BalancedBinaryTree.IsBalanced(n1);
                Console.WriteLine(result.ToString());
            }
        }

        static void TestBracketBalanced()
        {
            OutputTitle("Test bracket balanced");
            
            var inputs = new List<string>() { "}", "{[()]}", "{[(])}", "{{[[(())]]}}" };
            var expectedResults = new List<string>() { "NO", "YES", "NO", "YES" };

            for(int i=0;i<inputs.Count;i++)
            {
                Console.WriteLine($"{inputs[i]} -> expected: {expectedResults[i]}");
                Console.WriteLine(Miscellaneous.BracketBalanced.isBalanced(inputs[i]));
                Console.WriteLine("------------------------------");
            }
        }

        static void TestGreedy()
        {
            TestGasStation();
        }

        static void TestGasStation()
        {
            OutputTitle("Test Gas Station");

            var gas = new List<int>() { 5,5,5,5,5 };
            var distances = new List<int>() { 6,3,3,8,5 };

            var result = Greedy.GasStation.StartingStation(gas, distances);
            Console.WriteLine(result.ToString());
            Console.WriteLine("-----------");
        }

        static void TestFindingBoundaries()
        {
            OutputTitle("Finding Boundaries");            

            for (int test = 0; test < 200; test++)
            {
                var n = 50;
                var startIndex = _random.Next(n+1);
                var values = new List<bool>();
                for (int i = 0; i < n; i++)
                {
                    values.Add(i >= startIndex);
                }
                Output(values);
                var result = BinarySearch.FindingBoundary.FindBoundary(values);
                OutputIndex(result);
                Console.WriteLine("--------------------------------------------------");
            }
        }

        static void TestFindElementInSortedArray()
        {
            OutputTitle("Test Find element in Sorted Array");

            for (int test = 0; test < 50; test++)
            {
                var n = 30;
                var values = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    values.Add(_random.Next(9)+1);
                }
                values.Sort();
               
                var target = _random.Next(10);

                Console.WriteLine($"Find {target}");

                Output(values);
                var result = BinarySearch.FindElementInSortedArray.FindFirstOccurrence(values, target);
                OutputIndex(result);
                Console.WriteLine("--------------------------------------------------");
            }
        }

        static void TestFindMinimumInRotatedArray()
        {
            OutputTitle("Test find minimum in rotated array");

            for (int test = 0; test < 50; test++)
            {
                var n = 20;
                var values = new List<int>();

                var currentValue = 1;

                for (int i = 0; i < n; i++)
                {
                    var newValue = _random.Next(5)+1 + currentValue;
                    values.Add(newValue);
                    currentValue = newValue;
                }
                values.Sort();

                var pivot = _random.Next(n + 1);

                for (int i = 0; i < pivot; i++)
                {
                    values.Add(values[0]);
                    values.RemoveAt(0);
                }


                //values = new List<int>() { 30, 40, 50, 10, 20 };

                Output(values,3);
                var result = BinarySearch.FindMinimumInRotatedArray.FindMinRotated(values);
                OutputIndex(result,3);
                Console.WriteLine("--------------------------------------------------");
            }
        }

        static void OutputTitle(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }

        private static void Output(List<bool> values)
        {
            foreach (var value in values)
                Console.Write(value ? "#" : " ");
            Console.WriteLine();
        }

        private static void Output(List<int> values, int places = 1)
        {
            foreach (var value in values)
            {
                var valueString = value.ToString();
                Console.Write(valueString);
                for (int i = valueString.Length; i < places; i++)
                    Console.Write(" ");
            }
            Console.WriteLine();
        }

        private static void OutputIndex(int index, int places = 1)
        {
            for (int i = 0; i <= index; i++)
            {
                Console.Write(i == index ? "$" : " ");
                for (int j = 1; j < places; j++)
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    public class Solution
    {
        int _max = 0;

        public int DiameterOfBinaryTree(TreeNode root)
        {
            ProcessNode(root);
            return _max;
        }

        public int ProcessNode(TreeNode n)
        {
            if (n == null) return -1;
            var lmax = ProcessNode(n.left);
            var rmax = ProcessNode(n.right);
            if (lmax + rmax > _max) _max = lmax + rmax;
            if (n.left == null) lmax = 0;
            else if (n.right == null) rmax = 0;
            var nMax = Math.Max(lmax, rmax);
            if (nMax > _max) _max = nMax;
            return nMax + 1;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public override string ToString()
        {
            return val.ToString();
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val=0,ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public override string ToString()
        {
            return string.Join("-", GetValues());
        }

        public List<int> GetValues()
        {
            var result = new List<int>();
            result.Add(val);
            if (next != null) result.AddRange(next.GetValues());
            return result;
        }
    }
}
