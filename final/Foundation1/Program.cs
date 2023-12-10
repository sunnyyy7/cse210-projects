using System;
using System.Collections.Generic;

// Comment class to store information about a comment
class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }
}

// Video class to store information about a video
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> Comments { get; set; } = new List<Comment>();

    // Method to add a comment to the video
    public void AddComment(string commenterName, string commentText)
    {
        Comments.Add(new Comment { CommenterName = commenterName, CommentText = commentText });
    }

    // Method to return the number of comments
    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    // Method to display video information and comments
    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length (seconds): {LengthInSeconds}");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");

        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
        }

        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        // Create videos
        var video1 = new Video { Title = "Video 1", Author = "Author 1", LengthInSeconds = 300 };
        var video2 = new Video { Title = "Video 2", Author = "Author 2", LengthInSeconds = 240 };

        // Add comments to videos
        video1.AddComment("User1", "Great video!");
        video1.AddComment("User2", "Nice content!");

        video2.AddComment("User3", "Interesting topic!");
        video2.AddComment("User4", "Well explained!");

        // Create a list of videos
        var videos = new List<Video> { video1, video2 };

        // Display information for each video
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
