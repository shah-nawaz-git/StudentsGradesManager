using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGradesManager
{
    public class GradeManager
    {
        //Fields
        private List<Student> students;

        //Constructor
        public GradeManager()
        {
            students = new List<Student>();
        }

        //Method to add students
        public void AddStudent(string name, int id)
        {
            if (students.Any(s => s.ID == id))
            {
                throw new InvalidOperationException("A student with this ID already exists.");
            }

            students.Add(new Student(name, id, new List<SubjectGrade>()));
        }

        //Method to find a student by ID
        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.ID == id);
        }

        // Method to display all students
        public void DisplayAllStudents()
        {
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.ID}, Name: {student.Name}, GPA: {student.CalculateGPA():F2}");
            }
        }

        // Method to print a student's transcript
        public void PrintTranscript(int id)
        {
            var student = GetStudentById(id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine($"\nTranscript for {student.Name} (ID: {student.ID})");
            foreach (var grade in student.Grades)
            {
                Console.WriteLine(grade.ToString());
            }
            Console.WriteLine($"GPA: {student.CalculateGPA():F2}");
        }

        //Method To Get Class Average GPA
        public double GetClassAverageGPA()
        {
            if (students.Count == 0)
            {
                return 0;
            }

            double totalGPA = 0;
            int count = 0;

            foreach (var student in students)
            {
                double gpa = student.CalculateGPA();
                totalGPA += gpa;
                count++;
            }

            return count == 0 ? 0 : totalGPA / count;
        }

        //File Handling***
        public void SaveToFile(string filePath)
        {
            string json = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                students = JsonConvert.DeserializeObject<List<Student>>(json) ?? new List<Student>();
            }
            else
            {
                students = new List<Student>();
            }
        }

    }
}
