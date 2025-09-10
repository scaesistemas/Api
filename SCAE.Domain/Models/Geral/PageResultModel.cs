using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace SCAE.Domain.Models.Geral
{
    public class PageResultModel<T>
    {
        [JsonPropertyName("items")]
        public List<T> Items { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
