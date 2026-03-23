namespace university_equipment_rental_app.Rules;

public static class RentalRules
{
    public const int PenaltyPerDay = 10;
    public static int CalculatePenalty(Loan loan) => loan.DaysOverdue * PenaltyPerDay;
}