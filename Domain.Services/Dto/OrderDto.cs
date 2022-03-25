namespace Domain.Services.Dto
{
    public record OrderDto(int Id, int ClientId, decimal TotalValue, string RegistrationDate);
}