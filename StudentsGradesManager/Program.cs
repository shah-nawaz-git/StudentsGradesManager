using System;
using System.Threading;

namespace StudentsGradesManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load subjects and students from file
            string Students_FilePath = @"Students_Data.json";
            string Subjects_FilePath = @"Subjects.json";
            SubjectCatalog.LoadFromFile(Subjects_FilePath);                     // subjects.json
            var gradeManager = new GradeManager();
            gradeManager.LoadFromFile(Students_FilePath);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Grade Manager Menu ===");
                Console.WriteLine("0. Add Subject to Catalog");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Grade to Student");
                Console.WriteLine("3. Edit Grade of Student");
                Console.WriteLine("4. Print Student Transcript");
                Console.WriteLine("5. Display All Students");
                Console.WriteLine("6. View Class Average GPA");
                Console.WriteLine("7. Save & Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        AddSubjectToCatalog();
                        break;
                    case "1":
                        AddStudentFlow(gradeManager);
                        break;
                    case "2":
                        AddGradeFlow(gradeManager);
                        break;
                    case "3":
                        EditGradeFlow(gradeManager);
                        break;
                    case "4":
                        PrintTranscriptFlow(gradeManager);
                        break;
                    case "5":
                        gradeManager.DisplayAllStudents();
                        Pause();
                        break;
                    case "6":
                        double average = gradeManager.GetClassAverageGPA();
                        Console.WriteLine($"Class Average GPA: {average:F2}");
                        Pause();
                        break;
                    case "7":
                        SubjectCatalog.SaveToFile(Subjects_FilePath);
                        gradeManager.SaveToFile(Students_FilePath);
                        Console.WriteLine("Data saved. Exiting...");
                        Thread.Sleep(1000);
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        static void AddSubjectToCatalog()
        {
            string Subjects_FilePath = @"E:\Visual Studio\StudentsGradesManager\Subjects.json";
            Console.Write("Enter subject name: ");
            string name = Console.ReadLine();

            Console.Write("Enter credit hours: ");
            if (!int.TryParse(Console.ReadLine(), out int credits))
            {
                Console.WriteLine("Invalid credit hour input.");
                Thread.Sleep(1500);
                return;
            }

            if (SubjectCatalog.Subjects.Exists(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Subject already exists.");
                Thread.Sleep(1500);
                return;
            }

            SubjectCatalog.Subjects.Add(new SubjectInfo(name, credits));
            SubjectCatalog.SaveToFile(Subjects_FilePath);
            Console.WriteLine("Subject added and saved.");
            Thread.Sleep(1500);
        }

        static void AddStudentFlow(GradeManager gm)
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            Console.Write("Enter student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                Thread.Sleep(1500);
                return;
            }

            try
            {
                gm.AddStudent(name, id);
                Console.WriteLine("Student added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Thread.Sleep(1500);
        }

        static void AddGradeFlow(GradeManager gm)
        {
            Console.Write("Enter student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                Thread.Sleep(1500);
                return;
            }

            var student = gm.GetStudentById(id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                Thread.Sleep(1500);
                return;
            }

            Console.Write("Enter subject name: ");
            string subject = Console.ReadLine();
            Console.Write("Enter grade point: ");
            if (!double.TryParse(Console.ReadLine(), out double grade))
            {
                Console.WriteLine("Invalid grade.");
                Thread.Sleep(1500);
                return;
            }

            try
            {
                student.AddSubjectGrade(subject, grade);
                Console.WriteLine("Grade added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Thread.Sleep(1500);
        }

        static void EditGradeFlow(GradeManager gm)
        {
            Console.Write("Enter student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                Thread.Sleep(1500);
                return;
            }

            var student = gm.GetStudentById(id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                Thread.Sleep(1500);
                return;
            }

            Console.Write("Enter subject name to edit: ");
            string subject = Console.ReadLine();
            Console.Write("Enter new grade point: ");
            if (!double.TryParse(Console.ReadLine(), out double newGrade))
            {
                Console.WriteLine("Invalid grade.");
                Thread.Sleep(1500);
                return;
            }

            try
            {
                student.EditSubjectGrade(subject, newGrade);
                Console.WriteLine("Grade updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Thread.Sleep(1500);
        }

        static void PrintTranscriptFlow(GradeManager gm)
        {
            Console.Write("Enter student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                Thread.Sleep(1500);
                return;
            }

            gm.PrintTranscript(id);
            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }
}
