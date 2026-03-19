namespace university_equipment_rental_app.Model.Equipment;

public abstract class EquipmentBase
{
    public Guid Id { get; } = Guid.NewGuid();
    public String Name { get; set; }
    public bool IsAvilable { get; set; } = true;
}