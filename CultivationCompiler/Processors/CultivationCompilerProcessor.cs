using CultivationCompiler.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompiler.Processors
{
    public class CultivationCompilerProcessor
    {
        private ProjectService projectService;

        public CultivationCompilerProcessor()
        {
            projectService = new ProjectService();
        }

        public void Compile(string projectFilename)
        {
            var project = projectService.LoadProject(projectFilename);
            int i = -0;
        }
    }
}
