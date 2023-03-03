using AutoMapper;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTOs.Movies;

namespace MovieCharactersAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieSummaryDTO>();
            CreateMap<Movie, MovieDTO>().ForMember(dto => dto.Characters, opt => opt.MapFrom(m => m.Characters));
        }
    }
}
