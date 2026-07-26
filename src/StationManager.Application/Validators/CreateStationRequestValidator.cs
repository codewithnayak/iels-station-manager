using FluentValidation;

public class CreateStationRequestValidator : AbstractValidator<CreateStationRequest>
{
    public CreateStationRequestValidator()
    {
        RuleFor(x => x.StationId).NotEmpty().MaximumLength(20);
        RuleFor(x => x.StationCode).NotEmpty().MaximumLength(20);
        RuleFor(x => x.StationName).NotEmpty().MaximumLength(200);
        RuleFor(x => x.StateCode).NotEmpty().MaximumLength(10);
        RuleFor(x => x.District).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Address).NotEmpty().MaximumLength(300);
    }
}

