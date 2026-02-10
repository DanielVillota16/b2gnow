using System.ComponentModel.DataAnnotations;

namespace employee_crud.Data.Entities;

public class EmployeeAddress
{
    [Key]
    public int EmployeeAddressID { get; set; }
    public int EmployeeID { get; set; }
    public string StreetAddress { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
}