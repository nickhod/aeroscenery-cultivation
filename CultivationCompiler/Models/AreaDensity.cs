using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CultivationCompiler.Models
{
    public class AreaDensity
    {
        [XmlAttribute]
        public int Min { get; set; }

        [XmlAttribute]
        public int Max { get; set; }

        [XmlText]
        public double Value { get; set; }
    }
}
