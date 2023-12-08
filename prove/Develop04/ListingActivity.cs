using System;
using System.Threading;

public class ListingActivity
{
    private int durationInSeconds;
    private string[] listingPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int durationInSeconds)
    {
        this.durationInSeconds = durationInSeconds;
    }

    public void Start()
    {
        Console.WriteLine("Listing Activity");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        Console.WriteLine("Set duration in seconds (increments of 10): ");
        durationInSeconds = GetDurationFromUser();

        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000);

        Random rand = new Random();
        int index = rand.Next(listingPrompts.Length);
        Console.WriteLine(listingPrompts[index]);

        Console.WriteLine("Starting in:");
        Countdown(5);

        Console.WriteLine("Start listing items...");
        int itemCount = RecordItems();

        Console.WriteLine($"You listed {itemCount} items.");

        FinishActivity();
    }

    private int GetDurationFromUser()
    {
        int duration;
        do
        {
            Console.Write("Set duration in seconds (increments of 10): ");
        } while (!int.TryParse(Console.ReadLine(), out duration) || duration % 10 != 0 || duration <= 0);

        return duration;
    }

    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine("\n");
    }

    private int RecordItems()
    {
        int itemCount = 0;
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < durationInSeconds)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) 
                break;
            itemCount++;
        }

        return itemCount;
    }

    private void FinishActivity()
    {
        Console.WriteLine($"Good job! You've completed the Listing Activity for {durationInSeconds} seconds.");
        Thread.Sleep(3000);
    }
}
