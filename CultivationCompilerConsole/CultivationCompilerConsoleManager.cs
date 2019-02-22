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


        public void Start(string projectPath)
        {
            this.cultivationCompilerProcessor = new CultivationCompilerProcessor();

            if (!Path.IsPathRooted(projectPath))
            {
                projectPath = Path.GetFullPath(projectPath);
            }

            cultivationCompilerProcessor.Compile(projectPath);
        }
    }
}
