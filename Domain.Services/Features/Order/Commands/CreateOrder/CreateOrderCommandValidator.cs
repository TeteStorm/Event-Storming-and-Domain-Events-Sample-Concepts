using FluentValidation;

namespace Domain.Services.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(order => order.TotalValue).NotNull();
            RuleFor(order => order.ClientId).NotNull();
        }
    }
}