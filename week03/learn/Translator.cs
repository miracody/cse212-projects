using System;
using System.Collections.Generic;

public class Translator
{
    public static void Run()
    {
        var englishToGerman = new Translator();
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");

        Console.WriteLine(englishToGerman.Translate("Car"));   // Auto
        Console.WriteLine(englishToGerman.Translate("Plane")); // Flugzeug
        Console.WriteLine(englishToGerman.Translate("Train")); // ???
    }

    // Dictionary to store translations (key: source word, value: translated word)
    private readonly Dictionary<string, string> _words = new();

    /// <summary>
    /// Add the translation from 'fromWord' to 'toWord'
    /// </summary>
    public void AddWord(string fromWord, string toWord)
    {
        _words[fromWord] = toWord; // add or replace translation
    }

    /// <summary>
    /// Translate the given word; return "???" if no translation exists
    /// </summary>
    public string Translate(string fromWord)
    {
        return _words.TryGetValue(fromWord, out var translated)
            ? translated
            : "???";
    }
}
