namespace university_equipment_rental_app.Model.Users;

public abstract class User
{
    public Guid Id { get; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    protected User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public abstract int MaxActiveRentals { get; }
    public abstract string GetUserType();
}