using university_equipment_rental_app.Enums;
using university_equipment_rental_app.Model.Equipment;
using university_equipment_rental_app.Model.Users;
using university_equipment_rental_app.Rules;

namespace university_equipment_rental_app.Service;

public class RentalService
{
    private readonly List<Loan> _rentals = new();
    public string Return(Loan loan)
    {
        if (loan.IsReturned)
            return "This equipment has already been returned.";

        loan.ReturnedAt = DateOnly.FromDateTime(DateTime.Today);
        loan.RentedEquipment.Status = EquipmentStatus.Available;

        int penalty = RentalRules.CalculatePenalty(loan);
        if (penalty > 0)
        {
            return $"Equipment returned. Penalty: {penalty} USD.";
        }
        return "Equipment returned in time. No penalty.";
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