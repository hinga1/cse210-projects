using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Scripture> scriptures = new List<Scripture>();

    static void Main()
    {
        LoadScripturesFromFile("scriptures.txt");

        while (true)
        {
            Scripture scripture = GetRandomScripture();
            Console.WriteLine("Reference: " + scripture.GetReference());
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");

            if (Console.ReadLine().ToLower() == "quit")
                break;

            HideRandomWords(scripture);
            Console.Clear();
            Console.WriteLine("Reference: " + scripture.GetReference());
            Console.WriteLine("Text: " + scripture.GetText());
        }

        Console.WriteLine("Program ended.");
    }

    static void LoadScripturesFromFile(string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                string reference = parts[0].Trim();
                string text = parts[1].Trim();
                scriptures.Add(new Scripture(reference, text));
            }

            Console.WriteLine("Scriptures loaded: " + scriptures.Count);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error loading scriptures: " + e.Message);
        }
    }

    static Scripture GetRandomScripture()
    {
        Random random = new Random();
        int index = random.Next(scriptures.Count);
        return scriptures[index];
    }

    static void HideRandomWords(Scripture scripture)
    {
        Random random = new Random();
        string[] words = scripture.GetText().Split(' ');

        foreach (string word in words)
        {
            if (random.Next(2) == 0) // Randomly decide to hide a word
            {
                int wordIndex = scripture.GetText().IndexOf(word);
                scripture.HideWord(wordIndex, word.Length);
            }
        }
    }
}

class Scripture
{
    private string reference;
    private string text;
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
        words = new List<Word>();

        foreach (string word in text.Split(' '))
        {
            words.Add(new Word(word));
        }
    }

    public string GetReference()
    {
        return reference;
    }

    public string GetText()
    {
        string result = "";
        foreach (Word word in words)
        {
            result += word.GetVisibleWord() + " ";
        }
        return result.Trim();
    }

    public void HideWord(int startIndex, int length)
    {
        for (int i = startIndex; i < startIndex + length; i++)
        {
            words[i].Hide();
        }
    }
}

class Word
{
    private string word;
    private bool visible;

    public Word(string word)
    {
        this.word = word;
        visible = true;
    }

    public string GetVisibleWord()
    {
        return visible ? word : new string('_', word.Length);
    }

    public void Hide()
    {
        visible = false;
    }
}
