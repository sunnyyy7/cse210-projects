using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        ScriptureManager manager = new ScriptureManager();
        manager.LoadScripture("scripture.txt");

        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("Press Enter to hide words, or type 'quit' to exit.");
        Console.ReadLine();

        while (!manager.AllWordsHidden)
        {
            Console.Clear();
            manager.HideRandomWords();
            Console.WriteLine(manager.GetVisibleScripture());
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
                break;
        }

        Console.WriteLine("All words are hidden. Memorization complete!");
    }
}

class ScriptureManager
{
    private Scripture scripture;
    private List<string> visibleWords;

    public bool AllWordsHidden => visibleWords.Count == 0;

    public void LoadScripture(string filePath)
    {
        string scriptureText = File.ReadAllText(filePath);
        scripture = new Scripture(scriptureText);
        visibleWords = new List<string>(scripture.GetWords());
    }

    public void HideRandomWords()
    {
        if (!AllWordsHidden)
        {
            int numWordsToHide = Math.Min(3, visibleWords.Count);
            Random random = new Random();

            for (int i = 0; i < numWordsToHide; i++)
            {
                int index = random.Next(0, visibleWords.Count);
                visibleWords[index] = "______";
            }
        }
    }

    public string GetVisibleScripture()
    {
        return string.Join(" ", visibleWords);
    }
}

class Scripture
{
    private string reference;
    private string text;
    private string[] words;

    public Scripture(string fullText)
    {
        int referenceEnd = fullText.IndexOf(' ');
        reference = fullText.Substring(0, referenceEnd).Trim();
        text = fullText.Substring(referenceEnd).Trim();
        words = text.Split(' ');
    }

    public string GetReference()
    {
        return reference;
    }

    public string GetText()
    {
        return text;
    }

    public string[] GetWords()
    {
        return words;
    }
}
