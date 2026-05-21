# MatchCore - Football Match & Event Management System

An N-Tier Architecture, API-first web application designed to manage and track football fixtures, match details, and in-game events. Developed using ASP.NET Core Web API and ASP.NET Core MVC, this project emphasizes separation of concerns, scalable database design, and a dynamic user interface.

## Project Overview
The system allows administrators to manage league fixtures by weeks and record minute-by-minute match events such as goals, cards, and substitutions. The architecture is strictly divided into backend API services and a frontend MVC client, ensuring a modern, decoupled development approach.

## Key Features
* **Fixture Management:** Matches are logically grouped and displayed by their respective "Matchweeks" using a clean, accordion-style UI.
* **In-Depth Event Tracking:** Ability to record detailed match events (Goals, Yellow/Red Cards, Substitutions) chronologically. 
* **Dynamic UI & UX:** Context-aware event creation forms (e.g., dynamically displaying Home/Away team names based on the selected match) without requiring page reloads.
* **API-Driven Data Flow:** All data operations are handled through a robust RESTful Web API, consumed by the Web UI via HTTP Clients.
* **Advanced Data Mapping:** Complex relational data (Match -> Home Team / Away Team) is safely transformed and flattened using AutoMapper and Data Transfer Objects (DTOs).

## Technology Stack
* **Backend:** C#, ASP.NET Core Web API
* **Frontend / UI:** ASP.NET Core MVC, Bootstrap 5, Custom CSS, jQuery / AJAX
* **Database:** Microsoft SQL Server
* **ORM:** Entity Framework Core (Code-First Approach)
* **Mapping:** AutoMapper
* **Serialization:** System.Text.Json (configured for Reference Loop handling)

## Architecture & Design Patterns
This project is built upon the **N-Tier (Multi-Layer) Architecture**, ensuring clean code and high maintainability. The layers include:

1.  **Entity Layer:** Contains the core domain classes (FootballMatch, Team, MatchEvent, etc.).
2.  **Data Access Layer (DAL):** Implements the **Generic Repository Pattern** alongside Entity Framework Core for database operations. It includes custom methods for complex `Include` and `ThenInclude` SQL joins.
3.  **Business Logic Layer (BLL):** Acts as a bridge between DAL and API, containing validation and business rules.
4.  **DTO Layer:** Isolates database entities from the presentation layer, preventing JSON cycle errors and over-posting attacks.
5.  **API Layer:** Exposes endpoints to serve JSON data.
6.  **WebUI Layer:** The client-side application that consumes the API and renders the user interface.

## Technical Highlights
* **Asynchronous Programming:** Full implementation of `async/await` across all layers to ensure non-blocking, highly performant database queries and API calls.
* **Complex Relational Queries:** Efficiently fetching deeply nested relational data (Events -> Match -> Home/Away Teams) using EF Core and mapping them seamlessly to the UI.
* **JSON Cycle Management:** Configured the API to ignore reference loops, a common challenge when dealing with bidirectional EF Core relationships.

---
## 📸 Screenshots

<img width="1427" height="3165" alt="Homepage" src="https://github.com/user-attachments/assets/62c29588-8478-409e-a2b3-c48847bf930d" />
<img width="1427" height="1867" alt="fixture" src="https://github.com/user-attachments/assets/ab5421df-d03f-41b7-a93f-1cc3fa92f4e1" />
<img width="1427" height="2043" alt="standing" src="https://github.com/user-attachments/assets/ba78d34d-e2c6-4c9e-b81c-36a11864f6f5" />
<img width="1427" height="2431" alt="matchdetail" src="https://github.com/user-attachments/assets/ad439024-5388-4f70-8994-1f840d3047d8" />


### Admin Panel
<img width="1905" height="918" alt="Dashboard1" src="https://github.com/user-attachments/assets/59a54478-a958-4280-a1a6-8d9f5cc2683f" />
<img width="1908" height="490" alt="Dashboard2" src="https://github.com/user-attachments/assets/ff1b3324-1588-4ffc-b38e-9e6fb41c4a9b" />
<img width="1908" height="916" alt="Matches1" src="https://github.com/user-attachments/assets/4a2050f5-4900-4d06-b579-f2291e96b152" />
<img width="1915" height="920" alt="Matches2" src="https://github.com/user-attachments/assets/d8d5aa7d-d3f3-4f7c-979c-cec8a751798f" />
<img width="1909" height="915" alt="Matchevents1" src="https://github.com/user-attachments/assets/93e4670e-da86-4acd-927a-1d38bf328cd9" />
<img width="1916" height="921" alt="Matchevents2" src="https://github.com/user-attachments/assets/75cd5b2e-461a-48c4-b3fb-3256c371a328" />
<img width="1903" height="915" alt="Matchstatistics1" src="https://github.com/user-attachments/assets/4cec798a-5035-4072-9efc-6d09dd97cae1" />
<img width="1902" height="917" alt="matchstatistics2" src="https://github.com/user-attachments/assets/d3a01922-6997-4e2f-929c-6ea11098b045" />
<img width="1900" height="914" alt="matchstatistics3" src="https://github.com/user-attachments/assets/05063d85-2170-4f8e-b480-f73aef41ef1f" />
<img width="1901" height="917" alt="matchstatistics4" src="https://github.com/user-attachments/assets/b0e5e510-e66d-4d1f-8280-c7425e4db59a" />
<img width="1911" height="915" alt="seasons1" src="https://github.com/user-attachments/assets/3ecc1bc5-8586-4f28-bea0-907b0bbec75f" />
<img width="1916" height="917" alt="seasons2" src="https://github.com/user-attachments/assets/840fcf87-248f-4db4-b7c2-9aced50e5513" />
<img width="1906" height="916" alt="Team1" src="https://github.com/user-attachments/assets/d241b081-2f4c-4015-96f5-ca267a61bc49" />
<img width="1910" height="917" alt="Team2" src="https://github.com/user-attachments/assets/970ba67a-acce-42db-a160-7842d2fabb56" />
<img width="1904" height="916" alt="weeks1" src="https://github.com/user-attachments/assets/08d21053-390f-4df3-932c-a09735e4dd8e" />
<img width="1910" height="915" alt="weeks2" src="https://github.com/user-attachments/assets/e3af5c28-59cf-411f-b3a9-9998fa131698" />


