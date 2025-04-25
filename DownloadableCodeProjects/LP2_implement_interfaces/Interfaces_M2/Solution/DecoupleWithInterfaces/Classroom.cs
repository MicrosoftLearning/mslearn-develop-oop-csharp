namespace DecoupleWithInterfaces;
using System.Collections;
using System.Collections.Generic;

public class Classroom : IEnumerable<Student>
{
    private List<Student> students = new List<Student>();

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void SortStudentsByAge()
    {
        students.Sort(); // Uses the IComparable implementation in Student
    }

    public IEnumerator<Student> GetEnumerator()
    {
        return students.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}