using AutoMapper;
using Dev.App.Api.Dtos;
using Dev.App.Api.Models;

namespace Dev.App.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
             CreateMap<City, CityDto>().ReverseMap();
        }
       
    }
}