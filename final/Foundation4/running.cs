using System;

public class Running : Activity
{
    private double distance;

    public Running(DateTime date, int duration, double distance) : base(date, duration)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / durationInMinutes) * 60;
    }

    public override double GetPace()
    {
        return durationInMinutes / distance;
    }

    public override string GetSummary()
    {
        double speed = GetSpeed();
        double pace = GetPace();
        return FormatSummary("Running", distance, speed, pace, "miles");
    }
}