using System;
using System.Text.RegularExpressions;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the scripture reference:");
        string scriptureReference = Console.ReadLine();

        Console.WriteLine("Enter the scripture text:");
        string scriptureText = Console.ReadLine();

        Console.Clear();
        DisplayScripture(scriptureReference, scriptureText);

        Random random = new Random();
        string[] words = Regex.Split(scriptureText, @"\s+");
        bool[] hiddenWords = new bool[words.Length];

        Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
        string userInput = Console.ReadLine();

        while (userInput.ToLower() != "quit")
        {
            int wordsLeft = hiddenWords.Count(wordHidden => !wordHidden);
            if (wordsLeft == 0)
            {
                Console.WriteLine("You have completed the scripture challenge. The program will close now.");
                break;
            }

            HideWords(random, words, hiddenWords);
            Console.Clear();
            DisplayScripture(scriptureReference, GetHiddenScripture(scriptureText, words, hiddenWords));

            Console.WriteLine("\nPress enter to continue or type 'quit' to exit.");
            userInput = Console.ReadLine();
        }
    }

    static void DisplayScripture(string reference, string text)
    {
        Console.WriteLine($"Scripture Reference: {reference}\n");
        Console.WriteLine(text);
    }

    static void HideWords(Random random, string[] words, bool[] hiddenWords)
    {
        int wordsToHide = random.Next(1, 4);
        int wordsLeft = hiddenWords.Count(wordHidden => !wordHidden);

        while (wordsToHide > 0 && wordsLeft > 0)
        {
            int wordIndex = random.Next(words.Length);
            if (!hiddenWords[wordIndex])
            {
                hiddenWords[wordIndex] = true;
                wordsToHide--;
                wordsLeft--;
            }
        }
    }

    static string GetHiddenScripture(string text, string[] words, bool[] hiddenWords)
    {
        string hiddenText = "";
        for (int i = 0; i < words.Length; i++)
        {
            if (hiddenWords[i])
            {
                hiddenText += new string('_', words[i].Length);
            }
            else
            {
                hiddenText += words[i];
            }
            hiddenText += " ";
        }
        return hiddenText.Trim();
    }
}