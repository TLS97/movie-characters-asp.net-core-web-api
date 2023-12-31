﻿using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTOs.Characters;

namespace MovieCharactersAPI.Models.DTOs.Movies
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public string Director { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public string Trailer { get; set; } = null!;
        public int FranchiseId { get; set; }
        public List<CharacterSummaryDTO> Characters { get; set; } = null!;

    }
}
