using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompiler.Models.Rules
{
    public class DistributeObjectsRule : Rule
    {
        public double Density { get; set; }

        public List<AFObject> Objects { get; set; }

        public List<Filter> Filters { get; set; }

        public List<AreaDensity> AreaDensities { get; set; }
    }
}
