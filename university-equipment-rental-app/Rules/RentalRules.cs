using university_equipment_rental_app.Model;

namespace university_equipment_rental_app.Rules;

public static class RentalRules
{
    public static int CalculatePenalty(Loan loan) => loan.DaysOverdue * loan.Penalty;
}