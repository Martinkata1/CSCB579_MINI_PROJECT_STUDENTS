using System.Collections.Generic;
using System.Linq;

namespace StudentRegistrationSystem
{
    public class StudentService
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student s)
        {
            students.Add(s);
        }

        public bool RemoveStudent(string facultyNumber)
        {
            var s = students.FirstOrDefault(x => x.FacultyNumber == facultyNumber);
            if (s != null)
            {
                students.Remove(s);
                return true;
            }
            return false;
        }

        public Student? FindStudent(string facultyNumber)
        {
            return students.FirstOrDefault(x => x.FacultyNumber == facultyNumber);
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public void SortByName()
        {
            students = students.OrderBy(s => s.Name).ToList();
        }

        public void SortByAverageGrade()
        {
            students = students.OrderByDescending(s => s.AverageGrade).ToList();
        }
    }
}