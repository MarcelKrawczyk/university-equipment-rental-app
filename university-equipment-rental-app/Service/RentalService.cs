using university_equipment_rental_app.Enums;
using university_equipment_rental_app.Rules;

namespace university_equipment_rental_app.Service;

public class RentalService
{
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
}