using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompiler.Models.GeoJson
{
    public class GeoJsonData
    {
        public GeoJsonData()
        {
            this.Features = new List<Feature>();
        }

        public IList<Feature> Features { get; set; }
    }
}
