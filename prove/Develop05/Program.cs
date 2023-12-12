using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuestApp {
    public class Program
    {
        private static List<Goal> goals = new List<Goal>();
        private static int score = 0;

        static void Main(string[] args)
        {
            string filePath = "";

            while (true)
            {
                Console.Clear();
                DisplayMenu();

                string input = Console.ReadLine();
                int choice;

                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            CreateNewGoal();
                            break;
                        case 2:
                            ListGoals();
                            break;
                        case 3:
                            Console.WriteLine("Enter file path to save goals:");
                            filePath = Console.ReadLine();
                            SaveData(filePath);
                            break;
                        case 4:
                            Console.WriteLine("Enter file path to load goals:");
                            filePath = Console.ReadLine();
                            LoadData(filePath);
                            break;
                        case 5:
                            RecordEvent();
                            break;
                        case 6:
                            Console.WriteLine("Thank you for using Eternal Quest!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Eternal Quest");
            Console.WriteLine("----------------");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");
            Console.Write("Enter your choice: ");
        }

        private static void CreateNewGoal()
        {
            Console.Clear();

            Console.WriteLine("Select goal type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
            }

            Console.WriteLine("Enter goal name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter goal description:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter goal value:");
            int value = int.Parse(Console.ReadLine());

            Goal goal = CreateGoal(choice, name, description, value);
            if (goal != null)
            {
                goals.Add(goal);
                Console.WriteLine("Goal created successfully!");
            }
            else
            {
                Console.WriteLine("Error creating goal.");
            }
        }

        private static Goal CreateGoal(int type, string name, string description, int value)
        {
            switch (type)
            {
                case 1:
                    return new SimpleGoal(name, description, value);
                case 2:
                    return new EternalGoal(name, description, value);
                case 3:
                    Console.WriteLine("Enter target count:");
                    int targetCount = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter bonus value:");
                    int bonusValue = int.Parse(Console.ReadLine());

                    return new ChecklistGoal(name, description, value, targetCount, bonusValue);
                default:
                    return null;
            }
        }

        private static void ListGoals()
        {
            Console.Clear();

            if (goals.Count == 0)
            {
                Console.WriteLine("You haven't created any goals yet.");
            }
            else
            {
                Console.WriteLine("Your goals:");
                Console.WriteLine();

                foreach (var goal in goals)
                {
                    string status = goal.Completed ? "[X]" : "[ ]";
                    string progress = goal is ChecklistGoal checklistGoal ? $"Completed {checklistGoal.CurrentCount}/{checklistGoal.TargetCount} times" : "";

                    Console.WriteLine($"{status} {goal.Name} - {goal.Description} ({goal.Value}) {progress}");
                }
            }
        }

        private static void SaveData(string filePath)
        {
            FileManager.SaveGoals(filePath, goals, score);
            Console.WriteLine("Goals saved successfully!");
        }

        private static void LoadData(string filePath)
        {
            (List<Goal> loadedGoals, int loadedScore) = FileManager.LoadGoals(filePath);
            if (loadedGoals != null)
            {
                goals = loadedGoals;
                score = loadedScore;
                Console.WriteLine("Goals loaded successfully!");
            }
            else
            {
                Console.WriteLine("No goals found or error loading goals.");
            }
        }

        private static void RecordEvent()
        {
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals available to record an event.");
                return;
            }

            Console.WriteLine("Select the goal achieved:");

            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].Name}");
            }

            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= goals.Count)
            {
                Goal selectedGoal = goals[choice - 1];
                bool eventRecorded = selectedGoal.RecordEvent();
                
                if (eventRecorded)
                {
                    Console.WriteLine($"Event recorded for {selectedGoal.Name}. You earned {selectedGoal.Value} points!");
                }
                else
                {
                    Console.WriteLine("Error recording event.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}