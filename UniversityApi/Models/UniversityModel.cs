using System.Collections.Generic;
using Newtonsoft.Json;

namespace UniversityApi.Models
{
    public class UniversityModel 
    {
        public string Name { get; set; }

        [JsonProperty(PropertyName = "web_pages")]
        public List<string> WebPages { get; set; } = new List<string>();
    }
}