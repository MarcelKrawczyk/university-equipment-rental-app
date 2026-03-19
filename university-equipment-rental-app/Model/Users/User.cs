namespace university_equipment_rental_app.Model.Users;

public abstract class User
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Surname { get; set; }
    public abstract int MaxActiveRentals { get; }
}