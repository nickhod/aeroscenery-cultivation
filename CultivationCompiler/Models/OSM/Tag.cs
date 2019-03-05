using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompiler.Models.OSM
{
    public class Tag
    {
        public Tag()
        {

        }

        public Tag(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}
