﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivationCompiler.Common
{
    public class EventLogMessageEventArgs : EventArgs
    {
        public EventLogMessage EventLogMessage { get; set; }
    }
}
