using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGradesManager
{
    public class Student
    {

        //The things i would like student class to have are grades against subjects, 
        //We should be able to calculate the GPA of students
        //we should also be able to calculate the CGPA of students
        //Later on consider making the subjects name case insensitive
        

        //Fields
        public string Name { get; set; }
        public int ID { get; set; }
        public List<SubjectGrade> Grades { get; set;}

        //Constructor
        public Student(string name, int id, List<SubjectGrade> grades)
        {
            Name = name;
            ID = id;
            Grades = grades;
        }

        //Method Adding a student's grade of a subject
        public void AddSubjectGrade(string subjectName, double gradePoint)
        {
            if (gradePoint < 0 || gradePoint > 5)
            {
                throw new ArgumentOutOfRangeException("Grade point must be between 0.0 and 4.0.");
            }

            if (!SubjectCatalog.Subjects.Any(s => s.Name.Equals(subjectName, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("This subject isn't part of the subject catalog.");
            }
            //Optional Check: REVIEW IT LATER***
            if (Grades.Any(g => g.SubjectName.Equals(subjectName, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("Grade for this subject already exists. Use EditSubjectGrade to modify it.");
            }

            Grades.Add(new SubjectGrade(subjectName, gradePoint));
        }

        //Method for updating or modifying already uploaded grades
        public void EditSubjectGrade(string subjectName, double newGradePoint)
        {
            if (newGradePoint < 0 || newGradePoint > 5) // Adjust this range if needed
            {
                throw new ArgumentOutOfRangeException("Grade point must be between 0.0 and 5.0.");
            }

            var subject = Grades.FirstOrDefault(s => s.SubjectName.Equals(subjectName, StringComparison.OrdinalIgnoreCase));
            if (subject == null)
            {
                throw new ArgumentException("Subject not found in the student's grades.");
            }

            subject.GradePoint = newGradePoint;
        }

        //Method to calculate GPA
        public double CalculateGPA()
        {
            double totalGradePoints = 0;
            int totalCreditHours = 0;

            foreach (var grade in Grades)
            {
                var subject = SubjectCatalog.Subjects
                    .FirstOrDefault(s => s.Name.Equals(grade.SubjectName, StringComparison.OrdinalIgnoreCase));

                if (subject != null)
                {
                    totalGradePoints += grade.GradePoint * subject.CreditHours;
                    totalCreditHours += subject.CreditHours;
                }
                
            }
            return totalCreditHours == 0 ? 0 : totalGradePoints / totalCreditHours;
        }

    }
}
