using System;

namespace StudentRegistrationSystem
{
    public class Student
    {
        public string Name { get; set; }
        public string FacultyNumber { get; set; }
        public string Major { get; set; }
        public double AverageGrade { get; set; }
        //dotnet new winforms -n StudentRegistrationSystem
        public Student(string name, string facultyNumber, string major, double averageGrade)
        {
            Name = name;
            FacultyNumber = facultyNumber;
            Major = major;
            AverageGrade = averageGrade;
        }

        public override string ToString()
        {
            return $"{Name} ({FacultyNumber}) - {Major} - Среден успех: {AverageGrade:F2}";
        }
    }
}