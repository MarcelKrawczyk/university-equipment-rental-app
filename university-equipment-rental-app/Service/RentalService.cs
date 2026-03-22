using university_equipment_rental_app.Enums;
using university_equipment_rental_app.Model.Equipment;
using university_equipment_rental_app.Model.Users;
using university_equipment_rental_app.Rules;

namespace university_equipment_rental_app.Service;

public class RentalService
{
    private readonly List<Loan> _rentals = new();
    public void Return(Loan loan)
    {
        if (loan.IsReturned)
        {
            Console.WriteLine("This equipment has already been returned.");
            return;
        }
        loan.ReturnedAt = DateOnly.FromDateTime(DateTime.Today);
        if (loan.IsOverdue)
        {
            Console.WriteLine($"Equipment Returned. Penalty: {RentalRules.CalculatePenalty(loan)} USD.");
        }
        else
        {
            Console.WriteLine("Returned in time.");
        }
        loan.RentedEquipment.Status = EquipmentStatus.Available;
    }
    
    public string Rent(User user, EquipmentBase equipment, int dueDate)
    {
        if (equipment.Status != EquipmentStatus.Available)
            return "Equipment Not Available.";

        int activeLoans = _rentals.Count(l => l.User.Id == user.Id && !l.IsReturned);
        if (activeLoans >= user.MaxActiveRentals)
            return $"User already reached the limit of active loans ({user.MaxActiveRentals}).";

        var loan = new Loan(user, equipment, DateOnly.FromDateTime(DateTime.Today), DateOnly.FromDateTime(DateTime.Today).AddDays(dueDate));
        equipment.Status = EquipmentStatus.Rented;
        _rentals.Add(loan);
        return $"Loaned '{equipment.Name}'. Return date: {DateOnly.FromDateTime(DateTime.Today).AddDays(dueDate)}.";
    }
}