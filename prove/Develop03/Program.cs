// using System;
// using System.Text.RegularExpressions;
// using System.Linq;

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("Enter the scripture reference:");
//         string scriptureReference = Console.ReadLine();

//         Console.WriteLine("Enter the scripture text:");
//         string scriptureText = Console.ReadLine();

//         Console.Clear();
//         DisplayScripture(scriptureReference, scriptureText);

//         Random random = new Random();
//         string[] words = Regex.Split(scriptureText, @"\s+");
//         bool[] hiddenWords = new bool[words.Length];

//         Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
//         string userInput = Console.ReadLine();

//         while (userInput.ToLower() != "quit")
//         {
//             int wordsLeft = hiddenWords.Count(wordHidden => !wordHidden);
//             if (wordsLeft == 0)
//             {
//                 Console.WriteLine("You have completed the scripture challenge. The program will close now.");
//                 break;
//             }

//             HideWords(random, words, hiddenWords);
//             Console.Clear();
//             DisplayScripture(scriptureReference, GetHiddenScripture(scriptureText, words, hiddenWords));

//             Console.WriteLine("\nPress enter to continue or type 'quit' to exit.");
//             userInput = Console.ReadLine();
//         }
//     }

//     static void DisplayScripture(string reference, string text)
//     {
//         Console.WriteLine($"Scripture Reference: {reference}\n");
//         Console.WriteLine(text);
//     }

//     static void HideWords(Random random, string[] words, bool[] hiddenWords)
//     {
//         int wordsToHide = random.Next(1, 4);
//         int wordsLeft = hiddenWords.Count(wordHidden => !wordHidden);

//         while (wordsToHide > 0 && wordsLeft > 0)
//         {
//             int wordIndex = random.Next(words.Length);
//             if (!hiddenWords[wordIndex])
//             {
//                 hiddenWords[wordIndex] = true;
//                 wordsToHide--;
//                 wordsLeft--;
//             }
//         }
//     }

//     static string GetHiddenScripture(string text, string[] words, bool[] hiddenWords)
//     {
//         string hiddenText = "";
//         for (int i = 0; i < words.Length; i++)
//         {
//             if (hiddenWords[i])
//             {
//                 hiddenText += new string('_', words[i].Length);
//             }
//             else
//             {
//                 hiddenText += words[i];
//             }
//             hiddenText += " ";
//         }
//         return hiddenText.Trim();
//     }
// }

using System;
using System.Text.RegularExpressions;

class Scripture
{
    private string reference;
    private string text;
    private Random random;
    private bool[] hiddenWords;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
        random = new Random();
        hiddenWords = new bool[Regex.Matches(text, @"\b\w+\b").Count];
    }

    public void Display()
    {
        Console.WriteLine($"Scripture Reference: {reference}\n");
        Console.WriteLine(text);
    }

    public void HideWords()
    {
        int wordsLeft = Array.FindAll(hiddenWords, x => !x).Length;
        int wordsToHide = random.Next(1, 4); // Hide 1 to 3 words

        while (wordsToHide > 0 && wordsLeft > 0)
        {
            int wordIndex = random.Next(hiddenWords.Length);
            if (!hiddenWords[wordIndex])
            {
                hiddenWords[wordIndex] = true;
                wordsToHide--;
                wordsLeft--;
            }
        }

        UpdateHiddenText();
    }

    public bool AllWordsHidden()
    {
        return Array.TrueForAll(hiddenWords, x => x);
    }

    private void UpdateHiddenText()
    {
        string[] words = Regex.Split(text, @"\b\w+\b");

        for (int i = 0; i < hiddenWords.Length; i++)
        {
            if (hiddenWords[i])
            {
                words[i] = new string('*', words[i].Length);
            }
        }

        text = string.Join("", words);
    }

    public string GetHiddenScripture()
    {
        return text;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the scripture reference:");
        string scriptureReference = Console.ReadLine();

        Console.WriteLine("Enter the scripture text:");
        string scriptureText = Console.ReadLine();

        Scripture scripture = new Scripture(scriptureReference, scriptureText);

        Console.Clear();
        scripture.Display();

        Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
        string userInput = Console.ReadLine();

        while (userInput.ToLower() != "quit" && !scripture.AllWordsHidden())
        {
            scripture.HideWords();
            Console.Clear();
            scripture.Display();

            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            userInput = Console.ReadLine();
        }
    }
}