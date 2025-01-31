using System;

using System.Collections;

using System.IO;


class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string prompt,string Response)
    {
        Date=DateTime.Now.ToShortDateString();
        prompt=prompt;
        Response=Response;

    }

    public override string ToString()
    {
        return $"Date:{Date}\nPrompt:{Prompt}\nResponse:{Response}\n";

    }

}

class Journal
{
    private List<Entry>entries=new List<Entry>();
    private List<string>prompts=new List<string>
    {
       "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?" 
    };
    public void AddEntry()
    {
        Random rnd=new Random();
        string prompt=prompts[rnd.Next(prompts.Count)];
        Console.WriteLine($"\n{prompt}");
        Console.Write("your response: ");
        string response=Console.ReadLine();
        entries.Add(new Entry(prompt,response));
        Console.WriteLine("Entry added succesfully!\n");

    }
    public void DisplayEntrries()
    {
        if (entries.Count==0)
        {
            Console.WriteLine("No journal entries found!");
            return;
        }
        Console.WriteLine("\nJournal Entries:");
        foreach(var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }
    public void SaveToFile()
    {
        Console.Write("Enter filename: ");
        string filename=Console.ReadLine();
        using(StreamWriter writer=new StreamWriter(filename))
        {
            foreach(var entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");

            }

        }
        Console.WriteLine("Journal saved successfully!\n");
    }
    public void LoadFromFile()
    {
        Console.Write("Enter filename to load journal: ");
        string filename=Console.ReadLine();
        if (File.Exists(filename))
        {
            entries.Clear();
            string[]lines=File.ReadAllLines(filename);
            foreach(string line in lines)
            {
                string[]parts =line.Split('|');
                if(parts.Length==3)
                {
                    entries.Add(new Entry(parts[1],parts[2]){Date=parts[0]});

                }
            }
            Console.WriteLine("Journal loaded succesfully!\n");
        }
        else
        {
            Console.WriteLine("File not found\n");
        }
    }
}

class Program
{
    static void Main()
    {
        Journal journal=new Journal();
        while(true)
        {
           Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                     journal.AddEntry();
                     break;
                case "2":
                     journal.DisplayEntrries();
                     break;
                case "3":
                     journal.SaveToFile();
                     break;
                case "4":
                     journal.LoadFromFile();
                     break;
                case "5":
                     return;
                default:
                     Console.WriteLine("invalid choice");
                     break;

            }
  
        }
    }
}