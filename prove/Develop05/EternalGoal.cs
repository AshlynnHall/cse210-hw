using System;
using System.Collections.Generic;

namespace EternalQuestApp {
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int value) : base(name, description, value)
        {
        }

        public override bool RecordEvent()
        {
            Completed = false;
            return true;
        }
    }
}