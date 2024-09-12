using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppCountryISO.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Alpha_2 { get; set; }
        public string? Alpha_3 { get; set; }
        public string? Code { get; set; }
        public string? Iso_3166_2 { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }

        public string CountryFlag => $"{Alpha_2?.ToLower()}.png";

    }

    public class CountryCreate
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("alpha_2")]
        public string? Alpha_2 { get; set; }

        [JsonProperty("alpha_3")]
        public string? Alpha_3 { get; set; }

        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("iso_3166_2")]
        public string? Iso_3166_2 { get; set; }
    }

    public class State
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("created_at")]
        public DateTime? Created_at { get; set; }
        [JsonProperty("updated_at")]
        public DateTime? Updated_at { get; set; }
    }

    public class StateCreate
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
    }

    public class CountriesResponse
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<Country>? Records { get; set; }
    }

    public class ErrorDetail
    {
        public string? Detail { get; set; }
    }

    public class HTTPValidationError
    {
        public List<ValidationError>? Detail { get; set; }
    }

    public class ValidationError
    {
        public List<object>? Loc { get; set; }
        public string? Msg { get; set; }
        public string? Type { get; set; }
    }

}
