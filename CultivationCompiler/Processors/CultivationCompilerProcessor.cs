using CultivationCompiler.Common;
using CultivationCompiler.Models;
using CultivationCompiler.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompiler.Processors
{
    public class CultivationCompilerProcessor
    {
        private ProjectService projectService;
        private OsmDataService osmDataService;

        public event EventHandler<EventLogMessageEventArgs> OnEventLogMessage;
        public event EventHandler<ProgressMessageEventArgs> OnProgressMessage;

        private static CultivationCompilerProcessor instance;

        public CultivationCompilerProcessor()
        {
            projectService = new ProjectService();
            osmDataService = new OsmDataService();
        }

        public void Compile(string projectFilename)
        {
            var eventLogMessage = new EventLogMessage("Test message", this, EventLogLevel.Debug);
            RaiseEventLogMessage(eventLogMessage);

            var project = projectService.LoadProject(projectFilename);

            foreach (var geoDataSource in project.GeoDataSources)
            {
                //geoDataSource.Filename

                var geoDataFilename = geoDataSource.Filename;

                // If it's a relative path get the absolute path
                if (!Path.IsPathRooted(geoDataFilename))
                {
                    geoDataFilename = Path.GetFullPath(geoDataFilename);
                }

                switch (geoDataSource.Type)
                {
                    case GeoDataSourceType.Osm:

                        this.osmDataService.ReadOSMData(geoDataFilename, geoDataSource.ImportMethod);
                        break;
                    case GeoDataSourceType.GeoJson:
                        break;
                }
            }
        }

        public void RaiseEventLogMessage(EventLogMessage eventLogMessage)
        {
            var eventArgs = new EventLogMessageEventArgs();
            eventArgs.EventLogMessage = eventLogMessage;

            OnEventLogMessage?.Invoke(this, eventArgs);
        }

        public void RaiseEventLogMessage(string message, object sender, EventLogLevel level)
        {
            var eventLogMessage = new EventLogMessage();
            eventLogMessage.Time = DateTime.Now;
            eventLogMessage.Message = message;
            eventLogMessage.Sender = sender.ToString();
            eventLogMessage.Level = level;

            RaiseEventLogMessage(eventLogMessage);
        }

        public void RaiseProgressMessage(ProgressMessage progressMessage)
        {
            var eventArgs = new ProgressMessageEventArgs();
            eventArgs.ProgressMessage = progressMessage;

            OnProgressMessage?.Invoke(this, eventArgs);
        }

        public static CultivationCompilerProcessor Instance
        {
            get
            {
                if (CultivationCompilerProcessor.instance == null)
                {
                    CultivationCompilerProcessor.instance = new CultivationCompilerProcessor();
                }

                return CultivationCompilerProcessor.instance;
            }
        }

    }
}
