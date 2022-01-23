using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace TesteKryptusMVVM.Models
{
    class Movie
    {
        [JsonProperty(PropertyName = "episode_id")]
        public int EpisodeId { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "opening_crawl")]
        public string OpeningCrawl { get; set; }

        [JsonProperty(PropertyName = "director")]
        public string Director {get; set;}

        [JsonProperty(PropertyName = "producer")]
        public string Producer { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "edited")]
        public DateTime Edited { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "characters")]
        public string[] CharactersUrl { get; set; }

        [JsonProperty(PropertyName = "planets")]
        public string[] PlanetsUrl { get; set; }

        [JsonProperty(PropertyName = "starships")]
        public string[] StarshipsUrl { get; set; }

        [JsonProperty(PropertyName = "vehicles")]
        public string[] VehiclesUrl { get; set; }

        [JsonProperty(PropertyName = "species")]
        public string[] SpeciesUrl { get; set; }

        public Character[] Characters { get; set; }

        public Planet[] Planets{ get; set; }

        public Starship[] Starships { get; set; }

        public Vehicle[] Vehicles { get; set; }

        public Specie[] Species{ get; set; }

        //Characters - Character Object

        //Planets - Planet Object

        //starship

        //vehicles

        //species




    }
}
