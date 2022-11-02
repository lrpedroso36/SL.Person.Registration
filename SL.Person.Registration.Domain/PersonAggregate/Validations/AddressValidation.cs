using FluentValidation;

namespace SL.Person.Registration.Domain.PersonAggregate.Validations;

public class AddressValidation : AbstractValidator<Address>
{
    public AddressValidation()
    {
        RuleFor(x => x.ZipCode)
           .NotEmpty()
           .WithMessage("Informe o CEP do endereço.")
           .NotNull()
           .WithMessage("Informe o CEP do endereço.");

        RuleFor(x => x.Street)
           .NotEmpty()
           .WithMessage("Informe o Logradouro do endereço.")
           .NotNull()
           .WithMessage("Informe o Logradouro do endereço.");

        RuleFor(x => x.Number)
           .NotEmpty()
           .WithMessage("Informe o Número do endereço.")
           .NotNull()
           .WithMessage("Informe o Número do endereço.");

        RuleFor(x => x.Neighborhood)
           .NotEmpty()
           .WithMessage("Informe o Bairro do endereço.")
           .NotNull()
           .WithMessage("Informe o Bairro do endereço.");

        RuleFor(x => x.City)
           .NotEmpty()
           .WithMessage("Informe o Cidade do endereço.")
           .NotNull()
           .WithMessage("Informe o Cidade do endereço.");

        RuleFor(x => x.State)
           .NotEmpty()
           .WithMessage("Informe o Estado do endereço.")
           .NotNull()
           .WithMessage("Informe o Estado do endereço.");

    }
}
