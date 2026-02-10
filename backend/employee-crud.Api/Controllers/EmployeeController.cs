using employee_crud.Api.Dtos;
using employee_crud.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace employee_crud.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController(AppDbContext context): ControllerBase
{
    private readonly AppDbContext _dbContext = context;

    [HttpGet]
    public IActionResult GetEmployee()
    {
        return Ok(_dbContext.Employee.ToList());
    }

    [HttpGet("getEmployeesFromDateOnwards")]
    public async Task<IActionResult> GetEmployeesFromDateOnwards([FromQuery] DateTime hireDate)
    {
        var query = _dbContext.Employee.Where(e => e.HireDate >= hireDate);
        var result = await query.ToListAsync();
        return Ok(result);
    }

    [HttpGet("getEmployeeById")]
    public async Task<IActionResult> GetEmployeesFromDateOnwards([FromQuery] int ID)
    {
        var query = _dbContext.Employee.Where(e => e.EmployeeID == ID);
        var result = await query.FirstAsync();
        return Ok(result);
    }

    [HttpPut("updatePhoneForGivenEmployee/{id:int}")]
    public async Task<IActionResult> UpdatePhoneForGivenEmployee(int id, [FromBody] string phoneNumber)
    {
        try
        {
            var query = _dbContext.Employee.Where(e => e.EmployeeID == id);
            if (query.Count() != 1)
            {
                return BadRequest($"Employee with ID: {id} doesn't exist");
            }
            var employee = await query.Include(e => e.EmployeePhone).FirstAsync();
            var employeePhone = employee.EmployeePhone;
            employeePhone.Phone = phoneNumber;
            _dbContext.Update(employee);
            await _dbContext.SaveChangesAsync();
            return Ok(employeePhone);
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("getEmployeeByPhoneNumberOrZipCode")]
    public async Task<IActionResult> GetEmployeeByPhoneNumberOrZipCode([FromQuery] PhoneNumberOrZipCodeFilterDto filterDto)
    {
        if (filterDto.Option == "phone-number")
        {
            var query = _dbContext.Employee.Where(e => e.EmployeePhone.Phone == filterDto.Data);
            if (query.Count() == 1)
            {
                return Ok(await query.FirstAsync());
            }
            return BadRequest($"There are zero or more than one employees with the given phone number: {filterDto.Data}");
        }
        else if (filterDto.Option == "zip-code")
        {
            var query = _dbContext.Employee.Where(e => e.EmployeeAddress.ZipCode == filterDto.Data);
            if (query.Count() == 1)
            {
                return Ok(await query.FirstAsync());
            }
            return BadRequest($"There are zero or more than one employees with the given zip code: {filterDto.Data}");
        }
        return BadRequest($"Invalid option {filterDto.Option}");
    }
}