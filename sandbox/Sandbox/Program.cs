using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {Person p1=new Person{};
    p1._firstname="mukisa";
    p1._lastname="edrine";
    p1._age=20;

    Person p2=new Person{};
    p2._firstname="namirembe";
    p2._lastname="fatuma";
    p2._age=22;

    List<Person>people=new List<Person>{};
    people.Add(p1);
    people.Add(p2);

    foreach(Person p in people)
    {
        Console.WriteLine(p._firstname);
    }
    

        
    SaveToFile(people);   

    List<Person> newpeople= ReadFromFile();
    foreach (Person p in newpeople)
    {
        Console.WriteLine(p._lastname);
    }



    }

    private static List<Person> ReadFromFile()
    {
        throw new NotImplementedException();
    }

    public static void SaveToFile(List<Person>people)
    {
        Console.WriteLine("saving to file");

        string filename="people.txt";

        using(StreamWriter outputFile=new StreamWriter(filename))
        {
            foreach(Person p in people)
            {
                outputFile.WriteLine($"{p._firstname}--{p._lastname}--{p._age}");
            }
        }

    }
    public static List<Person> ReadFromLine()
    {
        Console.WriteLine("reading from the flie");
        List<Person> people=new List<Person>();
        string filename="people.txt";

        string[] lines=System.IO.File.ReadAllLines(filename);
        foreach(string line in lines)
        {
            Console.WriteLine(line);
        }

        return people;
    }
}

