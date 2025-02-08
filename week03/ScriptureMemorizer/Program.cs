using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        Scripture scripture = new Scripture("Matthew 7:7", "Ask, and it shall be given you; seek, and ye shall find; knock, and it shall be opened unto you.");
        
        while (!scripture.IsFullyHidden())
        {
            Console.Clear();
            scripture.Display();
            Console.WriteLine("\nPress ENTER to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();
            
            if (input.ToLower() == "quit")
                break;
            
            scripture.HideWords(3); // Hide 3 words at a time
        }
        
        Console.Clear();
        scripture.Display();
        Console.WriteLine("\nWell done! You have memorized the scripture.");
    }
}

class Scripture
{
    private Reference Reference;
    private List<Word> Words;

    public Scripture(string reference, string text)
    {
        Reference = new Reference(reference);
        Words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void Display()
    {
        Console.Write(Reference.GetText() + " - ");
        foreach (var word in Words)
        {
            Console.Write(word.Display() + " ");
        }
        Console.WriteLine();
    }

    public void HideWords(int count)
    {
        Random rand = new Random();
        List<Word> visibleWords = Words.Where(w => !w.IsHidden()).ToList();
        
        if (visibleWords.Count == 0) return;
        
        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsFullyHidden()
    {
        return Words.All(w => w.IsHidden());
    }
}

class Reference
{
    private string Text;
    public Reference(string text)
    {
        Text = text;
    }
    public string GetText()
    {
        return Text;
    }
}

class Word
{
    private string Text;
    private bool Hidden;
    
    public Word(string text)
    {
        Text = text;
        Hidden = false;
    }

    public void Hide()
    {
        Hidden = true;
    }

    public bool IsHidden()
    {
        return Hidden;
    }
    
    public string Display()
    {
        return Hidden ? new string('_', Text.Length) : Text;
    }
}
