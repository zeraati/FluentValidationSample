using FluentValidation;

namespace FluentValidationSample;
public class Customer
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
}

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(customer => customer.Name)
            .NotEmpty().WithMessage("Name is required.");
        RuleFor(customer => customer.Age)
            .InclusiveBetween(18, 60).WithMessage("Age must be between 18 and 60.");
        RuleFor(customer => customer.Email)
            .EmailAddress().WithMessage("Invalid email address.");
    }
}