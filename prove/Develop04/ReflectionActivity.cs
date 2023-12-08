using System;
using System.Threading;

public class ReflectionActivity
{
    private int durationInSeconds;
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you represented Jesus Christ in your actions."
    };

    private string[] reflectionQuestions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int durationInSeconds)
    {
        this.durationInSeconds = durationInSeconds;
    }

    public void Start()
    {
        int userInputDuration;
        do
        {
            Console.Write("Set duration in seconds (increments of 10): ");
        } while (!int.TryParse(Console.ReadLine(), out userInputDuration) || userInputDuration % 10 != 0 || userInputDuration <= 0);

        Console.WriteLine("Reflection Activity");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
        Console.WriteLine("This will help you recognize the power you have and how you can use it in other aspects of your life.");

        Console.WriteLine($"Prepare to begin... You have {userInputDuration} seconds.");
        Thread.Sleep(3000);

        Random rand = new Random();

        Console.Clear(); // Clear the initial message
        int index = rand.Next(prompts.Length);
        Console.WriteLine(prompts[index]);

        DateTime startTime = DateTime.Now;
        int questionIndex = 0;

        while ((DateTime.Now - startTime).TotalSeconds < userInputDuration && questionIndex < reflectionQuestions.Length)
        {
            Console.WriteLine(reflectionQuestions[questionIndex]);
            SpinSpinner();
            Thread.Sleep(10000); // Display each question for 10 seconds
            questionIndex++;
        }

        FinishActivity(userInputDuration);
    }

    private void SpinSpinner()
    {
        Thread spinnerThread = new Thread(() =>
        {
            char[] spinner = { '|', '/', '-', '\\' };
            int counter = 0;
            while (!Console.KeyAvailable)
            {
                Console.Write($"Processing... {spinner[counter % 4]}\r");
                Thread.Sleep(500);
                counter++;
            }
        });
        spinnerThread.Start();
    }

    private void FinishActivity(int userInputDuration)
    {
        Console.WriteLine($"Good job! You've completed the Reflection Activity for {userInputDuration} seconds.");
        Thread.Sleep(3000);
    }
}