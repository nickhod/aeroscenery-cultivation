using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CultivationCompiler.Models
{
    public enum GeoDataSourceType
    {
        [XmlEnum(Name = "osm")]
        Osm,
        [XmlEnum(Name = "geojson")]
        GeoJson
    }
}
