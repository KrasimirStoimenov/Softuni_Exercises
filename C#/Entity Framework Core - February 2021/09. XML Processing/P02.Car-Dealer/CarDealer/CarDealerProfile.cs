using AutoMapper;
using CarDealer.DtoModels.InputModels;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<InputSuppliersDto, Supplier>();
            CreateMap<InputPartsDto, Part>();
            CreateMap<InputCustomersDto, Customer>();
        }
    }
}
