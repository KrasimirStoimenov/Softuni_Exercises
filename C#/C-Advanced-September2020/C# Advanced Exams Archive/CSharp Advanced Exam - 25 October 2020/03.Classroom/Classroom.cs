using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }
        public int Capacity { get; set; }
        public int Count => this.students.Count;
        public string RegisterStudent(Student student)
        {
            if (this.students.Count < this.Capacity)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = this.students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (student == null)
            {
                return "Student not found";
            }
            this.students.Remove(student);
            return $"Dismissed student {student.FirstName} {student.LastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            Student[] studentArray = this.students.Where(x => x.Subject == subject).ToArray();

            if (studentArray.Length == 0)
            {
                return "No students enrolled for the subject";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");
            foreach (var student in studentArray)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }
            return sb.ToString().TrimEnd();
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return this.students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
