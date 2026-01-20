using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// Find symmetric pairs of two-character words using sets.
    /// Example: [am, at, ma, if, fi] → ["am & ma", "if & fi"]
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> wordSet = new HashSet<string>(words);
        List<string> pairs = new List<string>();

        foreach (var word in words)
        {
            string reversed = new string(word.Reverse().ToArray());
            if (wordSet.Contains(reversed) && word != reversed)
            {
                pairs.Add($"{word} & {reversed}");
                wordSet.Remove(word);     // avoid duplicates
                wordSet.Remove(reversed); // avoid duplicates
            }
        }

        return pairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize degrees earned.
    /// Degree info is in the 4th column (index 3).
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            string degree = fields[3];

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    /// <summary>
    /// Determine if word1 and word2 are anagrams (ignoring spaces and case).
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        string w1 = new string(word1.ToLower().Where(c => c != ' ').ToArray());
        string w2 = new string(word2.ToLower().Where(c => c != ' ').ToArray());

        if (w1.Length != w2.Length) return false;

        var count = new Dictionary<char, int>();

        foreach (char c in w1)
        {
            if (count.ContainsKey(c)) count[c]++;
            else count[c] = 1;
        }

        foreach (char c in w2)
        {
            if (!count.ContainsKey(c)) return false;
            count[c]--;
            if (count[c] < 0) return false;
        }

        return true;
    }

    /// <summary>
    /// Read USGS earthquake JSON data and return summaries of place and magnitude.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        var json = client.GetStringAsync(uri).Result;
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        List<string> summaries = new List<string>();
        foreach (var feature in featureCollection.Features)
        {
            summaries.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
        }

        return summaries.ToArray();
    }
}
