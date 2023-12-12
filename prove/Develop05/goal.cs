using System;
using System.Collections.Generic;

namespace EternalQuestApp
{
    public abstract class Goal
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Value { get; protected set; }
        public bool Completed { get; protected set; }

        public Goal(string name, string description, int value)
        {
            Name = name;
            Description = description;
            Value = value;
            Completed = false;
        }

        public abstract bool RecordEvent();
    }
}