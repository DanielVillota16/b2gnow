using System.ComponentModel.DataAnnotations;

namespace employee_crud.Data.Entities;

public class Employee
{
    [Key]
    public int EmployeeID { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public DateTime HireDate { get; set; }

    public EmployeePhone EmployeePhone { get; set; } = new();
    public EmployeeAddress EmployeeAddress { get; set; } = new();

}