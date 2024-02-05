using System;
using System.Collections.Generic;


class Introduction 
{
    public static void DisplayIntro()
    {
        string intro = @"Welcome! This software is used to test the knowledge on scriptures.
Every time you click the enter key a word will be hidden until you decide to quit.";

        Console.WriteLine(intro);
    }
}

class Scripture
{
    public string Refrence { get;set; }
    public string Text{get; set;}
}


class Program
{
    static void Main(string[] args)
    {
        // changing font color to green
        Console.ForegroundColor = ConsoleColor.Green;

        Introduction.DisplayIntro();

        Console.WriteLine();

        List<Scripture> scriptures = InitializeScriptures();

        while (true)
        {
            var randomScripture = GetRandomScripture(scriptures);
        
            DisplayCompleteScripture(randomScripture);

            while (true)
            {
                Console.Clear();
                HideWord(randomScripture);
                DisplayCompleteScripture(randomScripture);
                Console.ReadLine();

                if (AllWordsHidden(randomScripture))
                    break;
            }

            Console.WriteLine();

           
        }

        
    }

    static List<Scripture> InitializeScriptures()
    {
        return new List<Scripture>
        {
            new Scripture {Refrence = "Proverbs 2:11", Text ="discretion shall preserve thee, understanding shall keep thee."},
            new Scripture {Refrence = "James 3:18",  Text ="And the fruit of righteousness is sown in peace of them that make peace."},
            new Scripture {Refrence ="1 Peter 2:9", Text ="For ye were as sheep going astray;but now returned unto the Sheperd and Bishop of your souls."},
            new Scripture {Refrence ="1 Nephi 14:22", Text="And he shall also write concerning the end of the worldd."},
            new Scripture {Refrence ="Ecclesiastes 8:6", Text ="Because to every purpose there is time and judgement, therefore misery of man is great upon him."}
        };
        
    }

    static void DisplayCompleteScripture (Scripture scripture)
    {
     Console.WriteLine($"{scripture.Refrence}\n\n {scripture.Text}");

     Console.WriteLine();
     
      Console.WriteLine("Press enter to contine or type 'quit to quit.");
            var userInput = Console.ReadLine();
            if (userInput.ToLower() == "quit")
            return;
    }

   static void HideWord(Scripture scripture)
   {
    string[] words = scripture.Text.Split(' ');

    Random random = new Random();

    int wordsToHide = random.Next(1,2);

    for (int i = 0; i < wordsToHide; i++)
    {
        int wordIndexToHide = random.Next(words.Length);
        words[wordIndexToHide] = new string('_', words[wordIndexToHide].Length);
    }
    
    scripture.Text = string.Join(' ', words);

     //Console.WriteLine("Press enter to contine or type 'quit to quit");
        //var userInput = Console.ReadLine();
        //if (userInput.ToLower() == "quit")
        //return;
   }
    
    static bool AllWordsHidden(Scripture scripture)
    {
        return !scripture.Text.Contains('_');
    }

    static Scripture GetRandomScripture(List<Scripture> scriptures)
    {
        Random random = new Random();
        int randomIndex = random.Next(scriptures.Count);
        return scriptures[randomIndex];
    }
}