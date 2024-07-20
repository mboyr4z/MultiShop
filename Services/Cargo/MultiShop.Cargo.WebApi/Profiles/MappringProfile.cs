using AutoMapper;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CargoCompany, CreateCargoCopmanyDto>().ReverseMap();
            CreateMap<CargoCompany, UpdateCargoCompanyDto>().ReverseMap();

            CreateMap<CargoCustomer, CreateCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, UpdateCargoCustomerDto>().ReverseMap();
            
            CreateMap<CargoDetail, CreateCargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, UpdateCargoDetailDto>().ReverseMap();
            
            CreateMap<CargoOperation, CreateCargoOperationDto>().ReverseMap();
            CreateMap<CargoOperation, UpdateCargoOperationDto>().ReverseMap();
        }
    }

}
