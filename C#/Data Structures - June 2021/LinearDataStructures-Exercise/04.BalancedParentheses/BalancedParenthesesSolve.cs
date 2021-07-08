namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            var stack = new Stack<char>();

            foreach (var parenthes in parentheses)
            {
                if (parenthes == '(' || parenthes == '[' || parenthes == '{')
                {
                    stack.Push(parenthes);
                }

                if (stack.Count == 0)
                {
                    return false;
                }

                if ((stack.Peek() == '(' && parenthes == ')')
                     || (stack.Peek() == '[' && parenthes == ']')
                     || (stack.Peek() == '{') && parenthes == '}')
                {
                    stack.Pop();
                }
            }

            return stack.Count == 0;
        }
    }
}
