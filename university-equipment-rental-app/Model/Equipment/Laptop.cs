namespace university_equipment_rental_app.Model.Equipment;

public class Laptop : EquipmentBase
{
    public string Procesor { get; set; }
    public int RamGb { get; set; }

    public Laptop(string name, string proc, int ramgb) : base(name)
    {
        Procesor = proc;
        RamGb = ramgb;
    }

    public override string GetTypeName()
    {
        return "Laptop";
    }

    public override string GetItemParameters()
    {
        return "Procesor: " + Procesor+ "\n Ram: " + RamGb + "GB";
    }
}