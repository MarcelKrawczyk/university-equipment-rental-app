using university_equipment_rental_app.Service;
using university_equipment_rental_app.UI;

var equipmentService = new EquipmentService();
var userService = new UserService();
var rentalService = new RentalService();
var reportService = new ReportService();

equipmentService.CreateLaptop("Dell XPS 15","Intel i7-12700H",32);
equipmentService.CreateLaptop("Lenovo ThinkPad X1","Intel i5-1135G7",16);

equipmentService.CreateProjector("Epson EB-X51",1024,768);
equipmentService.CreateProjector("BenQ MH560",1920,1080);

equipmentService.CreateCamera("Canon EOS 90D",32, true);
equipmentService.CreateCamera("Sony A6400",24, false);

userService.CreateStudent("Verso","Dessandre","s33");
userService.CreateStudent("Lambert","Witcher","s0534");

userService.CreateEmployee("Clive","Rosefield","IT Department");
userService.CreateEmployee("Leon","Kennedy","Polic");

var menu = new ConsoleMenu(equipmentService, userService, rentalService, reportService);
menu.Run();