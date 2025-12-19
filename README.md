# 🎓 Students Grades Manager  
### Console-Based Academic Records & GPA Management System (C# / .NET)

<p align="center">
  <img src="https://img.shields.io/badge/Tech-.NET-blue?style=for-the-badge">
  <img src="https://img.shields.io/badge/App-Console-lightgrey?style=for-the-badge">
  <img src="https://img.shields.io/badge/Data-JSON-yellow?style=for-the-badge">
  <img src="https://img.shields.io/badge/Testing-Unit%20Tests-green?style=for-the-badge">
  <img src="https://img.shields.io/badge/Status-Stable-success?style=for-the-badge">
</p>

---

## ✨ Overview

**Students Grades Manager** is a C# console application designed to simulate a simplified university grading system.  
It allows managing **students**, **subjects**, and **grades**, while generating **transcripts** and calculating **GPA** using credit-weighted logic.

The project focuses on:
- Object-Oriented Programming (OOP)
- Clean data modeling
- File-based persistence
- Console-based UI workflows
- Testable business logic

---

## 📐 System Architecture

```text
User Input (Console Menu)
        ↓
   GradeManager
        ↓
Student ─── SubjectCatalog
        ↓
 GPA Calculation Engine
        ↓
 JSON Persistence Layer
```

---

## 🧩 Core Features

### 👤 Student Management
- Add students with unique IDs
- Store grades per subject
- Edit existing grades

### 📚 Subject Catalog
- Add subjects with credit hours
- Case-insensitive subject validation
- Centralized subject lookup

### 🧮 GPA & Transcript
- Credit-weighted GPA calculation
- Per-student transcript generation
- Class average GPA computation

### 💾 Persistence
- Load & save data using JSON files
- No external database required
- Portable and easy to run

### 🧪 Unit Testing
- Separate test project
- Validates core business logic

---

## 🗂️ Repository Structure

```txt
StudentsGradesManager/
│
├── StudentsGradesManager.sln
├── .gitignore
│
├── StudentsGradesManager/              # Main Console Application
│   ├── Program.cs
│   ├── Student.cs
│   ├── GradeManager.cs
│   ├── SubjectCatalog.cs
│   ├── SubjectInfo.cs
│   ├── SubjectGrade.cs
│   └── StudentsGradesManager.csproj
│
└── StudentsGradesManagerTests/          # Unit Tests
    └── StudentsGradesManagerTests.csproj
```

---

## 🛠️ How to Run the Project

### ✅ Prerequisites
- .NET SDK installed
- Visual Studio or VS Code

### 1️⃣ Clone the Repository
```bash
git clone https://github.com/shah-nawaz-git/StudentsGradesManager.git
cd StudentsGradesManager
```

### 2️⃣ Open the Solution
Open `StudentsGradesManager.sln` in Visual Studio.

### 3️⃣ Set Startup Project
Ensure **StudentsGradesManager** (not the test project) is set as the startup project.

### 4️⃣ Run the Application
```bash
dotnet run --project StudentsGradesManager/StudentsGradesManager.csproj
```

You will see a console menu allowing you to manage students, subjects, and grades.

---

## 📄 Data Files

The application uses JSON files for persistence:
- `Subjects.json`
- `Students_Data.json`

These files are loaded at startup and saved when exiting the application.

---

## 🎯 Educational Goals

This project demonstrates:
- Practical OOP design in C#
- Separation of concerns
- Console-based user interaction
- GPA calculation logic
- Clean GitHub-ready project structure

It is suitable for:
- Academic coursework
- Teaching assistant / demonstrator applications
- Entry-level portfolio projects

---

## 🚀 Future Enhancements

- 📊 Improved tabular transcript output
- 🗓️ Multi-semester support
- 🗄️ Database-backed persistence
- 🎨 Enhanced console UI formatting
- 🧪 Expanded unit test coverage

---

## 👨‍💻 Author

**Shah Nawaz**  
BSc Computer Science Engineering  
Óbuda University, Budapest

---

## 📬 Contact

For feedback, suggestions, or collaboration:
- Open an issue on GitHub
- Or reach out via GitHub profile

---

⭐ If you find this project useful, consider starring the repository!
