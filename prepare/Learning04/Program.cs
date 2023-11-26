using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Ashton Kelce", "Addition");
        Console.WriteLine(a1.GetSummary());

        MathAssignment a2 = new MathAssignment("Sylisa Beck", "Division", "4.1", "1-10");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Ashlynn Hall", "WWII", "Leaders of the War");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}