using System;
using System.Collections.Generic;

namespace EternalQuestApp {
    public class ChecklistGoal : Goal
    {
        public int TargetCount { get; private set; }
        public int CurrentCount { get; private set; }

        public ChecklistGoal(string name, string description, int value, int targetCount, int currentCount) : base(name, description, value)
        {
            TargetCount = targetCount;
            CurrentCount = 0;
        }

        public override bool RecordEvent()
        {
            CurrentCount++;
            Completed = CurrentCount == TargetCount;

            if (Completed)
            {
                // Bonus value awarded for completing the checklist
                Value *= 2;
            }

            return true;
        }
    }
}