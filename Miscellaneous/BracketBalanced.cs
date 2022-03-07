using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Miscellaneous
{
    class BracketBalanced
    {
        public static string isBalanced(string s)
        {
            var stack = new Stack<char>();
            foreach (var c in s)
            {
                var mustPop = false;
                if (stack.Count > 0)
                {
                    var currentValue = stack.Peek();
                    if (c == '}' && currentValue == '{') mustPop = true;
                    else if (c == ']' && currentValue == '[') mustPop = true;
                    else if (c == ')' && currentValue == '(') mustPop = true;
                }
                if (mustPop) stack.Pop();
                else stack.Push(c);
            }
            return stack.Count == 0 ? "YES" : "NO";
        }
    }
}
