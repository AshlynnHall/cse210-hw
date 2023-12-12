using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuestApp {
    public static class FileManager
    {
        public static void SaveGoals(string filePath, List<Goal> goals, int score)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(score);
                foreach (var goal in goals)
                {
                    string goalType = goal.GetType().Name;
                    writer.WriteLine($"{goalType},{goal.Name},{goal.Description},{goal.Value},{goal.Completed}");
                    if (goal is ChecklistGoal checklistGoal)
                    {
                        writer.WriteLine(checklistGoal.TargetCount);
                        writer.WriteLine(checklistGoal.CurrentCount);
                    }
                }
            }
        }

        public static (List<Goal>, int) LoadGoals(string filePath)
        {
            List<Goal> goals = new List<Goal>();
            int score = 0;

            if (!File.Exists(filePath))
            {
                return (goals, score);
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                score = int.Parse(reader.ReadLine());
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(',');

                    Goal goal = CreateGoalFromData(parts);
                    if (goal != null)
                    {
                        goals.Add(goal);
                    }
                }
            }

            return (goals, score);
        }

        private static Goal CreateGoalFromData(string[] parts)
        {
            string goalType = parts[0];
            string name = parts[1];
            string description = parts[2];
            int value = int.Parse(parts[3]);
            bool completed = bool.Parse(parts[4]);

            switch (goalType)
            {
                case "SimpleGoal":
                    return new SimpleGoal(name, description, value);
                case "EternalGoal":
                    return new EternalGoal(name, description, value);
                case "ChecklistGoal":
                    if (parts.Length >= 7) // Checking if there are enough parts for ChecklistGoal
                    {
                        int targetCount = int.Parse(parts[5]);
                        int currentCount = int.Parse(parts[6]);
                        return new ChecklistGoal(name, description, value, targetCount, currentCount);
                    }
                    else
                    {
                        // Handle insufficient data for ChecklistGoal
                        // You can throw an exception or handle it based on your program's logic
                        return null;
                    }
                default:
                    return null;
            }
        }
    }
}