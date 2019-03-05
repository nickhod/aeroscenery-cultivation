using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompiler.Models.OSM
{
    public class Member
    {
        public string Type { get; set; }
        public long Ref { get; set; }
        public string Role { get; set; }
    }
}
