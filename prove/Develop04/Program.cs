using System;
using System.Runtime.CompilerServices;
using System.Threading;

abstract class MindfulnessActivity
{
    public abstract void StartActivity();
}

class BreathingActivity : MindfulnessActivity
{
    public override void StartActivity()
    {
        Console.Clear();
        Console.WriteLine("Breathing Activity: ");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

       
        Console.Write("Enter the duration in seconds: ");
        if (int.TryParse(Console.ReadLine(), out int duration))
        {
            Console.WriteLine($"Starting Breathing Activity for {duration} seconds...");
            PerformBreathingActivity(duration);
        }
        else
        {
            Console.WriteLine("Invalid duration input. Exiting Breathing Activity.");
        }
    }

    private void PerformBreathingActivity(int duration)
    {
        for (int seconds = duration; seconds > 0; seconds--)
        {
            Console.WriteLine(seconds % 2 == 0 ? "Breathe in..." : "Breathe out...");
            Thread.Sleep(2000); 
            Console.Clear(); 
        }

        Console.WriteLine("Breathing Activity complete. Take a moment to relax.");
    }
}

class ReflectionActivity : MindfulnessActivity
{

    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    
    private string[] reflectionQuestions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public override void StartActivity()
    {
        Console.Clear();
        Console.WriteLine("Reflection Activity");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        Console.WriteLine();

        Console.Write("Enter the duration in seconds: ");

        Console.WriteLine();
        if (int.TryParse(Console.ReadLine(), out int duration))
        {
            Console.WriteLine($"Starting Reflection Activity for {duration} seconds. . .");
            PerformReflectionActivity(duration);
        }
        else
        {
            Console.WriteLine("Invalid duration input. Exiting Reflection Activity.");
        }
    }

    private void PerformReflectionActivity(int duration)
    {

        Random random = new Random();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        
        string randomPrompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine($"Prompt: {randomPrompt}");

        
        Thread.Sleep(5000);

        Console.Write("Your response: ");
        Console.ReadLine();

       
        while (DateTime.Now < endTime)
        {
            foreach (string question in reflectionQuestions)
            {
                Console.WriteLine($"Question: {question}");

                
                Console.Write("Your response: ");
                string response = Console.ReadLine();
                Console.WriteLine();

                
                if (DateTime.Now >= endTime)
                    break; 
            }

            
            if (DateTime.Now < endTime)
            {
                Thread.Sleep(1000);
                Console.Clear(); 
            }
        }

        // Print final message after the duration ends
        Console.WriteLine("Reflection Activity complete. Take a moment to process your reflections.");
    }
}


class ListingActivity : MindfulnessActivity
{
    
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public override void StartActivity()
    {
        Console.Clear();
        Console.WriteLine("Listing Activity:");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        Console.WriteLine();

        Console.Write("Enter the duration in seconds: ");
        Console.WriteLine();

        if (int.TryParse(Console.ReadLine(), out int duration))
        {
            Console.WriteLine($"Starting Listing Activity for {duration} seconds...");
            PerformListingActivity(duration);
        }
        else
        {
            Console.WriteLine("Invalid duration input. Exiting Listing Activity.");
        }
    }

    private void PerformListingActivity(int duration)
    {
        Random random = new Random();
        string randomPrompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine($"Prompt: {randomPrompt}");

        
        Console.WriteLine("You may begin thinking about the prompt...");
        for (int seconds = 3; seconds > 0; seconds--)
        {
            Console.Write($"{seconds}");
            Thread.Sleep(1000);
        }
        Console.WriteLine("Go!");

        Console.WriteLine();

        DateTime startTime = DateTime.Now;

       
        int itemCount = 0;
        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            Console.Write("Enter an item: ");
            string item = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(item))
            break;
            itemCount++;
        }

        Console.WriteLine();

        Console.WriteLine("Listing Activity is complete. Take a moment to reflect.");
    }
}


class Introduction 
{
    public static void DisplayIntro()
    {
        string intro = @"Welcome! Medicare is an app designed to help practice mindfullness.
There are three activites that can be used in our everyday lives which will help to maintain a healthy mind and body.
Medicare is a user-friendly application crafted to bring mindfullness practices into your daily life at your own time and pace!
";

        Console.WriteLine(intro);

         Thread.Sleep(2000);

        DisplayMenu();
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("\n Menu:");
        Console.WriteLine("1.Breathing Activity");
        Console.WriteLine("2.Reflection Activity");
        Console.WriteLine("3.Listing Activity");
        Console.WriteLine("4.Quit");
        Console.Write("Please select an option: ");
        
        string option = Console.ReadLine();

           MindfulnessActivity selectedActivity =  GetSelectedActivity(option);

           selectedActivity?.StartActivity();
    }

    private static MindfulnessActivity GetSelectedActivity(string option)
    {
        switch (option)
        {
            case "1":
            return new BreathingActivity();
            case "2":
            return new ReflectionActivity();
            case "3":
            return new ListingActivity();
            case "4":
            Environment.Exit(0);
            return null;
            default:
            Console.WriteLine("Invalid Option.");
            return null;
        }
    }
}



class Program
{
    static void Main(string[] args)
    {
         Console.ForegroundColor = ConsoleColor.Blue;

       Introduction.DisplayIntro();
    }
}