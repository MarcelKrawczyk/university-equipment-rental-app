using university_equipment_rental_app.Enums;
using university_equipment_rental_app.Model;
using university_equipment_rental_app.Rules;

namespace university_equipment_rental_app.Service;

public class RentalService
{
    public void ReturnLoanedItem(Loan loan)
    {
        loan.ActualReturnDate = DateOnly.FromDateTime(DateTime.Today);
        if (loan.IsOverdue)
        {
            loan.Penalty = RentalRules.CalculatePenalty(loan);
        }
        loan.RentedEquipment.Status = EquipmentStatus.Avilable;
    }
}