using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompiler.Models.OSM
{
    public class Node
    {
        public long NodeId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool Visible { get; set; }

    }
}
