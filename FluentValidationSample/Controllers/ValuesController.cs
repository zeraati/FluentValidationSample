using Microsoft.AspNetCore.Mvc;

namespace FluentValidationSample.Controllers;
[Route("api/[controller]"), ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var customer = new Customer { Name = "", Age = 25, Email = "invalid-email" };
        var validator = new CustomerValidator();
        var result = validator.Validate(customer);

        if (!result.IsValid)
        {
            foreach (var failure in result.Errors)
            {
                Console.WriteLine($"Property {failure.PropertyName} failed validation. Error: {failure.ErrorMessage}");
            }
        }

        return Ok();
    }
}
