using System.Collections;
using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  If n <= 0, return 0.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) return 0; // base case
        return (n * n) + SumSquaresRecursive(n - 1); // recursive case
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length 'size' from a list of 'letters'
    /// into the results list.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: if word length == size, add to results
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive case: try each letter
        for (int i = 0; i < letters.Length; i++)
        {
            string remaining = letters.Substring(0, i) + letters.Substring(i + 1);
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count ways to climb stairs with steps of 1, 2, or 3 using recursion + memoization.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null) remember = new Dictionary<int, decimal>();

        // Base cases
        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        // Check memoization
        if (remember.ContainsKey(s)) return remember[s];

        // Recursive case
        decimal ways = CountWaysToClimb(s - 1, remember) +
                       CountWaysToClimb(s - 2, remember) +
                       CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Expand wildcard binary string into all possible binary strings.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        // Base case: no wildcard left
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Recursive case: replace * with 0 and 1
        string withZero = pattern.Substring(0, index) + "0" + pattern.Substring(index + 1);
        string withOne = pattern.Substring(0, index) + "1" + pattern.Substring(index + 1);

        WildcardBinary(withZero, results);
        WildcardBinary(withOne, results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Solve maze recursively: find all paths from (0,0) to end.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        // If out of bounds or blocked, stop
        if (!maze.IsOpen(x, y)) return;

        // If already visited, stop
        if (currPath.Contains((x, y))) return;

        // Add current position
        currPath.Add((x, y));

        // If reached end, add path to results
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Recursive exploration in 4 directions
        SolveMaze(results, maze, x + 1, y, new List<ValueTuple<int, int>>(currPath));
        SolveMaze(results, maze, x - 1, y, new List<ValueTuple<int, int>>(currPath));
        SolveMaze(results, maze, x, y + 1, new List<ValueTuple<int, int>>(currPath));
        SolveMaze(results, maze, x, y - 1, new List<ValueTuple<int, int>>(currPath));

        // Backtrack
        currPath.RemoveAt(currPath.Count - 1);
    }
}
