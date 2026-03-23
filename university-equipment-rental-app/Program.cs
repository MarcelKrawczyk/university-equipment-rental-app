using university_equipment_rental_app.Service;
using university_equipment_rental_app.UI;

var menu = new ConsoleMenu(
    new EquipmentService(),
    new UserService(),
    new RentalService(),
    new ReportService()
);

menu.Run();