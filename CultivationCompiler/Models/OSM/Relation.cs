using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompiler.Models.OSM
{
    public class Relation : OsmElement
    {
        public Relation()
        {
            Members = new List<Member>();
            this.Tags = new List<Tag>();
        }

        public long RelationId { get; set; }

        public IList<Member> Members { get; set; }
    }
}
