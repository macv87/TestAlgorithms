using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DepthFirstSearch
{
    class BalancedBinaryTree
    {
        public static bool IsBalanced(Node<int> tree)
        {
            if (tree == null) return true;
            var leftHeight = GetHeight(tree.left, 0);
            var rightHeight = GetHeight(tree.right, 0);
            if (Math.Abs(leftHeight - rightHeight) > 1) return false;
            return IsBalanced(tree.left) && IsBalanced(tree.right);
        }

        private static int GetHeight(Node<int> node, int height)
        {
            if (node == null) return height;
            return Math.Max(GetHeight(node.left, height + 1), GetHeight(node.right, height + 1));
        }
    }
}
