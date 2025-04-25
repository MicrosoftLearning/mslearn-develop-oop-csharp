namespace DecoupleWithInterfaces;

public class Student : IPerson, IComparable
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; } = 0;

    public string Role => "Student";

    public void DisplayInfo()
    {
        Console.WriteLine($"Student Name: {Name}, Age: {Age}");
    }

    public int CompareTo(object? obj)
    {
        // Explicitly check if obj is null
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj), "Cannot compare to a null object.");
        }

        // Explicitly check if obj is of type Student
        if (!(obj is Student))
        {
            throw new ArgumentException(nameof(obj), "The object being compared must be of type Student.");
        }

        // Explicitly cast obj to Student
        Student other = (Student)obj;

        // Compare the Age property
        return this.Age.CompareTo(other.Age);
    }
}