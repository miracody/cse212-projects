using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> wordSet = new HashSet<string>(words);
        List<string> pairs = new List<string>();

        foreach (var word in words)
        {
            string reversed = $"{word[1]}{word[0]}";

            if (wordSet.Contains(reversed) && word != reversed)
            {
                string first = word.CompareTo(reversed) < 0 ? word : reversed;
                string second = word.CompareTo(reversed) < 0 ? reversed : word;

                pairs.Add($"{first} & {second}");

                wordSet.Remove(word);
                wordSet.Remove(reversed);
            }
        }

        return pairs.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            string degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

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
            // Must include " - Mag " exactly as the test expects
            summaries.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
        }

        return summaries.ToArray();
    }
}
