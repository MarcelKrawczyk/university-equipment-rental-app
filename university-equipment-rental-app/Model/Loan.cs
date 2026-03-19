using university_equipment_rental_app.Model.Users;
using university_equipment_rental_app.Model.Equipment;

namespace university_equipment_rental_app.Model;

public class Loan
{
    public DateOnly LoanDate { get; set; }
    public DateOnly ReturnDate => LoanDate.AddDays(7);
    public DateOnly? ActualReturnDate { get; set; }
    public EquipmentBase RentedEquipment { get; set; }
    public User Renter { get; set; }
}