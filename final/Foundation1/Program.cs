using System;
using System.Collections.Generic;

namespace Foundation1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            Video video1 = new Video
            {
                Title = "Horse Jumps Over Pallets of Sprite",
                Author = "Horsegirl1567",
                LengthInSeconds = 245 
            };
            video1.AddComment("sodafan99", "That is HILARIOUS!");
            video1.AddComment("bigmemequeen", "Hahaha, LOL!");
            video1.AddComment("4m4nd4", "that is so dangerous and this video is not funny im disgusted");

            Video video2 = new Video
            {
                Title = "Ranking my Favorite Sodas",
                Author = "taylorswift",
                LengthInSeconds = 1568
            };
            video2.AddComment("taylorswiftfan13", "Sprite is my favorite too! #yasss");
            video2.AddComment("ihatetaylorswift31", "Ew, sprite??????");
            video2.AddComment("gerome78203", "ha i luv u taylor plz go to prom w/ me i will buy u sprite :)");

            Video video3 = new Video
            {
                Title = "Blindfolded Soda Challenge!!!",
                Author = "brittanyspears",
                LengthInSeconds = 789
            };
            video3.AddComment("melanie4567", "I have never tried soda before hehe");
            video3.AddComment("ilovesprite44280", "I could NEVER get Sprite wrong...");
            video3.AddComment("scarygirl21", "I could beat you in this challenge any day.");

            videos.Add(video1);
            videos.Add(video2);
            videos.Add(video3);

            foreach (var video in videos)
            {
                video.DisplayVideoInfo();
            }

            Console.ReadLine();
        }
    }
}
