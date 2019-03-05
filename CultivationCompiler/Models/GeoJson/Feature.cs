using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompiler.Models.GeoJson
{
    public class Feature
    {
        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }
    }
}
