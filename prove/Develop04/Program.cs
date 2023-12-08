using System;

class Program
{
    static void Main(string[] args)
    {
        int duration = 60;

        Console.WriteLine("Mindfulness Activities:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.Write("Choose an activity (1-3): ");

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            switch (choice)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Start();
                    break;
                case 2:
                    ReflectionActivity reflection = new ReflectionActivity(duration);
                    reflection.Start();
                    break;
                case 3:
                    ListingActivity listing = new ListingActivity(duration);
                    listing.Start();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
}