using System;

class Program
{
    static void Main(string[] args)
    {
        
       Video video1 = new Video("Unboxing Smartwatch", "TechGuru", 480);
        video1.AddComment(new Comment("Alice", "Nice product showcase!"));
        video1.AddComment(new Comment("Bob", "Does it support GPS?"));
        video1.AddComment(new Comment("Charlie", "Buying one now!"));

        Video video2 = new Video("Morning Coffee Routine", "CafeVibes", 300);
        video2.AddComment(new Comment("Dave", "Love the ambiance"));
        video2.AddComment(new Comment("Eve", "Which coffee grinder is that?"));
        video2.AddComment(new Comment("Frank", "Perfect start to the day"));

        Video video3 = new Video("Office Desk Setup", "ModernSpaces", 600);
        video3.AddComment(new Comment("Grace", "Where's the keyboard from?"));
        video3.AddComment(new Comment("Hank", "Super clean layout"));
        video3.AddComment(new Comment("Ivy", "Love the monitor stand"));

        Video video4 = new Video("Running Shoes Review", "AthleteZone", 720);
        video4.AddComment(new Comment("Jake", "Great breakdown of features"));
        video4.AddComment(new Comment("Kara", "Comfortable for long runs?"));
        video4.AddComment(new Comment("Leo", "I'm convinced—I'm getting these"));

        List<Video> videoLibrary = new List<Video> { video1, video2, video3, video4 };

        foreach (Video video in videoLibrary)
        {
            video.DisplayInfo();
        }

    }
}