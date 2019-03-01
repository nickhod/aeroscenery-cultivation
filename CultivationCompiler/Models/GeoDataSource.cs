using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CultivationCompiler.Models
{
    public class GeoDataSource
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public GeoDataSourceType Type { get; set; }

        [XmlAttribute]
        public ImportMethod ImportMethod { get; set; }

        [XmlText]
        public string Filename { get; set; }
    }
}
