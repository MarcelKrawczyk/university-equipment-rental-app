using university_equipment_rental_app.Model;

namespace university_equipment_rental_app.Rules;

public static class RentalRules
{
    public const decimal PenaltyPerDay = 10m;
    
    public static decimal CalculatePenalty(Loan loan)
        => loan.DaysOverdue * PenaltyPerDay;
}