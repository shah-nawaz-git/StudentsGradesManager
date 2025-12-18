using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGradesManager
{
    public class SubjectInfo
    {
        public string Name { get; set; }
        public int CreditHours { get; set; }

        public SubjectInfo(string name, int creditHours)
        {
            Name = name;
            CreditHours = creditHours;
        }
    }
}
