using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGradesManager
{
    public class SubjectGrade
    {
        //Fields
        public string SubjectName { get; set; }
        public double GradePoint { get; set; }
        public int CreditHours { get; private set; }

        //Constructor
        public SubjectGrade(string subjectName, double gradePoint)
        {
            int? credits = SubjectCatalog.GetCreditHours(subjectName);

            if (credits == null)
            {
                throw new ArgumentException("Subject not found in SubjectCatalog."); //Or you can also write that subject is not part of the provided curriculum
            }

            SubjectName = subjectName;
            GradePoint = gradePoint;
            CreditHours = credits.Value;
        }

        //May need it later on
        public override string ToString()
        {
            return $"{SubjectName} - Grade: {GradePoint}, Credits: {CreditHours}";
        }
    }
}
