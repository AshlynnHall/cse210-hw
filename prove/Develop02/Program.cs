using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _writeNewEntry(journal);
                    break;
                case "2":
                    _displayJournal(journal);
                    break;
                case "3":
                    _saveJournalToFile(journal);
                    break;
                case "4":
                    _loadJournalFromFile(journal);
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }
        }
    }

    static void _writeNewEntry(Journal journal)
    {
        string randomPrompt = journal.GetRandomPrompt();

        Console.WriteLine($"Prompt: {randomPrompt}");

        Console.Write("Enter your response: ");
        string response = Console.ReadLine();

        Console.Write("Enter the date: ");
        string date = Console.ReadLine();

        Entry newEntry = new Entry(date, randomPrompt, response);
        journal.AddEntry(newEntry);

        Console.WriteLine("Entry added successfully!\n");
    }

    static void _displayJournal(Journal journal)
    {
        Console.WriteLine("Journal Entries:\n");

        foreach (Entry entry in journal.Entries)
        {
            Console.WriteLine($"Date: {entry.Date}, Prompt: {entry.Prompt}, Response: {entry.Response}\n");
        }
    }

    static void _saveJournalToFile(Journal journal)
    {
        Console.Write("Enter the filename to save the journal: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in journal.Entries)
            {
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }

        Console.WriteLine($"Journal saved to {filename} successfully!\n");
    }

    static void _loadJournalFromFile(Journal journal)
    {
        Console.Write("Enter the filename to load the journal: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            List<Entry> entries = new List<Entry>();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string date = parts[0];
                    string prompt = parts[1];
                    string response = parts[2];
                    entries.Add(new Entry(date, prompt, response));
                }
            }

            journal.LoadEntries(entries);
            Console.WriteLine($"Journal loaded from {filename} successfully!\n");
        }
        else
        {
            Console.WriteLine($"File {filename} not found.\n");
        }
    }
}

class Entry
{
    public string Date { get; }
    public string Prompt { get; }
    public string Response { get; }

    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }
}

class Journal
{
    private List<Entry> entries;
    private List<string> prompts;
    private Random random;

    public List<Entry> Entries => entries;

    public Journal()
    {
        entries = new List<Entry>();
        prompts = new List<string>
        {
            "What made you happy today?",
            "What was hard today and how did you get through it?",
            "How did God bless you today?",
            "What was your favorite activity of the day?",
            "What is one thing you want to remember from today?"
        };
        random = new Random();
    }

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void LoadEntries(List<Entry> loadedEntries)
    {
        entries = loadedEntries;
    }

    public string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}