using System;
using System.Collections.Generic;

public class Video
{
    public string _title;
    public string _author;
    public int _lengthSeconds;
    public List<Comment> comments = new List<Comment>();

    public Video(string titleValue, string authorValue, int lengthValue)
    {
        _title = titleValue;
        _author = authorValue;
        _lengthSeconds = lengthValue;
    }
     public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_lengthSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (Comment comment in comments)
        {
            Console.WriteLine($"  - {comment}");
        }
        Console.WriteLine();
    }

}