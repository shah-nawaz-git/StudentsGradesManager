using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGradesManager
{
    public static class SubjectCatalog
    {
        //Single Field containing list of all subjects
        public static List<SubjectInfo> Subjects { get; set; } = new List<SubjectInfo>();

        //No need of constructor
        public static int? GetCreditHours(string subjectName)
        {
            var subject = Subjects.FirstOrDefault(s => s.Name.Equals(subjectName, StringComparison.OrdinalIgnoreCase));
            return subject?.CreditHours;
        }
    
        public static void SaveToFile(string filePath)
        {
            string json = JsonConvert.SerializeObject(Subjects, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }


        public static void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                Subjects = JsonConvert.DeserializeObject<List<SubjectInfo>>(json) ?? new List<SubjectInfo>();
            }
            else
            {
                Subjects = new List<SubjectInfo>();
            }
        }

        //Static AddSubject Method
        public static void AddSubject(string name, int creditHours)
        {
            if (Subjects.Any(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Subject already exists.");
            }
            else
            {
                Subjects.Add(new SubjectInfo(name, creditHours));
                Console.WriteLine("Subject added successfully.");
            }
        }

        //Static RemoveSubject Method
        public static void RemoveSubject(string name)
        {
            var subject = Subjects.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (subject != null)
            {
                Subjects.Remove(subject);
                Console.WriteLine("Subject removed successfully.");
            }
            else
            {
                Console.WriteLine("Subject not found.");
            }
        }

        //Static Method to display the subject list
        public static void DisplayAllSubjects()
        {
            Console.WriteLine("\nAvailable Subjects:");
            foreach (var subject in Subjects)
            {
                Console.WriteLine($"- {subject.Name} ({subject.CreditHours} credits)");
            }
        }
    }

}
