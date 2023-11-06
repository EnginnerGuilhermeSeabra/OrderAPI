using FluentValidation;
using Order.Application.Commands;
using Order.Infra.Validator;

namespace Order.Application.Validators
{
    public interface ICreateOrderCommandValidator : IValidator<CreateOrderCommand> { }

    public class CreateOrderCommandValidator : CommandValidator<CreateOrderCommand>, ICreateOrderCommandValidator
    {
        public CreateOrderCommandValidator()
        {

        }

        protected override void CreateRules()
        {

            RuleFor(x => x.Email)
             .EmailAddress()
             .WithMessage("Email inválido");

            RuleFor(x => x.Products)
              .NotNull()
              .WithMessage("Lista de produtos está vazia");

            RuleForEach(p => p.Products).ChildRules(child =>
            {
                child.RuleFor(x => x.Value).NotNull().WithMessage("Valor do produto não pode ser vazio");
                child.RuleFor(x => x.Amount).NotNull().WithMessage("Quantidade do produto não pode ser vazio");
                child.RuleFor(x => x.Name).NotNull().WithMessage("Nome do produto não pode ser vazio");
            });
        }
    }
}
