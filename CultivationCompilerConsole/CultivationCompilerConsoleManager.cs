using CultivationCompiler.Common;
using CultivationCompiler.Processors;
using log4net;
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
        private readonly ILog log = LogManager.GetLogger("Cultivation Compiler");

        private CultivationCompilerProcessor cultivationCompilerProcessor;

        public void Start(string projectPath)
        {

            this.cultivationCompilerProcessor = CultivationCompilerProcessor.Instance;

            this.cultivationCompilerProcessor.OnEventLogMessage += OnEventLogMessageReceived;

            if (!Path.IsPathRooted(projectPath))
            {
                projectPath = Path.GetFullPath(projectPath);
            }

            cultivationCompilerProcessor.Compile(projectPath);
        }

        public void OnEventLogMessageReceived(object sender, EventLogMessageEventArgs e)
        {
            log.Info(e.EventLogMessage.Message);
        }

        public void OnProgressMessageReceived(object sender, ProgressMessageEventArgs e)
        {
            log.Info(e.ProgressMessage.Activity);

        }
    }
}
