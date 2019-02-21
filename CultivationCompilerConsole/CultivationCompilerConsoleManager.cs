using CultivationCompiler.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompilerConsole
{
    public class CultivationCompilerConsoleManager
    {
        private CultivationCompilerProcessor cultivationCompilerProcessor;
        private string projectFilename;


        public async void Start(string projectFilename)
        {
            this.cultivationCompilerProcessor = new CultivationCompilerProcessor();


            await cultivationCompilerProcessor.Compile(projectFilename);
        }
    }
}
