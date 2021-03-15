using AutoMapper;
using CarDealer.DTO.InputModels;
using CarDealer.DTO.OutputModels;
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

            CreateMap<Customer, CustomerOutputModel>()
                .ForMember(x => x.BirthDate, y => y.MapFrom(c => c.BirthDate.ToString("dd/MM/yyyy")));
            CreateMap<Supplier, SupplierOutputModel>()
                .ForMember(x => x.PartsCount, y => y.MapFrom(s => s.Parts.Count));
        }
    }
}
