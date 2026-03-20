using university_equipment_rental_app.Enums;

namespace university_equipment_rental_app.Model.Equipment;

public abstract class EquipmentBase
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; }
    public EquipmentStatus Status { get; set; } =  EquipmentStatus.Available;
    protected EquipmentBase(string name)
    {
        Name = name;
    }

    public abstract string GetTypeName();
    public abstract string GetItemParameters();
}   