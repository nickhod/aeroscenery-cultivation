using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CultivationCompiler.Models.Rules
{
    [XmlInclude(typeof(BuildingsRule))]
    [XmlInclude(typeof(DistributeObjectsRule))]
    [XmlInclude(typeof(ExcludeRule))]
    [XmlInclude(typeof(LineRule))]
    [XmlInclude(typeof(NodeTrackerRule))]
    [XmlInclude(typeof(ObjectRule))]
    [XmlInclude(typeof(ShapeBuildingRule))]
    [XmlInclude(typeof(WayTrackerRule))]
    public class Rule
    {
        [XmlAttribute]
        public string GeoDataSource { get; set; }

    }
}
