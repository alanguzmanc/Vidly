
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;
namespace Vidly.App_Start
{
    public class MapingProfile: Profile
    {

        public MapingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, MovieDto>();
            CreateMap<List<Movie>,List<MovieDto>>();
        }
    }
}
