using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int numberToGuess = random.Next(1, 101);
        int guesses = 0;
        int guess;

        Console.WriteLine("I'm thinking of a number between 1 and 100. Can you guess what it is?");
        do
        {
            Console.Write("Enter your guess: ");
            guess = Convert.ToInt32(Console.ReadLine());
            guesses++;

            if (guess < numberToGuess)
            {
                Console.WriteLine("Too low! Try again.");
            }
            else if (guess > numberToGuess)
            {
                Console.WriteLine("Too high! Try again.");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed the number in {0} guesses.", guesses);
                break;
            }
        } while (true);

        Console.Write("Do you want to play again? (Y/N): ");
        string answer = Console.ReadLine();

        if (answer == "Y" || answer == "y")
        {
            Main(args);
        }
        else
        {
            Console.WriteLine("Thanks for playing!");
        }
    }
}
