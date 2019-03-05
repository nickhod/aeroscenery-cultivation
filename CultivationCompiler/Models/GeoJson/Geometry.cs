using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompiler.Models.GeoJson
{
    public class Geometry
    {
        [JsonProperty("type")]
        public GeoJsonGeometryType Type { get; set; }

        public IList<Coordinate> Coordinates { get; set; }

    }
}
