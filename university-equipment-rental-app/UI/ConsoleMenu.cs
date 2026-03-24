using university_equipment_rental_app.Enums;
using university_equipment_rental_app.Model.Users;
using university_equipment_rental_app.Service;

namespace university_equipment_rental_app.UI;

public class ConsoleMenu
{
    private readonly EquipmentService _equipmentService;
    private readonly UserService _userService;
    private readonly RentalService _rentalService;
    private readonly ReportService _reportService;

    public ConsoleMenu(EquipmentService equipmentService, UserService userService,
        RentalService rentalService, ReportService reportService)
    {
        _equipmentService = equipmentService;
        _userService = userService;
        _rentalService = rentalService;
        _reportService = reportService;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n=== UNIVERSITY EQUIPMENT RENTAL ===");
            Console.WriteLine("1.  Add equipment");
            Console.WriteLine("2.  Add user");
            Console.WriteLine("3.  Show all equipment");
            Console.WriteLine("4.  Show available equipment");
            Console.WriteLine("5.  Rent equipment");
            Console.WriteLine("6.  Return equipment");
            Console.WriteLine("7.  Mark equipment as unavailable");
            Console.WriteLine("8.  Show active loans for user");
            Console.WriteLine("9.  Show overdue loans");
            Console.WriteLine("10. Generate report");
            Console.WriteLine("0.  Exit");
            Console.Write("\nChoose option: ");

            var choice = Console.ReadLine()?.Trim();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddEquipment();
                    break;
                case "2":  AddUser();
                    break;
                case "3":  ShowAllEquipment();
                    break;
                case "4":  ShowAvailableEquipment();
                    break;
                case "5":  RentEquipment();
                    break;
                case "6":  ReturnEquipment();
                    break;
                case "7":  MarkUnavailable();
                    break;
                case "8":  ShowActiveLoansForUser();
                    break;
                case "9":  ShowOverdueLoans();
                    break;
                case "10": GenerateReport();
                    break;
                case "0":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    // EQUIPMENT -------------------------------------------------------

    private void AddEquipment()
    {
        Console.WriteLine("Equipment type:");
        Console.WriteLine("1. Laptop");
        Console.WriteLine("2. Projector");
        Console.WriteLine("3. Camera");
        Console.Write("Choose: ");
        var type = Console.ReadLine()?.Trim();

        Console.Write("Name: ");
        var name = Console.ReadLine();

        switch (type)
        {
            case "1":
                Console.Write("Processor: ");
                var processor = Console.ReadLine();
                Console.Write("RAM (GB): ");
                if (!int.TryParse(Console.ReadLine(), out int ram))
                {
                    Console.WriteLine("Invalid RAM value.");
                    return;
                }
                _equipmentService.CreateLaptop(name, processor, ram);
                Console.WriteLine("Laptop added.");
                break;

            case "2":
                Console.Write("Resolution width: ");
                if (!int.TryParse(Console.ReadLine(), out int width))
                {
                    Console.WriteLine("Invalid value.");
                    return;
                }
                Console.Write("Resolution height: ");
                if (!int.TryParse(Console.ReadLine(), out int height))
                {
                    Console.WriteLine("Invalid value.");
                    return;
                }
                _equipmentService.CreateProjector(name, width, height);
                Console.WriteLine("Projector added.");
                break;

            case "3":
                Console.Write("Megapixels: ");
                if (!int.TryParse(Console.ReadLine(), out int mp))
                {
                    Console.WriteLine("Invalid value.");
                    return;
                }
                Console.Write("Has stabilization? (y/n): ");
                bool stabilization = Console.ReadLine()?.Trim().ToLower() == "y";
                _equipmentService.CreateCamera(name, mp, stabilization);
                Console.WriteLine("Camera added.");
                break;

            default:
                Console.WriteLine("Invalid equipment type.");
                break;
        }
    }

    private void ShowAllEquipment()
    {
        var all = _equipmentService.GetAll();
        if (!all.Any())
        {
            Console.WriteLine("No equipment found.");
            return;
        }
        int i = 0;
        foreach (var e in all)
            Console.WriteLine($"{i++}. [{e.Status}] {e.GetTypeName()} - {e.Name} | {e.GetItemParameters()}");
    }

    private void ShowAvailableEquipment()
    {
        var available = _equipmentService.GetAvailable();
        if (!available.Any())
        {
            Console.WriteLine("No available equipment.");
            return;
        }
        int i = 0;
        foreach (var e in available)
            Console.WriteLine($"{i++}. {e.GetTypeName()} - {e.Name} | {e.GetItemParameters()}");
    }

    private void MarkUnavailable()
    {
        var all = _equipmentService.GetAll().Where(e => e.Status != EquipmentStatus.Unavailable).ToList();

        if (!all.Any())
        {
            Console.WriteLine("No equipment to mark.");
            return;
        }

        for (int i = 0; i < all.Count; i++)
            Console.WriteLine($"{i}. [{all[i].Status}] {all[i].GetTypeName()} - {all[i].Name}");

        Console.Write("Choose equipment (number): ");
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 0 || index >= all.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        _equipmentService.SetAsUnavailable(all[index]);
        Console.WriteLine($"'{all[index].Name}' marked as unavailable.");
    }

    // USERS -------------------------------------------------------

    private void AddUser()
    {
        Console.WriteLine("User type:");
        Console.WriteLine("1. Student");
        Console.WriteLine("2. Employee");
        Console.Write("Choose: ");
        var type = Console.ReadLine()?.Trim();

        Console.Write("First name: ");
        var firstName = Console.ReadLine();
        Console.Write("Last name: ");
        var lastName = Console.ReadLine();

        switch (type)
        {
            case "1":
                Console.Write("Student ID: ");
                var studentId = Console.ReadLine();
                _userService.CreateStudent(firstName, lastName, studentId);
                Console.WriteLine("Student added.");
                break;
            case "2":
                Console.Write("Department: ");
                var department = Console.ReadLine();
                _userService.CreateEmployee(firstName, lastName, department);
                Console.WriteLine("Employee added.");
                break;
            default:
                Console.WriteLine("Invalid user type.");
                break;
        }
    }

    private User? FindUser()
    {
        Console.Write("Enter last name to search: ");
        var lastName = Console.ReadLine()?.Trim();

        var found = _userService.GetAll().Where(u => u.LastName.Contains(lastName, StringComparison.OrdinalIgnoreCase)).ToList();

        if (!found.Any())
        {
            Console.WriteLine("No users found.");
            return null;
        }

        for (int i = 0; i < found.Count; i++)
            Console.WriteLine($"{i}. {found[i].FirstName} {found[i].LastName} ({found[i].GetUserType()})");

        Console.Write("Choose user (number): ");
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 0 || index >= found.Count)
        {
            Console.WriteLine("Invalid selection.");
            return null;
        }

        return found[index];
    }

