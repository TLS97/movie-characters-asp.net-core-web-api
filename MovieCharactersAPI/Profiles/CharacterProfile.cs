using AutoMapper;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTOs.Characters;

namespace MovieCharactersAPI.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile() 
        {
            CreateMap<CharacterPutDTO, Character>();
            CreateMap<CharacterPostDTO, Character>();
            CreateMap<Character, CharacterDTO>()
                .ForMember(dto => dto.Movies, opt => opt.MapFrom(p => p.Movies.Select(s => s.Id).ToList()));
        }
    }
}
