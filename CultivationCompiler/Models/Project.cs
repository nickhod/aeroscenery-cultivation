using CultivationCompiler.Models.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CultivationCompiler.Models
{
    public class Project
    {
        public string MinimumCultivationCompilerVersion { get; set; }
        public List<GeoDataSource> GeoDataSources { get; set; }


        [XmlArray]
        [XmlArrayItem(ElementName = "DistributeObjectsRule", Type = typeof(DistributeObjectsRule))]
        public List<Rule> Rules { get; set; }
        public Output Output { get; set; }
    }
}
