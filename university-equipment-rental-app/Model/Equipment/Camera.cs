namespace university_equipment_rental_app.Model.Equipment;

public class Camera : EquipmentBase {
    public int MegaPixels { get; set; }
    public bool HasStabilization { get; set; }
    
    public Camera(string name, int megaPixels, bool hasStabilization) : base(name)
    {
        MegaPixels = megaPixels;
        HasStabilization = hasStabilization;
    }

    public override string GetTypeName()
    {
        return "Camera";
    }

    public override string GetItemParameters()
    {
        return "MegaPixels: " + MegaPixels + "\n HasStabilization: " + HasStabilization;
    }
}