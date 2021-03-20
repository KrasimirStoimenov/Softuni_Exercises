using AutoMapper;
using CarDealer.DtoModels.InputModels;
using CarDealer.DtoModels.OutputModels;
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

            CreateMap<Car, ExportCarDto>();
            CreateMap<Car, BmwCarExportDto>();
            CreateMap<Supplier, ExportSuppliersDto>()
                .ForMember(x => x.PartCount, y => y.MapFrom(s => s.Parts.Count));
        }
    }
}
