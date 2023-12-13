using System;

namespace Foundation3
{
    public class OutdoorGathering : Event
    {
        private string weatherForecast;

        public OutdoorGathering(string title, string description, DateTime date, string time, Address address, string weatherForecast)
            : base(title, description, date, time, address)
        {
            this.weatherForecast = weatherForecast;
        }

        public override string StandardDetails()
        {
            return base.StandardDetails() + $"\nWeather Forecast: {weatherForecast}";
        }

        public override string FullDetails()
        {
            return $"{base.StandardDetails()}\nType of Event: Outdoor Gathering\nWeather Forecast: {weatherForecast}";
        }

        public override string ShortDescription()
        {
            return $"Outdoor Gathering: {Title}, Date: {Date.ToShortDateString()}";
        }
    }
}