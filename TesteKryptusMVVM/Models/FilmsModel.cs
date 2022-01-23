using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Newtonsoft.Json;


namespace TesteKryptusMVVM.Models
{
    class FilmsModel
    {
        [JsonProperty(PropertyName = "count")]
        public int count {get; set;}

        [JsonProperty(PropertyName = "next")]
        public string next { get; set; }

        [JsonProperty(PropertyName = "previous")]
        public string previous { get; set; }

        [JsonProperty(PropertyName = "results")]
        public Movie[] movies { get; set; }
}
}
