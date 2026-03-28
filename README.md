# University Equipment Rental App

A console app in C# (.NET 9) for managing university equipment rentals.  
Made for APBD – Exercise 2 @ PJATK.

---

## How to run

You need .NET 9 SDK installed.

```bash
git clone https://github.com/MarcelKrawczyk/university-equipment-rental-app
cd university-equipment-rental-app
dotnet run
```

---

## Project structure

```
university_equipment_rental_app/
├── Enums/
│   └── EquipmentStatus.cs
├── Model/
│   ├── Equipment/
│   │   ├── EquipmentBase.cs
│   │   ├── Laptop.cs
│   │   ├── Projector.cs
│   │   └── Camera.cs
│   └── Users/
│       ├── User.cs
│       ├── Student.cs
│       └── Employee.cs
├── Rules/
│   └── RentalRules.cs
├── Service/
│   ├── EquipmentService.cs
│   ├── UserService.cs
│   ├── RentalService.cs
│   └── ReportService.cs
├── UI/
│   └── ConsoleMenu.cs
├── Loan.cs
└── Program.cs
```

---

## How I split the code

I went with three layers: **Model**, **Service** and **UI**.

**Model** is just data – no logic, no printing. Classes like `User`, `EquipmentBase` or `Loan` only hold data and a few simple calculated properties (`IsOverdue`, `IsReturned`). They don't know anything about services or the console.

**Service** is where all the logic lives. Each service does one thing – `RentalService` handles renting and returning, `EquipmentService` manages the catalog, `UserService` manages users, `ReportService` just reads data and builds a report. None of them write to the console.

**UI** is just `ConsoleMenu` – reads input, calls the right method, prints the result.

`Program.cs` only creates the services, seeds some starting data and starts the menu.

---

## Cohesion

I tried to make sure each class has one clear job:

- `RentalRules` – just the penalty calculation. One constant, one method.
- `RentalService` – renting, returning, checking limits. Nothing else.
- `ReportService` – aggregates data and returns a formatted string. Doesn't modify anything.
- `ConsoleMenu` – all input/output in one place. No business logic here.

---

## Coupling

A few decisions I made to keep things loosely coupled:

- `ReportService` gets data passed as parameters instead of depending on other services. It doesn't care where the data comes from.
- `RentalRules` is static so `RentalService` doesn't need it injected.
- Services don't know about each other – only `Program.cs` connects them all.

---

## Inheritance

- `EquipmentBase` is abstract because all equipment shares `Id`, `Name` and `Status`, but each type has its own specific fields. Made sense to use inheritance here.
- `User` is abstract because `Student` and `Employee` mainly differ in their rental limit. Each defines its own `MaxActiveRentals`, so `RentalService` never needs to check the type – it just calls `user.MaxActiveRentals`.

---

## Business rules

| Rule | Value | Where |
|---|---|---|
| Max rentals – Student | 2 | `Student.MaxActiveRentals` |
| Max rentals – Employee | 5 | `Employee.MaxActiveRentals` |
| Late fee per day | $10 | `RentalRules.PenaltyPerDay` |

All in one place, easy to change.
