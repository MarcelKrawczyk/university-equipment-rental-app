using university_equipment_rental_app.Enums;
using university_equipment_rental_app.Model.Equipment;

namespace university_equipment_rental_app.Service;

public class ReportService
{
    public string GenerateReport(IReadOnlyList<EquipmentBase> equipment, IReadOnlyList<Loan> loans)
    {
        int available = equipment.Count(e => e.Status == EquipmentStatus.Available);
        int rented = equipment.Count(e => e.Status == EquipmentStatus.Rented);
        int unavailable = equipment.Count(e => e.Status == EquipmentStatus.Unavailable);
        int active = loans.Count(l => !l.IsReturned);
        int overdue = loans.Count(l => l.IsOverdue);

        return $"Total equipment: {equipment.Count}\n" +
               $"  - available: {available}\n" +
               $"  - rented: {rented}\n" +
               $"  - unavailable: {unavailable}\n" +
               $"Active rentals: {active}\n" +
               $"Overdue rentals: {overdue}";
    }
}