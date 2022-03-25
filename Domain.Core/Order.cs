using System;

namespace Domain.Core
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public decimal TotalValue { get; set; } = default!;
        public DateTime RegistrationDate { get; set; }
    }
}