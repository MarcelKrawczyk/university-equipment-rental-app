using university_equipment_rental_app.Model.Users;
using university_equipment_rental_app.Model.Equipment;

namespace university_equipment_rental_app.Model;

public class Loan
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateOnly LoanDate { get; set; }
    public DateOnly ReturnDate => LoanDate.AddDays(7);
    public DateOnly? ActualReturnDate { get; set; }
    public EquipmentBase RentedEquipment { get; set; }
    public User Renter { get; set; }
    public bool IsReturned => ActualReturnDate.HasValue;
    public bool IsOverdue => DaysOverdue > 0;
    public int Penalty { get; set; }
    
    public int DaysOverdue
    {
        get
        {
            var compareDate = ActualReturnDate ?? DateOnly.FromDateTime(DateTime.Today);
            return Math.Max(0, compareDate.DayNumber - ReturnDate.DayNumber);
        }
    }
}