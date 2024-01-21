using System;
using System.Runtime.InteropServices;

using System;
using System.Collections.Generic;
using System.IO;

public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string DateTimeString { get; set; }

    public Entry(string prompt, string response, DateTime dateTime)
    {
        Prompt = prompt;
        Response = response;
        DateTimeString = dateTime.ToString();
    }

    public override string ToString()
    {
        return $"{Prompt}\nResponse: {Response}\nDate and Time: {DateTimeString}\n";
    }
}

public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(string prompt, string response, DateTime dateTime)
    {
        Entry entry = new Entry(prompt, response, dateTime);
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        Console.WriteLine("Journal Entries:");
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string fileName)
    {
        try
        {
            List<string> lines = new List<string>();
            foreach (var entry in entries)
            {
                lines.Add(entry.ToString());
            }
            File.WriteAllLines(fileName, lines);
            Console.WriteLine($"Journal saved to {fileName} successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving journal: {e.Message}");
        }
    }

    public void LoadFromFile(string fileName)
    {
        try
        {
            List<string> lines = new List<string>(File.ReadAllLines(fileName));
            foreach (var line in lines)
            {
                string[] parts = line.Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 3)
                {
                    string prompt = parts[0];
                    string response = parts[1].Substring("Response: ".Length);
                    string dateTimeString = parts[2].Substring("Date and Time: ".Length);
                    DateTime dateTime = DateTime.Parse(dateTimeString);
                    AddEntry(prompt, response, dateTime);
                }
            }
            Console.WriteLine($"Journal loaded from {fileName} successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading journal: {e.Message}");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Welcome to MyJourney Journal!");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Exit");
        Console.WriteLine();

        Journal myJournal = new Journal();

        while (true)
        {
            Console.Write("Please select an option (1-5): ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                WriteNewEntry(myJournal);
            }
            else if (option == "2")
            {
                myJournal.DisplayEntries();
            }
            else if (option == "3")
            {
                SaveJournalToFile(myJournal);
            }
            else if (option == "4")
            {
                LoadJournalFromFile(myJournal);
            }
            else if (option == "5")
            {
                Console.WriteLine("Goodbye!");
                return;
            }
            else
            {
                Console.WriteLine("Invalid option. Please enter a number from 1 to 5.");
            }

            Console.WriteLine();
        }
    }

    static void WriteNewEntry(Journal journal)
    {
        string[] prompts = {
            "What emotion was most felt today and why?",
            "Leave a short message for your future self.",
            "What's something you needed to hear today?",
            "What's something you admire about your younger self?",
            "What's something you're looking forward to?",
            "What are you grateful for?",
            "What kind of person do you aspire to be?",
            "Has anyone inspired you to do something?",
            "What do you think about love?",
            "Which was your best birthday ever and why?",
            "What was Christmas like as a kid?",
            "Traditions you'll start/do with your family?"
        };

        Random random = new Random();
        int randomIndex = random.Next(prompts.Length);
        string selectedPrompt = prompts[randomIndex];

        Console.WriteLine($"Prompt: {selectedPrompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        DateTime dateTimeNow = DateTime.Now;
        journal.AddEntry(selectedPrompt, response, dateTimeNow);

        Console.WriteLine("Entry saved successfully!");
    }

    static void SaveJournalToFile(Journal journal)
    {
        Console.Write("Enter a filename to save the journal: ");
        string fileName = Console.ReadLine();
        journal.SaveToFile(fileName);
    }

    static void LoadJournalFromFile(Journal journal)
    {
        Console.Write("Enter a filename to load the journal: ");
        string fileName = Console.ReadLine();
        journal.LoadFromFile(fileName);
    }
}
