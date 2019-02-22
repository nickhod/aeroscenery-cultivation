using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CultivationCompiler.Models.Rules
{
    public class AFObject
    {
        [XmlAttribute]
        public string Type { get; set; }

        [XmlAttribute]
        public int Weight{ get; set; }


        [XmlText]
        public string Value { get; set; }
    }
}
