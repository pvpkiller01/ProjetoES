using System.ComponentModel;
using System.Text.Json.Serialization;

namespace ESProjeto.Client.Services.MovieServices
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public string Poster_Path { get; set; }
        public string BackdropPath { get; set; }
        public bool Adult { get; set; }
        public string ReleaseDate { get; set; }
        public List<Genre> Genres { get; set; }
        public int Runtime { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public float VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public ProductionCompany[] ProductionCompanies { get; set; }
        public ProductionCountry[] ProductionCountries { get; set; }
        public SpokenLanguage[] SpokenLanguages { get; set; }
        public string OriginalLanguage { get; set; } // The original language of the movie
        public float Popularity { get; set; } // The popularity score of the movie
        public bool Video { get; set; } // Indicates if a video exists for the movie
        public string Homepage { get; set; } // The URL of the movie's homepage
        public string ImdbId { get; set; } // The IMDB id of the movie
        public BelongsToCollection BelongsToCollection { get; set; } // Information about the collection the movie belongs to, if any
        public int Budget { get; set; } // The budget of the movie
        public int Revenue { get; set; } // The revenue of the movie
        public List<CastMember> Cast { get; set; }
        public List<CrewMember> Crew { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductionCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductionCountry
    {
        public string Iso31661 { get; set; }
        public string Name { get; set; }
    }

    public class SpokenLanguage
    {
        public string Iso6391 { get; set; }
        public string Name { get; set; }
    }

    public class BelongsToCollection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }
    }
    public class CastMember
    {
        public int CastId { get; set; }
        public string Character { get; set; }
        public string CreditId { get; set; }
        public int Gender { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string ProfilePath { get; set; }
    }

    public class CrewMember
    {
        public string CreditId { get; set; }
        public string Department { get; set; }
        public int Gender { get; set; }
        public int Id { get; set; }
        public string Job { get; set; }
        public string Name { get; set; }
        public string ProfilePath { get; set; }
    }


}