    // RENTALS -------------------------------------------------------

    private void RentEquipment()
    {
        var user = FindUser();
        if (user is null) return;

        var available = _equipmentService.GetAvailable();
        if (!available.Any())
        {
            Console.WriteLine("No available equipment.");
            return;
        }

        for (int i = 0; i < available.Count; i++)
            Console.WriteLine($"{i}. {available[i].GetTypeName()} - {available[i].Name}");

        Console.Write("Choose equipment (number): ");
        if (!int.TryParse(Console.ReadLine(), out int eqIndex) || eqIndex < 0 || eqIndex >= available.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Console.Write("Rental period (days): ");
        if (!int.TryParse(Console.ReadLine(), out int days) || days <= 0)
        {
            Console.WriteLine("Invalid number of days.");
            return;
        }

        Console.WriteLine(_rentalService.Rent(user, available[eqIndex], days));
    }

    private void ReturnEquipment()
    {
        var user = FindUser();
        if (user is null) return;

        var activeLoans = _rentalService.GetActiveLoansForUser(user);
        if (!activeLoans.Any())
        {
            Console.WriteLine("This user has no active loans.");
            return;
        }

        for (int i = 0; i < activeLoans.Count; i++)
            Console.WriteLine($"{i}. {activeLoans[i].RentedEquipment.Name} | Due: {activeLoans[i].DueDate}");

        Console.Write("Choose loan to return (number): ");
        if (!int.TryParse(Console.ReadLine(), out int loanIndex) || loanIndex < 0 || loanIndex >= activeLoans.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Console.WriteLine(_rentalService.Return(activeLoans[loanIndex]));
    }

    private void ShowActiveLoansForUser()
    {
        var user = FindUser();
        if (user is null) return;

        var loans = _rentalService.GetActiveLoansForUser(user);
        if (!loans.Any())
        {
            Console.WriteLine("No active loans for this user.");
            return;
        }

        foreach (var l in loans)
            Console.WriteLine($"- {l.RentedEquipment.Name} | Rented: {l.RentedAt} | Due: {l.DueDate}");
    }

    private void ShowOverdueLoans()
    {
        var overdue = _rentalService.GetOverdueLoans();
        if (!overdue.Any())
        {
            Console.WriteLine("No overdue loans.");
            return;
        }

        foreach (var l in overdue)
            Console.WriteLine($"- {l.User.FirstName} {l.User.LastName} | {l.RentedEquipment.Name} | Due: {l.DueDate} | Days overdue: {l.DaysOverdue}");
    }

    private void GenerateReport()
    {
        Console.WriteLine(_reportService.GenerateReport(
            _equipmentService.GetAll(),
            _rentalService.GetAll()));
    }
}