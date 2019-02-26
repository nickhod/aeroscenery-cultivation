using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompiler.Common
{
    public class EventLogMessage
    {
        public string Message { get; set; }
        public string Sender { get; set; }
        public DateTime Time { get; set; }
        public EventLogLevel Level { get; set; }

        public EventLogMessage()
        {

        }

        public EventLogMessage(string message, object sender, EventLogLevel level)
        {
            Time = DateTime.Now;
            this.Message = message;
            this.Sender = sender.ToString();
            this.Level = level;
        }
    }
}
