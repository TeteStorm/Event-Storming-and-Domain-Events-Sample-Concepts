using AutoMapper;
using OrderMS.Domain;
using OrderMS.Dto;
using OrderMS.Features.Order.Commands.CreateOrder;
using System;

namespace OrderMS.Infrastructure.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderCommand, Order>()
                .ForMember(c => c.RegistrationDate, opt =>
                    opt.MapFrom(_ => DateTime.Now));

            CreateMap<Order, OrderDto>()
                .ForMember(cd => cd.RegistrationDate, opt =>
                    opt.MapFrom(c => c.RegistrationDate.ToShortDateString()));
        }
    }
}