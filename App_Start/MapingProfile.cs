
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;
namespace Vidly.App_Start
{
    public class MapingProfile: Profile
    {

        public MapingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<Movie, MovieDto>().ReverseMap(); 
            CreateMap<MovieDto, MovieDto>().ReverseMap(); 
        }
    }
}
