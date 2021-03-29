using System.ComponentModel;
using Newtonsoft.Json;
using Sigo.Standard.Api.Domain.Contracts;

namespace Sigo.Standard.Api.Models.Request
{
    public class CreateStandardRequest : ICreateStandardRequest
    {
        [JsonProperty("description"), DisplayName("description")]
        public string Description { get; set; }

        [JsonProperty("url"), DisplayName("url")]
        public string Url { get; set; }

        [JsonProperty("type"), DisplayName("type")]
        public string Type { get; set; }

        [JsonProperty("owner"), DisplayName("owner")]
        public string Owner { get; set; }

        [JsonProperty("code"), DisplayName("code")]
        public string Code { get; set; }
    }
}