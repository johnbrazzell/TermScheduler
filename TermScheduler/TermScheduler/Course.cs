using System;
using System.Collections.Generic;
using System.Text;

namespace TermScheduler
{
    /// <summary>
    /// need to add:
    /// Course Name
    /// Start and Anticipated End Date
    /// Course Status (use a picker)
    /// Course Instructors Information (name, phone, email)
    /// 
    /// </summary>
    /// 
    public class Course
    {
     
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string CourseStatus { get; set; }
        public string InstructorName { get; set; }
        public string InstructorPhoneNumber { get; set; }
        public string InstructorEmail { get; set; }

        public ObjectiveAssessment ObjectiveAssessment { get; set; }
        public PerformanceAssessment PerformanceAssessment { get; set; }

      


        
    
    }
}
