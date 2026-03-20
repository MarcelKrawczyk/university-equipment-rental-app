namespace university_equipment_rental_app.Model.Users;

public class Employee : User
{
    public override int MaxActiveRentals => 5;
    public string Department { get; set; }

    public Employee(string firstName, string lastName, string department) : base(firstName, lastName)
    {
        Department = department;
    }
    public override string GetUserType()
    {
        return "Employee";
    }
}