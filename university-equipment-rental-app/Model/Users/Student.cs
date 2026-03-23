namespace university_equipment_rental_app.Model.Users;

public class Student : User
{
    public override int MaxActiveRentals => 2;
    public string StudentId { get; set; }

    public Student(string firstName, string lastName, string studentId) : base(firstName, lastName)
    {
        StudentId = studentId;
    }
    public override string GetUserType()
    {
        return "Student";
    }
}