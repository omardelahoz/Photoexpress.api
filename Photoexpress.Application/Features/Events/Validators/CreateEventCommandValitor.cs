using FluentValidation;
using FluentValidation.Results;
using Photoexpress.Application.Exceptions;
using Photoexpress.Domain.Entities;

namespace Photoexpress.Application.Features.Events.Validators
{
    public class CreateEventCommandValitor : AbstractValidator<Event>
    {
        public CreateEventCommandValitor()
        {
            RuleFor(e => e.BaseValue)
                .NotNull()
                .NotEmpty().WithMessage("Debe incluir un valor")
                .GreaterThan(0).WithMessage("El valor debe ser mayo o igual a 0");
            RuleFor(e => e.InstitutionAddress)
                .NotNull()
                .NotEmpty().WithMessage("Debe incluir un valor para la dirección")
                .MinimumLength(5).WithMessage("Mínimo 5 carcateres");
            RuleFor(e => e.InstitutionName)
                .NotEmpty()
                .NotNull().WithMessage("Debe incluir un valor para el nombre dirección")
                .MinimumLength(5).WithMessage("Mínimo 5 carcateres");
            RuleFor(e => e.NumStudents)
                .NotNull().WithMessage("Debe incluir un valor para el número de estudiantes")
                .GreaterThan(0).WithMessage("El valor debe ser mayor que 0");
            RuleFor(e => e.StartTime)
                .NotNull()
                .NotEmpty().WithMessage("Debe ingresar una fecha de inicio del evento")
                .GreaterThan(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(10)).WithMessage("la fecha del evento debe ser superior a 10 dias calendario");

        }

        public void Evaluate(Event instance)
        {
            var validationresult = Validate(instance);
            if (!validationresult.IsValid)
            {
                var errors = validationresult.Errors
                    .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                    .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());

                throw new PhotoexpressException(errors);
            }
        }
    }
}
