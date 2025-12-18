# StudentsGradesManagerProject

StudentsGradesManager is a C# console application for managing a subject catalog, student records, and grade-based transcript generation with GPA calculation.
The project demonstrates solid use of object-oriented design, data modeling, and file-based persistence in .NET.

#Key Features
Subject catalog with credit hours
Student registration with unique IDs
Add and edit subject grades
Transcript generation with credit-weighted GPA
Class average GPA calculation
JSON-based persistence
Unit tests for core logic

Project Structure
StudentsGradesManager/
├─ StudentsGradesManager.sln
├─ .gitignore
│
├─ StudentsGradesManager/          // Console application
│  ├─ Program.cs
│  ├─ Student.cs
│  ├─ SubjectCatalog.cs
│  ├─ GradeManager.cs
│  └─ ...
│
└─ StudentsGradesManagerTests/     // Unit tests

#Technologies
C# (.NET)
Console Application
Newtonsoft.Json
Unit Testing (xUnit / MSTest)
Git & GitHub
