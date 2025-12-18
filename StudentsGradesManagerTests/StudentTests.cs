using StudentsGradesManager;

namespace StudentsGradesManagerTests
{
    public class StudentTests
    {
        void SetupCatalog()
        {
            SubjectCatalog.Subjects = new List<SubjectInfo>
    {
        new SubjectInfo("Math", 4),
        new SubjectInfo("English", 3),
        new SubjectInfo("Physics", 3)
    };
        }
        [Fact]
        public void CalculateGPA_ReturnsCorrectGPA()
        {
            // Arrange
            SubjectCatalog.Subjects = new List<SubjectInfo>
        {
            new SubjectInfo ("Math", 4),
            new SubjectInfo ("English", 3)
        };

            var student = new Student("Ali", 1, new List<SubjectGrade>
        {
            new SubjectGrade("Math", 4.0),
            new SubjectGrade("English", 3.0)
        });

            // Act
            double gpa = student.CalculateGPA();

            // Assert
            double expected = (4.0 * 4 + 3.0 * 3) / 7.0;
            Assert.Equal(expected, gpa, 3); // 3 = precision to 3 decimal places
        }

        [Fact]
        public void AddSubjectGrade_ThrowsIfSubjectNotInCatalog()
        {
            SubjectCatalog.Subjects = new List<SubjectInfo>(); // empty

            var student = new Student("Ali", 2, new List<SubjectGrade>());

            Assert.Throws<System.ArgumentException>(() =>
                student.AddSubjectGrade("Physics", 4.0));
        }

        [Fact]
        public void AddSubjectGrade_ThrowsIfDuplicateSubject()
        {
            SubjectCatalog.Subjects = new List<SubjectInfo>
        {
            new SubjectInfo ("Math",4)
        };

            var student = new Student("Sara", 3, new List<SubjectGrade>
        {
            new SubjectGrade("Math", 4.0)
        });

            Assert.Throws<System.InvalidOperationException>(() =>
                student.AddSubjectGrade("Math", 4.5));
        }

        [Fact]
        public void EditSubjectGrade_UpdatesGrade()
        {
            SetupCatalog();

            var student = new Student("Sara", 3, new List<SubjectGrade>
    {
        new SubjectGrade("Math", 3.0)
    });

            student.EditSubjectGrade("Math", 4.0);
            Assert.Equal(4.0, student.Grades.Find(g => g.SubjectName == "Math").GradePoint);
        }

        [Fact]
        public void EditSubjectGrade_ThrowsIfSubjectNotFound()
        {
            SetupCatalog();

            var student = new Student("Sara", 3, new List<SubjectGrade>());

            Assert.Throws<System.ArgumentException>(() =>
                student.EditSubjectGrade("Math", 4.0));
        }

        [Fact]
        public void SubjectGrade_Constructor_ThrowsIfSubjectNotInCatalog()
        {
            SubjectCatalog.Subjects = new List<SubjectInfo>(); // empty catalog

            Assert.Throws<System.ArgumentException>(() =>
                new SubjectGrade("Unknown", 3.5));
        }

        [Fact]
        public void SubjectGrade_ToString_ReturnsFormattedString()
        {
            SetupCatalog();
            var grade = new SubjectGrade("Physics", 3.5);
            string result = grade.ToString();

            Assert.Contains("Physics", result);
            Assert.Contains("3.5", result);
            Assert.Contains("Credits: 3", result);
        }
    }
}