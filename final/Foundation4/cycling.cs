using System;

public class Cycling : Activity
{
    private double speed;

    public Cycling(DateTime date, int duration, double speed) : base(date, duration)
    {
        this.speed = speed;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetDistance()
    {
        return speed * durationInMinutes / 60;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }

    public override string GetSummary()
    {
        double distance = GetDistance();
        double pace = GetPace();
        return FormatSummary("Cycling", distance, speed, pace, "miles");
    }
}