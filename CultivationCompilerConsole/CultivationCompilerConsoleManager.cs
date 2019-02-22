using CultivationCompiler.Processors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompilerConsole
{
    public class CultivationCompilerConsoleManager
    {
        private CultivationCompilerProcessor cultivationCompilerProcessor;
        private string projectFilename;


        public async void Start(string projectPath)
        {
            this.cultivationCompilerProcessor = new CultivationCompilerProcessor();

            if (!Path.IsPathRooted(projectPath))
            {
                projectPath = Path.GetFullPath(projectPath);
            }

            await cultivationCompilerProcessor.Compile(projectFilename);
        }
    }
}
