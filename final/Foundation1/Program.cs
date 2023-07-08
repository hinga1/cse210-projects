using System;
using System.Collections.Generic;

// Base class Video
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
}

// Subclass Comment inheriting from Video
class Comment : Video
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }
}

// YouTubeVideoManager class to manage videos and comments
class YouTubeVideoManager
{
    private List<Video> videos;
    private List<Comment> comments;

    public YouTubeVideoManager()
    {
        videos = new List<Video>();
        comments = new List<Comment>();
    }

    public void AddVideo(Video video)
    {
        videos.Add(video);
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount(Video video)
    {
        int count = 0;
        foreach (Comment comment in comments)
        {
            if (comment.Title == video.Title && comment.Author == video.Author && comment.Length == video.Length)
                count++;
        }
        return count;
    }

    public void DisplayVideoInfoWithComments(Video video)
    {
        Console.WriteLine("Video Title: " + video.Title);
        Console.WriteLine("Author: " + video.Author);
        Console.WriteLine("Length: " + video.Length + " minutes");

        Console.WriteLine("Comments:");
        foreach (Comment comment in comments)
        {
            if (comment.Title == video.Title && comment.Author == video.Author && comment.Length == video.Length)
            {
                Console.WriteLine("Commenter: " + comment.CommenterName);
                Console.WriteLine("Comment: " + comment.CommentText);
                Console.WriteLine();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        YouTubeVideoManager videoManager = new YouTubeVideoManager();

        // Creating videos
        Video video1 = new Video
        {
            Title = "Video 1",
            Author = "Author 1",
            Length = 5
        };

        Video video2 = new Video
        {
            Title = "Video 2",
            Author = "Author 2",
            Length = 10
        };

        // Adding videos
        videoManager.AddVideo(video1);
        videoManager.AddVideo(video2);

        // Adding comments
        Comment comment1 = new Comment
        {
            Title = "Video 1",
            Author = "Author 1",
            Length = 5,
            CommenterName = "User 1",
            CommentText = "Great video!"
        };

        Comment comment2 = new Comment
        {
            Title = "Video 1",
            Author = "Author 1",
            Length = 5,
            CommenterName = "User 2",
            CommentText = "Nice content!"
        };

        Comment comment3 = new Comment
        {
            Title = "Video 2",
            Author = "Author 2",
            Length = 10,
            CommenterName = "User 3",
            CommentText = "Very informative!"
        };

        videoManager.AddComment(comment1);
        videoManager.AddComment(comment2);
        videoManager.AddComment(comment3);

        // Retrieving comment count
        int commentCount = videoManager.GetCommentCount(video1);
        Console.WriteLine("Comment count for Video 1: " + commentCount);

        // Displaying video info with comments
        videoManager.DisplayVideoInfoWithComments(video1);

        Console.ReadLine();
    }
}
