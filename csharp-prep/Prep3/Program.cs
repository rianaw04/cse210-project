using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter the secret number: ");
        int secretNumber = int.Parse(Console.ReadLine());

        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1,11);

        int guess = -1;

        while (guess != number)
        {
            Console.Write("Please enter you guess: ");
            guess = int.Parse(Console.ReadLine());

            if (number > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (number < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You've guessed it!");
            }
        }
    }
}