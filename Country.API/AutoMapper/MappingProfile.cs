using AutoMapper;
using Country.API.DTOs.CityDto;
using Country.API.DTOs.CountryDto;
using Country.API.DTOs.StateDto;
using Country.API.Models.City;
using Country.API.Models.Country;
using Country.API.Models.State;

namespace Country.API.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CountryResponseDto, CountryModel>().ReverseMap();
            CreateMap<CountryWithStatesDto,CountryModel>().ReverseMap();
            CreateMap<UpdateCountryDto, CountryModel>().ReverseMap();
            CreateMap<CreateCountryDto, CountryModel>().ReverseMap();

            CreateMap<CreateStateDto, StateModel>().ReverseMap();
            CreateMap<StateResponseDto, StateModel>().ReverseMap();
            CreateMap<StateWithCitiesDto, StateModel>().ReverseMap();
            CreateMap<UpdateStateDto, StateModel>().ReverseMap();

            CreateMap<CityResponseDto, CityModel>().ReverseMap();
            CreateMap<CreateCityDto, CityModel>().ReverseMap();
            CreateMap<UpdateCityDto, CityModel>().ReverseMap();

        }
    }
}
