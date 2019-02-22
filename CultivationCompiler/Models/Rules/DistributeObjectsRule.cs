using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompiler.Models.Rules
{
    public class DistributeObjectsRule : Rule
    {
        public int Density { get; set; }

        public IList<AFObject> Objects { get; set; }

        public IList<Filter> Filters { get; set; }
    }
}
