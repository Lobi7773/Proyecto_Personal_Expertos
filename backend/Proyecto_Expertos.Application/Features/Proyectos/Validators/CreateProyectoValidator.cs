using FluentValidation;
using Proyecto_Expertos.Application.Features.Proyectos.DTOs;

namespace Proyecto_Expertos.Application.Features.Proyectos.Validators;

public class CreateProyectoValidator : AbstractValidator<CreateProyectoRequestDto>
{
    public CreateProyectoValidator() 
    {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("")
            .MinimumLength(3).WithMessage("")
            .MaximumLength(100).WithMessage("");
    }

}