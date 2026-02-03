using System.Collections;
using System.Collections.Generic;

public class Maze
{
    private int _width;
    private int _height;
    private int _endX;
    private int _endY;
    private bool[,] _walls;

    public Maze(int width, int height, int endX, int endY, bool[,] walls)
    {
        _width = width;
        _height = height;
        _endX = endX;
        _endY = endY;
        _walls = walls;
    }

    public bool IsValidMove(List<(int, int)> path, int x, int y)
    {
        // Check bounds
        if (x < 0 || x >= _width || y < 0 || y >= _height)
            return false;

        // Check if it's a wall
        if (_walls[y, x])
            return false;

        // Check if already visited
        if (path.Contains((x, y)))
            return false;

        return true;
    }

    public bool IsEnd(int x, int y)
    {
        return x == _endX && y == _endY;
    }
}

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
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

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

        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        if (remember.ContainsKey(s)) return remember[s];

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

        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

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
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int, int)>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<(int, int)>();

        // Check if move is valid
        if (!maze.IsValidMove(currPath, x, y)) return;

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(PathToString(currPath));
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Explore neighbors
        SolveMaze(results, maze, x + 1, y, new List<(int, int)>(currPath));
        SolveMaze(results, maze, x - 1, y, new List<(int, int)>(currPath));
        SolveMaze(results, maze, x, y + 1, new List<(int, int)>(currPath));
        SolveMaze(results, maze, x, y - 1, new List<(int, int)>(currPath));

        currPath.RemoveAt(currPath.Count - 1);
    }

    private static string PathToString(List<(int, int)> path)
    {
        return string.Join("->", path);
    }
}
