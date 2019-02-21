using CultivationCompiler.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompilerConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            var cultivationCompilerConsoleManager = new CultivationCompilerConsoleManager();

            var projectFilename = args[0];

            cultivationCompilerConsoleManager.Start(projectFilename);
        }


    }
}
