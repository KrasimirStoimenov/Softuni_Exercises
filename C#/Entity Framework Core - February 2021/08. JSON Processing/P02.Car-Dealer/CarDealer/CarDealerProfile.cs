﻿using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierInputModel, Supplier>();
            CreateMap<PartInputModel, Part>();
            CreateMap<CarInputModel, Car>();
            CreateMap<CustomerInputModel, Customer>();
            CreateMap<SaleInputModel, Sale>();
        }
    }
}
