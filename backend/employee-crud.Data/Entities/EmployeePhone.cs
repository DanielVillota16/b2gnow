using System.ComponentModel.DataAnnotations;

namespace employee_crud.Data.Entities;

public class EmployeePhone
{
    [Key]
    public int EmployeePhoneID { get; set; }
    public int EmployeeID { get; set; }
    public string PhoneArea { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string PhoneExt { get; set; } = null!;
}