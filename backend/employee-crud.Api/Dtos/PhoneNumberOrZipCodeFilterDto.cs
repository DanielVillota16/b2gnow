namespace employee_crud.Api.Dtos;

public class PhoneNumberOrZipCodeFilterDto
{
    public string Option { get; set; } = string.Empty; // phone-number | zip-code
    public string Data { get; set; } = string.Empty;
}