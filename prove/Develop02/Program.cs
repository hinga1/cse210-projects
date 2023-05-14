using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DailyJournal
{
    class Program
    {
        static List<Entry> entries = new List<Entry>();

        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Write a new journal entry");
                Console.WriteLine("2. Display all journal entries");
                Console.WriteLine("3. Save journal to file");
                Console.WriteLine("4. Load journal from file");
                Console.WriteLine("5. Delete an entry");
                Console.WriteLine("6. Exit");

                int option;
                bool isValidOption = int.TryParse(Console.ReadLine(), out option);

                if (!isValidOption)
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        WriteNewEntry();
                        break;
                    case 2:
                        DisplayJournal();
                        break;
                    case 3:
                        SaveJournalToFile();
                        break;
                    case 4:
                        LoadJournalFromFile();
                        break;
                    case 5:
                        DeleteEntry();
                        break;
                    case 6:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void WriteNewEntry()
        {
            Random random = new Random();
            int index = random.Next(prompts.Length);
            string prompt = prompts[index];

            Console.WriteLine("Prompt: " + prompt);
            string response = Console.ReadLine();

            Console.WriteLine("Rate your day from 1 to 10:");
            int rating;
            bool isValidRating = int.TryParse(Console.ReadLine(), out rating);

            if (!isValidRating)
            {
                Console.WriteLine("Invalid rating. Defaulting to 5.");
                rating = 5;
            }

            Entry entry = new Entry(prompt, response, DateTime.Now, rating);
            entries.Add(entry);

            Console.WriteLine("Entry added successfully.");
        }

        static void DisplayJournal()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("No entries found.");
                return;
            }

            foreach (Entry entry in entries)
            {
                Console.WriteLine(entry.ToString());
            }
        }

        static void SaveJournalToFile()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("No entries found.");
                return;
            }

            Console.WriteLine("Enter filename:");
            string filename = Console.ReadLine();

            try
            {
                string jsonString = JsonSerializer.Serialize(entries, new JsonSerializerOptions() { WriteIndented = true });
                File.WriteAllText(filename, jsonString);
                Console.WriteLine("Journal saved successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error saving journal to file: " + e.Message);
            }
        }

        static void LoadJournalFromFile()
        {
            Console.WriteLine("Enter filename:");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            try
            {
                string jsonString = File.ReadAllText(filename);
                entries = JsonSerializer.Deserialize<List<Entry>>(jsonString);
                Console.WriteLine("Journal loaded successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error loading journal from file: " + e.Message);
            }
        }

        static void DeleteEntry()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("No entries found.");
                return;
            }

            Console.WriteLine("Enter the index of the entry to delete:");
            int index;
            bool isValid
        }
    }
}