public class Teacher : IPerson
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; } = 0;

    public string Role => "Teacher";

    public void DisplayInfo()
    {
        Console.WriteLine($"Teacher Name: {Name}, Age: {Age}");
    }

    public void Greet()
    {
        Console.WriteLine($"Hello, I am {Name}, a teacher with {Age} years of experience.");
    }
}