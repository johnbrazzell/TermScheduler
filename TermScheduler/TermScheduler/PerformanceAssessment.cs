using System;
using System.Collections.Generic;
using System.Text;

namespace TermScheduler
{
    public class PerformanceAssessment
    {


        public PerformanceAssessment()
        {

        }
        public PerformanceAssessment(string name, string startDate, string endDate, bool startNotificationsOn, bool endNotifcationsOn)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            ActivateStartNotifications = startNotificationsOn;
            ActivateEndNotifications = endNotifcationsOn;
        }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool ActivateStartNotifications { get; set; }
        public bool ActivateEndNotifications { get; set; }

    }
}
