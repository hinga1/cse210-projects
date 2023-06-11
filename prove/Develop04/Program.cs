using System;
using System.Threading;

class Activity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Duration { get; set; }

    public virtual void StartActivity()
    {
        Console.WriteLine($"Starting {Name} activity...\n");
        Console.WriteLine(Description);
        Console.WriteLine($"Duration: {Duration} seconds\n");
        Thread.Sleep(2000); // Delay for 2 seconds

        // Implement the activity specific logic in the subclasses
    }

    protected void DisplayMessage(string message)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(100); // Delay for 0.1 second
        }
        Console.WriteLine();
    }

    protected void DisplayCountdown()
    {
        for (int i = 3; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000); // Delay for 1 second
        }
        Console.WriteLine("Go!\n");
    }
}

class BreathingActivity : Activity
{
    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("Get ready to breathe in...");
        Thread.Sleep(1000); // Delay for 1 second
        BreatheIn();
        Console.WriteLine("\nGet ready to breathe out...");
        Thread.Sleep(1000); // Delay for 1 second
        BreatheOut();
        Console.WriteLine("\nBreathing activity completed.\n");
    }

    private void BreatheIn()
    {
        DisplayCountdown();
        DisplayMessage("Breathe in...");
    }

    private void BreatheOut()
    {
        DisplayCountdown();
        DisplayMessage("Breathe out...");
    }
}

class ReflectionActivity : Activity
{
    private string[] prompts = { "What are you grateful for today?", "Reflect on a recent accomplishment.", "What is one lesson you've learned recently?" };

    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("Reflect on the following prompt:\n");
        string prompt = SelectPrompt();
        AskQuestion(prompt);
        Console.WriteLine("\nReflection activity completed.\n");
    }

    private string SelectPrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Length);
        return prompts[index];
    }

    private void AskQuestion(string question)
    {
        DisplayCountdown();
        DisplayMessage(question);
    }
}

class ListingActivity : Activity
{
    private string[] prompts = { "List three things that make you happy.", "List five goals you want to achieve.", "List two places you want to visit." };

    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("Create a list based on the following prompt:\n");
        string prompt = SelectPrompt();
        ListItems(prompt);
        Console.WriteLine("\nListing activity completed.\n");
    }

    private string SelectPrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Length);
        return prompts[index];
    }

    private void ListItems(string prompt)
    {
        DisplayCountdown();
        Console.WriteLine(prompt);
        Console.WriteLine("Enter your items (one item per line):\n");

        int itemCount = 0;
        string input = Console.ReadLine();

        while (!string.IsNullOrWhiteSpace(input))
        {
            itemCount++;
            input = Console.ReadLine();
        }

        DisplayItemCount(itemCount);
    }

    private void DisplayItemCount(int count)
    {
        Console.WriteLine($"\nYou listed {count} items.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool exitProgram = false;

        do
        {
            ShowMainMenu();
            string choice = GetUserChoice();

            switch (choice)
            {
                case "1":
                    StartBreathingActivity();
                    break;
                case "2":
                    StartReflectionActivity();
                    break;
                case "3":
                    StartListingActivity();
                    break;
                case "4":
                    exitProgram = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }

        } while (!exitProgram);

        Console.WriteLine("Program exited. Goodbye!");
    }

    static void ShowMainMenu()
    {
        Console.WriteLine("+-------------------+");
        Console.WriteLine("|     Main Menu     |");
        Console.WriteLine("+-------------------+");
        Console.WriteLine("1. Breathing");
        Console.WriteLine("2. Reflection");
        Console.WriteLine("3. Listing");
        Console.WriteLine("4. Exit");
        Console.WriteLine();
    }

    static string GetUserChoice()
    {
        Console.Write("Choose an activity (1-4): ");
        return Console.ReadLine();
    }

    static void StartBreathingActivity()
    {
        BreathingActivity breathingActivity = new BreathingActivity
        {
            Name = "Breathing",
            Description = "Take a moment to focus on your breath and find inner calm.",
            Duration = "60"
        };

        breathingActivity.StartActivity();
    }

    static void StartReflectionActivity()
    {
        ReflectionActivity reflectionActivity = new ReflectionActivity
        {
            Name = "Reflection",
            Description = "Take some time to reflect on your thoughts and emotions.",
            Duration = "120"
        };

        reflectionActivity.StartActivity();
    }

    static void StartListingActivity()
    {
        ListingActivity listingActivity = new ListingActivity
        {
            Name = "Listing",
            Description = "Create a list of items based on the given prompt.",
            Duration = "180"
        };

        listingActivity.StartActivity();
    }
}
