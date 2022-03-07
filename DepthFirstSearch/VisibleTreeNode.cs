using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DepthFirstSearch
{
    class VisibleTreeNode
    {
        public static int VisibleTreeNodeCount(Node<int> root)
        {
            return GetVisibleTreeNodesCount(root.left, root.val) + GetVisibleTreeNodesCount(root.right, root.val) + 1;
        }

        private static int GetVisibleTreeNodesCount(Node<int> node, int parentValue)
        {
            if (node == null) return 0;
            var result = 0;
            if (node.val > parentValue) result++;
            var maxValue = Math.Max(parentValue, node.val);
            result += GetVisibleTreeNodesCount(node.left, maxValue);
            result += GetVisibleTreeNodesCount(node.right, maxValue);
            return result;
        }
    }
}
