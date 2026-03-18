namespace university_equipment_rental_app.Model.Users;

public abstract class User
{
    public Guid Id { get; } = Guid.NewGuid();
    public String Name { get; set; }
    public String Surname { get; set; }
}