# Task Management System 🚀

A Jira-like **Task Management System** built with **ASP.NET Core Web API**, **Angular 17**, and **SQL Server**. The application enables organizations to manage projects, assign tasks, track progress, and improve team collaboration through a centralized platform.

---

## 📌 Project Overview

The **Task Management System** provides an efficient and secure way to manage projects and tasks within an organization. It supports role-based access control, authentication using JWT, project monitoring, and task tracking.

This system helps teams:

* Organize projects efficiently
* Assign and monitor tasks
* Improve collaboration
* Track project progress in real-time
* Maintain secure access control

---

# 🚀 Features

## 📁 Project Management

* Create and manage projects
* View all projects
* Delete projects
* Monitor project progress
* Manage project timelines

## ✅ Task Management

* Assign tasks to users
* Track task status
* Update task progress
* Manage task priorities
* Set due dates

## 🔐 Security

* JWT-based Authentication
* Role-Based Authorization
* Secure REST APIs
* HTTPS Support

## 👥 User Management

* User Registration & Login
* Role Assignment
* Access Control based on roles

---

# 👥 User Roles

## 🛡️ Admin

* Manage users
* Manage projects
* View all system data
* Configure system settings

## 📊 Manager

* Assign tasks to team members
* Monitor team progress
* Update task priorities
* Manage project activities

## 👤 User

* View assigned tasks
* Update task status
* Track personal progress

---

# 🛠️ Technology Stack

## Frontend

* Angular 17
* TypeScript
* Bootstrap
* Angular Material

## Backend

* ASP.NET Core Web API
* Entity Framework Core
* LINQ

## Database

* SQL Server
* EF Core Migrations

## Security

* JWT Authentication
* Role-Based Authorization
* HTTPS

## Architecture

* Domain-Driven Design (DDD)
* Repository Pattern
* Dependency Injection

---

# 🏗️ System Architecture

```text
Presentation Layer
        ↓
Application Layer
        ↓
Domain Layer
        ↓
Infrastructure Layer
        ↓
Database (SQL Server)
```

---

# 📚 Layer Responsibilities

## Presentation Layer

* API Controllers
* Request/Response Handling
* Authentication Endpoints

## Application Layer

* Business Logic
* Service Interfaces
* DTOs and Validation

## Domain Layer

* Entities
* Domain Models
* Business Rules

## Infrastructure Layer

* Repository Implementations
* Database Context
* External Services

---

# 📂 Database Entities

## User

| Field        | Description           |
| ------------ | --------------------- |
| Id           | Unique Identifier     |
| Username     | User Name             |
| Email        | User Email            |
| PasswordHash | Encrypted Password    |
| Role         | User Role             |
| CreatedAt    | Account Creation Date |

---

## Project

| Field       | Description            |
| ----------- | ---------------------- |
| Id          | Unique Identifier      |
| Name        | Project Name           |
| Description | Project Description    |
| StartDate   | Project Start Date     |
| EndDate     | Project End Date       |
| Status      | Current Project Status |

---

## Task

| Field          | Description       |
| -------------- | ----------------- |
| Id             | Unique Identifier |
| Title          | Task Title        |
| Description    | Task Details      |
| Priority       | Task Priority     |
| Status         | Task Status       |
| AssignedUserId | Assigned User     |
| ProjectId      | Related Project   |
| DueDate        | Task Due Date     |

---

# 🔑 API Endpoints

## Authentication APIs

| Method | Endpoint             | Description                 |
| ------ | -------------------- | --------------------------- |
| POST   | `/api/Auth/register` | Register a new user         |
| POST   | `/api/Auth/login`    | Login and receive JWT token |

---

## Project APIs

| Method | Endpoint                    | Description           |
| ------ | --------------------------- | --------------------- |
| GET    | `/api/Projects`             | Get all projects      |
| POST   | `/api/Projects`             | Create a new project  |
| DELETE | `/api/Projects/{id}`        | Delete a project      |
| POST   | `/api/Projects/{id}/assign` | Assign tasks to users |
| GET    | `/api/Projects/my-tasks`    | Get assigned tasks    |

---

# 🔐 Authentication Flow

1. User registers using the Register API.
2. User logs in using credentials.
3. System generates a JWT token.
4. Token is included in API requests.
5. Role-based authorization controls access to resources.

---

# 📋 Project Objectives

* Centralize project and task management
* Enable secure user authentication
* Implement role-based access control
* Track project progress efficiently
* Build a scalable and maintainable application
* Improve team collaboration

---

# ⚙️ Installation & Setup

## ✅ Prerequisites

* .NET 8 SDK
* Node.js (Latest LTS)
* Angular CLI 17
* SQL Server
* Visual Studio 2022 / VS Code

---

# 🔧 Backend Setup

```bash
git clone https://github.com/yourusername/task-management-system.git

cd TaskManagementSystem.API

dotnet restore

dotnet ef database update

dotnet run
```

---

# 🎨 Frontend Setup

```bash
cd TaskManagementSystem.UI

npm install

ng serve
```

---

# 🌐 Application URLs

## Frontend

```text
http://localhost:4200
```

## Backend API

```text
https://localhost:5001
```




