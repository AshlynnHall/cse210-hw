using System;

namespace Foundation3
{
    class Program
    {
        static void Main()
        {
            Address eventAddress = new Address("4949 Yuba St", "Yuba City", "CA", "58647");

            Event lectureEvent = new Lecture("Taylor Swift", "Taylor Swift will be speaking with the Yuba City community about the new LDS Temple and how the church changed her life!",
                                               new DateTime(2023, 12, 15), "10:00 AM", eventAddress,
                                               "Ashlynn Hall", 50);

            Event receptionEvent = new Reception("Ashlynn and Harry Styles Wedding", "Join us for the union of Ashlynn and Harry Styles' through marriage!",
                                                     new DateTime(2023, 12, 20), "7:00 PM", eventAddress,
                                                     "rsvp@ashlynnandharry.com");

            Event gatheringEvent = new OutdoorGathering("Ashlynn's BBQ Kickback", "Free Hot Dogs, Swimming, and Dole Whip!",
                                                                   new DateTime(2023, 12, 25), "2:00 PM", eventAddress,
                                                                   "Sunny and 75");

            Console.WriteLine("Standard Details:");
            Console.WriteLine("Lecture:");
            Console.WriteLine(lectureEvent.StandardDetails());
            Console.WriteLine("\nReception:");
            Console.WriteLine(receptionEvent.StandardDetails());
            Console.WriteLine("\nOutdoor Gathering:");
            Console.WriteLine(gatheringEvent.StandardDetails());


            Console.WriteLine("\nFull Details:");
            Console.WriteLine("Lecture:");
            Console.WriteLine(((Lecture)lectureEvent).FullDetails());
            Console.WriteLine("\nReception:");
            Console.WriteLine(((Reception)receptionEvent).FullDetails());
            Console.WriteLine("\nOutdoor Gathering:");
            Console.WriteLine(((OutdoorGathering)gatheringEvent).FullDetails());

            Console.WriteLine("\nShort Descriptions:");
            Console.WriteLine("Lecture:");
            Console.WriteLine(lectureEvent.ShortDescription());
            Console.WriteLine("\nReception:");
            Console.WriteLine(receptionEvent.ShortDescription());
            Console.WriteLine("\nOutdoor Gathering:");
            Console.WriteLine(gatheringEvent.ShortDescription());


            Console.ReadLine();
        }
    }
}