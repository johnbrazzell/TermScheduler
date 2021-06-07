using System;
using System.Collections.Generic;
using System.Text;

namespace TermScheduler
{
    public class ObjectiveAssessment
    {
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool ActivateStartNotifications { get; set; }
        public bool ActivateEndNotifications { get; set; }

    }
}
