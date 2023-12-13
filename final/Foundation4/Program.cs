using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>();

        Activity runningActivity = new Running(new DateTime(2023, 12, 12), 30, 3.0);
        Activity cyclingActivity = new Cycling(new DateTime(2023, 12, 12), 45, 15.0);
        Activity swimmingActivity = new Swimming(new DateTime(2023, 12, 12), 40, 10);

        activities.Add(runningActivity);
        activities.Add(cyclingActivity);
        activities.Add(swimmingActivity);

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}