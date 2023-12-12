using System;
using System.Collections.Generic;

namespace EternalQuestApp {
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int value) : base(name, description, value)
        {
        }

        public override bool RecordEvent()
        {
            Completed = true;
            return true;
        }
    }
}