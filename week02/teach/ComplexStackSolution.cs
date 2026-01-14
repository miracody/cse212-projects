using System;
using System.Collections.Generic;

public static class ComplexStackSolution
{
    public static bool CheckBraces(string line)
    {
        var stack = new Stack<char>();
        foreach (var item in line)
        {
            if (item == '(' || item == '[' || item == '{')
            {
                stack.Push(item);
            }
            else if (item == ')')
            {
                if (stack.Count == 0 || stack.Pop() != '(')
                    return false;
            }
            else if (item == ']')
            {
                if (stack.Count == 0 || stack.Pop() != '[')
                    return false;
            }
            else if (item == '}')
            {
                if (stack.Count == 0 || stack.Pop() != '{')
                    return false;
            }
        }

        return stack.Count == 0;
    }
}
