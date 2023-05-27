using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // Create a list of scriptures
        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");

        // Check if scriptures were loaded successfully
        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found.");
            return;
        }

        // Select a random scripture
        Random random = new Random();
        Scripture selectedScripture = scriptures[random.Next(scriptures.Count)];

        // Display the complete scripture
        selectedScripture.Display();

        // Prompt the user to press enter or quit
        Console.WriteLine("Press enter to hide words or type 'quit' to exit.");

        while (true)
        {
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
                break;

            // Hide random words in the scripture
            selectedScripture.HideRandomWords();

            // Clear the console screen
            Console.Clear();

            // Display the modified scripture
            selectedScripture.Display();

            // Check if all words are hidden
            if (selectedScripture.AreAllWordsHidden())
                break;

            // Prompt the user to press enter or quit again
            Console.WriteLine("Press enter to hide more words or type 'quit' to exit.");
        }
    }

    // Load scriptures from a file and return a list of scripture objects
    static List<Scripture> LoadScripturesFromFile(string fileName)
    {
        List<Scripture> scriptures = new List<Scripture>();

        try
        {
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    string reference = parts[0].Trim();
                    string text = parts[1].Trim();
                    Scripture scripture = new Scripture(reference, text);
                    scriptures.Add(scripture);
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Error reading the file: " + e.Message);
        }

        return scriptures;
    }
}

class Scripture
{
    private string reference;
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        words = new List<Word>();

        string[] wordArray = text.Split(' ');

        foreach (string word in wordArray)
        {
            words.Add(new Word(word));
        }
    }

    public void Display()
    {
        Console.WriteLine(reference);

        foreach (Word word in words)
        {
            if (word.IsHidden)
                Console.Write("____ ");
            else
                Console.Write(word.Text + " ");
        }

        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        Random random = new Random();

        foreach (Word word in words)
        {
            if (!word.IsHidden && random.Next(2) == 0)
                word.Hide();
        }
    }

    public bool AreAllWordsHidden()
    {
        foreach (Word word in words)
        {
            if (!word.IsHidden)
                return false;
        }

        return true;
    }
}

class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }
}
