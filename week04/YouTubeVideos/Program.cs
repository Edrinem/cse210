using System;
using System.Collections.Generic;

// Comment class to store user comments
class Comment
{
    public string Author { get; set; }
    public string Text { get; set; }

    public Comment(string author, string text)
    {
        Author = author;
        Text = text;
    }
}

// Video class to store video information and comments
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (Comment c in comments)
        {
            Console.WriteLine($"- {c.Author}: {c.Text}");
        }
        Console.WriteLine("--------------------------------");
    }
}

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        // Creating sample videos
        Video video1 = new Video("How to Code in C#", "Edrine Code", 600);
        video1.AddComment(new Comment("Mark", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very informative."));
        video1.AddComment(new Comment("Angel", "Helped me a lot, thanks!"));

        Video video2 = new Video("Cooking Pasta Like a Chef", "Foodie Channel", 480);
        video2.AddComment(new Comment("Daniel", "Yummy!"));
        video2.AddComment(new Comment("Emma", "I tried this, it was amazing!"));
        video2.AddComment(new Comment("Pretty","you have really taught how to cook"));

        Video video3 = new Video("Traveling in Uganda", "Pearl Safaris", 720);
        video3.AddComment(new Comment("Frank", "Uganda is on my bucket list!"));
        video3.AddComment(new Comment("Grace", "Awesome travel tips."));
        video3.AddComment(new Comment("Hank", "Can't wait to visit!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Displaying details of each video
        foreach (Video video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}
