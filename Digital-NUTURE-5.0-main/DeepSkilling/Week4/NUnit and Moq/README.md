# Week 4 – Unit Testing with NUnit & Moq

## Overview

This week focused on understanding the fundamentals of **Unit Testing**, **Test-Driven Development (TDD)**, and **Mocking** using **NUnit** and **Moq**. The hands-on exercises demonstrated how to write isolated, maintainable, and automated unit tests by replacing external dependencies with mock objects.

---

# Technologies Used

- C#
- .NET 10
- NUnit
- Moq
- Visual Studio Code
- .NET CLI

---

# Hands-on Exercises

## 1. NUnit Handson – Calculator Unit Testing

### Objective
Develop unit tests for a calculator library using NUnit.

### Concepts Covered
- TestFixture
- Test
- TestCase
- SetUp
- TearDown
- Assert.That
- Parameterized Tests

### Implemented Tests
- Addition
- Subtraction
- Multiplication
- Division
- Division by Zero Exception
- AllClear Functionality

### Result
- Total Tests: **11**
- Passed: **11**
- Failed: **0**

---

## 2. Moq Handson – Mock Mail Server

### Objective
Unit test email functionality without sending real emails.

### Concepts Covered
- Dependency Injection
- Mock Objects
- Interfaces
- Constructor Injection
- Verify()
- Setup()

### Components
- IMailSender
- MailSender
- CustomerComm
- CustomerCommTests

### Result
- Successfully mocked the mail server
- Verified SendMail() invocation
- All tests passed

---

## 3. Moq Handson – Mock File System

### Objective
Mock file system operations for unit testing.

### Concepts Covered
- Mocking File Access
- Interface-based Design
- Collection Assertions

### Components
- IDirectoryExplorer
- DirectoryExplorer
- DirectoryExplorerTests

### Validations
- Collection is not null
- Correct file count
- Expected file names returned

### Result
- All tests passed

---

## 4. Moq Handson – Mock Database

### Objective
Mock database interactions while registering players.

### Concepts Covered
- Mock Database Access
- Repository Pattern
- Dependency Injection
- Verify()
- Player Registration

### Components
- IPlayerMapper
- PlayerMapper
- Player
- PlayerTests

### Validations
- Player registration
- Database call verification
- Player properties

### Result
- All tests passed

---

# Learning Outcomes

- Understood Unit Testing fundamentals
- Learned Test-Driven Development (TDD)
- Worked with NUnit testing framework
- Implemented parameterized unit tests
- Used Moq for mocking dependencies
- Applied Dependency Injection
- Mocked Email, File System, and Database operations
- Verified method invocations using Moq
- Built isolated and maintainable test cases

---

# Folder Structure

```
Week4
│
├── NUnit and Moq
│   ├── NUnit-Handson
│   │   └── CalcLibrary
│   │
│   └── Moq-Handson
│       ├── CustomerCommLib
│       ├── CustomerCommLib.Tests
│       ├── MagicFilesLib
│       ├── MagicFilesLib.Tests
│       ├── PlayersManagerLib
│       ├── PlayersManagerLib.Tests
│       └── CustomerComm.sln
│
└── README.md
```

---

# Key Skills Acquired

- NUnit Framework
- Automated Unit Testing
- Mocking with Moq
- Dependency Injection
- Test Isolation
- Interface-based Design
- Assertion Techniques
- C# Testing Best Practices

---

# Status

**Week 4 Completed Successfully**

- NUnit Handson ✔
- Moq Task 1 ✔
- Moq Task 2 ✔
- Moq Task 3 ✔

**Total Hands-ons Completed:** **4 / 4**

---

## Author

**Rawhan Ramzi Mohammed**

Cognizant Deep Skilling Program