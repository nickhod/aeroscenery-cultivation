using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompiler.Models.OSM
{
    public class OsmData
    {
        public OsmData()
        {
            Bounds = new Bounds();
            Nodes = new Dictionary<long, Node>();
            Ways = new Dictionary<long, Way>();
            Relations = new Dictionary<long, Relation>();
        }

        public Bounds Bounds { get; set; }
        public Dictionary<long, Node> Nodes { get; set; }
        public Dictionary<long, Way> Ways { get; set; }
        public Dictionary<long, Relation> Relations { get; set; }
    }
}
