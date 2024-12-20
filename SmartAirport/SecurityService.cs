using System;
using System.Collections.Generic;

namespace SmartAirport
{
    public class SecurityService
    {
        public class SecurityEvent
        {
            public string Time { get; set; }
            public string Event { get; set; }
            public string Level { get; set; }
        }

        private List<SecurityEvent> eventLog = new List<SecurityEvent>();

        public List<SecurityEvent> GetAllEvents()
        {
            return eventLog;
        }

        public void ClearEvents()
        {
            eventLog.Clear();
        }
    }
}
