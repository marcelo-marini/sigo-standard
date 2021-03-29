using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Sigo.Standard.Api.Models.Response
{
    public class GetStandardResponse
    {
        [JsonProperty("id"), DisplayName("id")]
        public string Id { get; set; }
        [JsonProperty("description"), DisplayName("description")]
        public string Description { get; set; }
        [JsonProperty("url"), DisplayName("url")]
        public string Url { get; set; }
        [JsonProperty("status"), DisplayName("status")]
        public string Status { get; set; }
        [JsonProperty("created_at"), DisplayName("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at"), DisplayName("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("type"), DisplayName("type")]
        public string Type { get; set; }

        [JsonProperty("owner"), DisplayName("owner")]
        public string Owner { get; set; }

        [JsonProperty("code"), DisplayName("code")]
        public string Code { get; set; }

        GetStandardResponse(Domain.Standard standard)
        {
            Id = standard.ExternalId;
            Description = standard.Description;
            Status = standard.Status;
            Url = standard.Url;
            CreatedAt = standard.CreatedAt;
            UpdatedAt = standard.UpdatedAt;
            Type = standard.Type;
            Owner = standard.Owner;
            Code = standard.Code;
        }

        public static GetStandardResponse Create(Domain.Standard standard)
        {
            return new GetStandardResponse(standard);
        }
    }
}