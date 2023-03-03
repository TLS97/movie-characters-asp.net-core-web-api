using AutoMapper;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTOs.Franchises;

namespace MovieCharactersAPI.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            CreateMap<FranchisePostDTO, Franchise>();
            CreateMap<FranchisePutDTO, Franchise>();
            CreateMap<Franchise, FranchiseDTO> ()
                .ForMember(dto => dto.Movies, opt => opt
                .MapFrom(f => f.Movies.Select(m => m.Id).ToList()));
        }
    }
}
