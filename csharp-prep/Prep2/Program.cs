using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your grade percentage: ");
        string percentage = Console.ReadLine();
        int percent = int.Parse(percentage);

        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }

        Console.WriteLine($"You got an: {letter}");

        if (percent >= 70)
        {
            Console.WriteLine("You passed! Keep aiming for the stars!");
        }
        else
        {
            Console.WriteLine("Keep working harder!");
        }
    }
}