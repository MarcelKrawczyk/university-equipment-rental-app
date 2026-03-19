namespace university_equipment_rental_app.Model.Equipment;

public abstract class EquipmentBase
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; }
    public bool IsAvailable { get; set; } = true;
    public string SerialNumber { get; set; }
    public decimal ReplecementCost { get; set; }
}   