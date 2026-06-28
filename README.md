# Student Grades Manager

A C#/.NET console application for managing student records, subjects, grades, transcripts, and credit-weighted GPA calculations.

The project uses object-oriented programming and JSON file persistence to provide a simple academic-record management workflow without requiring an external database.

## Features

* Add students with unique student IDs
* Add subjects and define credit hours
* Record and edit student grades
* Validate subjects using a centralized subject catalog
* Generate individual student transcripts
* Calculate credit-weighted GPA
* Display class average GPA
* Save and load student and subject data from JSON files

## Technologies

* C#
* .NET
* Object-Oriented Programming
* Newtonsoft.Json
* JSON file persistence
* Console-based user interface

## Project Structure

```text
StudentsGradesManager/
├── StudentsGradesManager.sln
├── Subjects.json
├── StudentsGradesManager/
│   ├── Program.cs
│   ├── GradeManager.cs
│   ├── Student.cs
│   ├── SubjectCatalog.cs
│   ├── SubjectInfo.cs
│   ├── SubjectGrade.cs
│   └── StudentsGradesManager.csproj
└── StudentsGradesManagerTests/
    └── StudentsGradesManagerTests.csproj
```

## How It Works

1. The application loads the subject catalog and saved student data when it starts.
2. Users can add subjects, students, and grades through a console menu.
3. Each grade is connected to a subject and its credit-hour value.
4. GPA is calculated using the student's grades and subject credit hours.
5. Student and subject data is saved in JSON format when the application exits.

## Run Locally

### Prerequisites

* .NET SDK
* Visual Studio or Visual Studio Code

### Run the application

```bash
git clone https://github.com/shah-nawaz-git/StudentsGradesManager.git
cd StudentsGradesManager
dotnet restore
dotnet run --project StudentsGradesManager/StudentsGradesManager.csproj
```

## Data Files

The application uses JSON files for persistence:

* `Subjects.json` stores subject names and credit hours.
* `Students_Data.json` is created or updated when student data is saved.

No external database is required.

## Future Improvements

* Multi-semester GPA and CGPA support
* Improved transcript formatting
* Expanded automated test coverage
* Database-backed persistence
* More robust input validation
* Improved console user interface

## Author

Shah Nawaz
BSc Computer Science Engineering Student
Óbuda University, Budapest
