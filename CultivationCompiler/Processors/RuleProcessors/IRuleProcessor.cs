using CultivationCompiler.Models.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompiler.Processors.RuleProcessors
{
    public interface IRuleProcessor<T> where T : Rule
    {
        void Process(T rule);
    }
}
