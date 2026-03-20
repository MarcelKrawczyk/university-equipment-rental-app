namespace university_equipment_rental_app.Model.Users;

public class Student : User
{
    public override int MaxActiveRentals => 2;
    public string StudnetId { get; set; }

    public Student(string firstName, string lastName, string studnetId) : base(firstName, lastName)
    {
        StudnetId = studnetId;
    }
    public override string GetUserType()
    {
        return "Student";
    }
}