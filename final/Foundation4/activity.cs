using System;

public class Activity
{
    protected DateTime date;
    protected int durationInMinutes;

    public Activity(DateTime date, int duration)
    {
        this.date = date;
        this.durationInMinutes = duration;
    }
    
    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return "";
    }

    protected string FormatDate()
    {
        return date.ToString("dd MMM yyyy");
    }

    protected string FormatSummary(string activityType, double distance, double speed, double pace, string unit)
    {
        return $"{FormatDate()} {activityType} ({durationInMinutes} min) - Distance: {distance:F2} {unit}, Speed: {speed:F2} {unit}/hr, Pace: {pace:F2} min per {unit}";
    }
}