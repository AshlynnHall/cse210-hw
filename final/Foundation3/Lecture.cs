using System;

namespace Foundation3
{
    public class Lecture : Event
    {
        private string speaker;
        private int capacity;

        public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity)
            : base(title, description, date, time, address)
        {
            this.speaker = speaker;
            this.capacity = capacity;
        }

        public override string StandardDetails()
        {
            return base.StandardDetails() + $"\nSpeaker: {speaker}\nCapacity: {capacity}";
        }

        public override string FullDetails()
        {
            return $"{base.StandardDetails()}\nType of Event: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
        }

        public override string ShortDescription()
        {
            return $"Lecture: {Title}, Date: {Date.ToShortDateString()}";
        }
    }
}