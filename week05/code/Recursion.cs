using System.Collections;
using System.Collections.Generic;

public static class Recursion
{
    // Problem 1
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) return 0;
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    // Problem 2
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

    // Problem 3
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

    // Problem 4
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

    // Problem 5
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int, int)>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<(int, int)>();

        if (!maze.IsValidMove(currPath, x, y)) return;

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(PathToString(currPath));
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

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
