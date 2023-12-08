using System;
using System.Threading;

public class BreathingActivity
{
    public void Start()
    {
        Console.WriteLine("Breathing Activity");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.");
        Console.WriteLine("Clear your mind and focus on your breathing.");

        int durationInSeconds = GetDurationFromUser();
        PerformBreathingExercise(durationInSeconds);

        Console.WriteLine($"Good job! You've completed the Breathing Activity for {durationInSeconds} seconds.");
        Thread.Sleep(3000);
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

    private void PerformBreathingExercise(int durationInSeconds)
    {
        Console.WriteLine($"Starting breathing exercise for {durationInSeconds} seconds.");
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000);

        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < durationInSeconds)
        {
            Console.WriteLine("Breathe in...");
            Countdown(5);

            if ((DateTime.Now - startTime).TotalSeconds >= durationInSeconds)
                break;

            Console.WriteLine("Breathe out...");
            Countdown(5);
        }
    }

    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}