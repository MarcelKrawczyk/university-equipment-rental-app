using university_equipment_rental_app.Enums;
using university_equipment_rental_app.Model.Equipment;

namespace university_equipment_rental_app.Service;

public class EquipmentService
{
    private readonly List<EquipmentBase> _equipment = new();
    public Laptop CreateLaptop(string name, string processor, int ramGb)
    {
        var laptop = new Laptop(name, processor, ramGb);
        _equipment.Add(laptop);
        return laptop;
    }

    public Projector CreateProjector(string name, int resolutionWidth, int resolutionHeight)
    {
        var projector = new Projector(name, resolutionWidth, resolutionHeight);
        _equipment.Add(projector);
        return projector;
    }

    public Camera CreateCamera(string name, int megaPixels, bool hasStabilization)
    {
        var camera = new Camera(name, megaPixels, hasStabilization);
        _equipment.Add(camera);
        return camera;
    }
    
    public IReadOnlyList<EquipmentBase> GetAll()
    {
        return _equipment.AsReadOnly();
    }

    public IReadOnlyList<EquipmentBase> GetAvailable()
    {
        return _equipment.Where(e => e.Status == EquipmentStatus.Available).ToList().AsReadOnly();
    }

    public void SetAsUnavailable(EquipmentBase equipmentBase)
    {
        equipmentBase.Status = EquipmentStatus.Unavailable;
    }
}