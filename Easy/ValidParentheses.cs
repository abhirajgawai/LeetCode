namespace LeetCode.Easy;

public class ValidParentheses
{

    /*
         Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
         An input string is valid if:

         Open brackets must be closed by the same type of brackets.
         Open brackets must be closed in the correct order.
         Every close bracket has a corresponding open bracket of the same type.

        Example 1:

        Input: s = "()"

        Output: true

        Example 2:

        Input: s = "()[]{}"

        Output: true

        Example 3:

        Input: s = "(]"

        Output: false

        Example 4:

        Input: s = "([])"

        Output: true
         */

    //Using Stack
    public bool IsValid(string s)
    {
        var stack = new Stack<char>();
        foreach (var c in s)
        {
            switch (c)
            {
                case '(':
                case '{':
                case '[':
                    stack.Push(c);
                    break;
                case ')':
                    if (stack.Count == 0 || stack.Pop() != '(') return false;
                    break;
                case '}':
                    if (stack.Count == 0 || stack.Pop() != '{') return false;
                    break;
                case ']':
                    if (stack.Count == 0 || stack.Pop() != '[') return false;
                    break;
            }
        }
        // If stack is empty, all brackets were matched
        return stack.Count == 0;
    }


    public int Min(string s)
    {
        var open = 0;
        var add = 0;
        foreach (var c in s)
        {
            // Count open parentheses
            if (c == '(')
            {
                open++;
            }

            else if (c == ')')
            {
                // If we have an open parenthesis, match it
                if (open > 0)
                {
                    open--; // match with existing '('
                }
                // If no open parenthesis to match, we need to add one
                else
                {
                    add++; // no '(' to match → need to add one
                }
            }

        }
        // Remaining `open` means we need that many ')'
        return open + add;
    }


    //  ) ( ) ( ) )
    public int LongestValidParentheses(string s)
    {
        Stack<int> stack = new();
        stack.Push(-1); // base index
        int maxLength = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                stack.Push(i); // save index of '('
            }
            else // it's a ')'
            {
                stack.Pop(); // try to match with '('
                if (stack.Count == 0)
                {
                    stack.Push(i); // reset base index
                }
                else
                {
                    // Calculate length of valid substring
                    // i - stack.Peek() gives the length of the valid substring
                    int length = i - stack.Peek(); // valid substring length
                    maxLength = Math.Max(maxLength, length);
                }
            }
        }

        return maxLength;
    }
}

