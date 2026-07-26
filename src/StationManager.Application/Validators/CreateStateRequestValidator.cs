using FluentValidation;

public class CreateStateRequestValidator : AbstractValidator<CreateStateRequest>
{
    public CreateStateRequestValidator()
    {
        RuleFor(x => x.StateCode).NotEmpty().MaximumLength(10);
        RuleFor(x => x.StateName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Country).NotEmpty().MaximumLength(100);
    }
}