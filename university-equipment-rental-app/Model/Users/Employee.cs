namespace university_equipment_rental_app.Model.Users;

public class Employee : User
{
    public override int MaxActiveRentals => 5;

    public Employee(string firstName, string lastName) : base(firstName, lastName)
    {
        
    }
    public override string GetUserType()
    {
        return "Employee";
    }
}