using AutoMapper;
using Domain.Core;
using Domain.Services.Dto;
using Domain.Services.Features.Order.Commands.CreateOrder;
using System;

namespace Domain.Services.Infrastructure.Mapper
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