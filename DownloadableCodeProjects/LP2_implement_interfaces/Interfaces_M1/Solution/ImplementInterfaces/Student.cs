namespace ImplementInterfaces
{
    public class Student : IPerson
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; } = 0;

        public void DisplayInfo()
        {
            Console.WriteLine($"Student Name: {Name}, Age: {Age}");
        }
    }
}