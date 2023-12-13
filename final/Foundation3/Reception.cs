using System;

namespace Foundation3
{
    public class Reception : Event
    {
        private string rsvpEmail;

        public Reception(string title, string description, DateTime date, string time, Address address, string rsvpEmail)
            : base(title, description, date, time, address)
        {
            this.rsvpEmail = rsvpEmail;
        }

        public override string StandardDetails()
        {
            return base.StandardDetails() + $"\nRSVP Email: {rsvpEmail}";
        }

        public override string FullDetails()
        {
            return $"{base.StandardDetails()}\nType of Event: Reception\nRSVP Email: {rsvpEmail}";
        }

        public override string ShortDescription()
        {
            return $"Reception: {Title}, Date: {Date.ToShortDateString()}";
        }
    }
}