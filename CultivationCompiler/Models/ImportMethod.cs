using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CultivationCompiler.Models
{
    public enum ImportMethod
    {
        [XmlEnum(Name = "memory")]
        Memory,
        [XmlEnum(Name = "database")]
        Database
    }
}
