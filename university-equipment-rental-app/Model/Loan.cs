using university_equipment_rental_app.Model.Equipment;
using university_equipment_rental_app.Model.Users;

public class Loan
{
    public Guid Id { get; } = Guid.NewGuid();
    public User User { get; }
    public EquipmentBase RentedEquipment { get; }
    public DateOnly RentedAt { get; }
    public DateOnly DueDate { get; }
    public DateOnly? ReturnedAt { get; set; }
    public bool IsReturned => ReturnedAt.HasValue;
    public bool IsOverdue => DaysOverdue > 0;
    
    public Loan(User user, EquipmentBase equipment, DateOnly rentedAt, DateOnly dueDate)
    {
        User = user;
        RentedEquipment = equipment;
        RentedAt = rentedAt;
        DueDate = dueDate;
    }

    public int DaysOverdue
    {
        get
        {
            var compareDate = ReturnedAt ?? DateOnly.FromDateTime(DateTime.Today);
            return Math.Max(0, compareDate.DayNumber - DueDate.DayNumber);
        }
    }
}