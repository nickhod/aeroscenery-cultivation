using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompiler.Models.OSM
{
    public class Way : OsmElement
    {
        public Way()
        {
            this.NodeReferences = new List<long>();
            this.Tags = new List<Tag>();
        }

        public long WayId { get; set; }
        public IList<long> NodeReferences { get; set; }
    }
}
