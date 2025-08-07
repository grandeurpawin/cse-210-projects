using System;

public class Comment
{
    public string _commenterName;
    public string _commentText;

    public Comment(string name, string text)
    {
        _commenterName = name;
        _commentText = text;
    }

    public override string ToString()
    {
        return $"{_commenterName}: {_commentText}";
    }
}