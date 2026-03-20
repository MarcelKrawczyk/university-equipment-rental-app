namespace university_equipment_rental_app.Model.Users;

public class Student : User
{
    public override int MaxActiveRentals => 2;

    public Student(string firstName, string lastName) : base(firstName, lastName)
    {
        
    }
    public override string GetUserType()
    {
        return "Student";
    }
}