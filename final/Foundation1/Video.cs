using System;
using System.Collections.Generic;

namespace Foundation1
{
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }
        private List<Comment> comments = new List<Comment>();

        public void AddComment(string commenterName, string commentText)
        {
            comments.Add(new Comment { CommenterName = commenterName, Text = commentText });
        }

        public int GetNumberOfComments()
        {
            return comments.Count;
        }

        public void DisplayVideoInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Length (seconds): {LengthInSeconds}");
            Console.WriteLine($"Number of comments: {GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (var comment in comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
