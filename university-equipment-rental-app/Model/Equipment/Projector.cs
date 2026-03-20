namespace university_equipment_rental_app.Model.Equipment;

public class Projector : EquipmentBase
{
    public int ResolutionWidth { get; set; }
    public int ResolutionHeight { get; set; }

    public Projector(string name, int resolutionWidth, int resolutionHeight) : base(name)
    {
        ResolutionWidth = resolutionWidth;
        ResolutionHeight = resolutionHeight;
    }

    public override string GetTypeName()
    {
        return "Projector";
    }

    public override string GetItemParameters()
    {
        return "Resolution:" + ResolutionWidth * ResolutionHeight;
    }
}