using university_equipment_rental_app.Model.Users;

namespace university_equipment_rental_app.Service;

public class UserService
{
    private readonly List<User> _users = new();
    public Student CreateStudent(string firstName, string lastName, string studentId)
    {
        var student = new Student(firstName, lastName, studentId);
        _users.Add(student);
        return student;
    }

    public Employee CreateEmployee(string firstName, string lastName, string department)
    {
        var employee = new Employee(firstName, lastName, department);
        _users.Add(employee);
        return employee;
    }
    public IReadOnlyList<User> GetAll()
    {
        return _users.AsReadOnly();
    }
}