
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
            CreateMap<Movie, MovieDto>().ReverseMap(); 
            CreateMap<MembershipType, MembershipTypeDto>().ReverseMap();
            CreateMap<Genre, GenreDto>().ReverseMap();
        }
    }
}
