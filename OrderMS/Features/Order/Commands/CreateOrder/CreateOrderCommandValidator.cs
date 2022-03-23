using FluentValidation;

namespace OrderMS.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(Order => Order.TotalValue).NotNull();
            RuleFor(Order => Order.ClientId).NotNull();
        }
    }
}