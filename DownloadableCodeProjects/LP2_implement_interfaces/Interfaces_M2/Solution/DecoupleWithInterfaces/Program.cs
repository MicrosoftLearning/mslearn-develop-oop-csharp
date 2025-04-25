namespace DecoupleWithInterfaces;

class Program
{
    static void Main(string[] args)
    {
        IPerson teacher = new Teacher { Name = "Helen Karu", Age = 35 };
        IPerson student1 = new Student { Name = "Eba Lencho", Age = 20 };
        IPerson student2 = new Student { Name = "Frederiek Eppink", Age = 22 };

        // Use the utility class
        PersonUtilities.PrintPersonDetails(teacher);
        PersonUtilities.PrintPersonDetails(student1);

        // Create a classroom and add students
        Classroom classroom = new Classroom();
        classroom.AddStudent((Student)student1);
        classroom.AddStudent((Student)student2);

        // Sort students by age
        classroom.SortStudentsByAge();

        Console.WriteLine("\nSorted Students by Age:");
        foreach (Student student in classroom)
        {
            student.DisplayInfo();
        }

        // Demonstrate ArgumentException for incompatible comparison
        try
        {
            Console.WriteLine("\nAttempting to compare a Student with a Teacher...");
            Student student = (Student)student1;
            int comparisonResult = student.CompareTo(teacher); // This will throw an exception
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}