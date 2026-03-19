namespace university_equipment_rental_app.Model.Users;

public class Employee : User
{
    public override int MaxActiveRentals => 5;
}