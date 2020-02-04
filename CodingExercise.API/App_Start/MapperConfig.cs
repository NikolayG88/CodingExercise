using VehicleInventory.Services.DTOs;
using CodingExercise.Data.Models;
using CodingExercise.API.Models;
using AutoMapper;

namespace CodingExercise.API.App_Start
{

    public class MapperConfig : MapperConfiguration
    {
        public MapperConfig() : base(cfg =>
        {

            cfg.CreateMap<VehicleInStock, VehicleInStockDTO>()
            .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model.Name))
            .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Model.Make.Name))
            .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Model.Year));


            cfg.CreateMap<AddVehicleInStockDTO, VehicleInStock>();
            cfg.CreateMap<AddVehicleInStockDTO, AddVehicleInStockModel>().ReverseMap();
        })
        {

        }
    }

}