using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.LocalNotifications;
using System.Collections.ObjectModel;

namespace TermScheduler
{
    public static class PushNotifications
    {

        

        public static async void CheckTermNotifications()
        {

            List<Term> terms = (List<Term>)await DBService.GetTerms();
           

            for(int i = 0; i < terms.Count; i++)
            {
                if(terms[i].TermStartNotifications == true && terms[i].TermStart.Date == DateTime.Today)
                {
                    CrossLocalNotifications.Current.Show("Term Starting", terms[i].TermName + " starts today!");
                }
                if(terms[i].TermEndNotifications == true && terms[i].TermEnd.Date == DateTime.Today)
                {
                    CrossLocalNotifications.Current.Show("Term Ending", terms[i].TermName + " ends today!");
                }
            }

        }

        public static async void CheckCourseNotifications()
        {
            List<Course> courses = (List<Course>)await DBService.GetClasses();

            for (int j = 0; j < courses.Count; j++)
            {
                if (courses[j].CourseStartNotifications == true && courses[j].CourseStartDate == DateTime.Today)
                {
                    CrossLocalNotifications.Current.Show("Course Starting", courses[j].Name + " starts today!");
                }
                if (courses[j].CourseEndNotifications == true && courses[j].CourseEndDate == DateTime.Today)
                {
                    CrossLocalNotifications.Current.Show("Course Ending", courses[j].Name + " ends today!");
                }
            }
        }

        public static async void CheckAssessmentNotifications()
        {
            List<Course> courses = (List<Course>)await DBService.GetClasses();

            for(int k = 0; k < courses.Count; k++)
            {
                if(courses[k].ObjectiveAssessmentStartNotifications == true && courses[k].ObjectiveStart == DateTime.Today)
                {
                    CrossLocalNotifications.Current.Show("Objective Assessment Starting", courses[k].ObjectiveAssessmentName + " starts today!");
                }
                if (courses[k].ObjectiveAssessmentEndNotifications == true && courses[k].ObjectiveEnd == DateTime.Today)
                {
                    CrossLocalNotifications.Current.Show("Objective Assessment Starting", courses[k].ObjectiveAssessmentName + " due today!");
                }

                if (courses[k].PerformanceAssessmentStartNotifications == true && courses[k].PerformanceStart == DateTime.Today)
                {
                    CrossLocalNotifications.Current.Show("Objective Assessment Starting", courses[k].PerformanceAssessmentName + " starts today!");
                }
                if (courses[k].PerformanceAssessmentEndNotifications == true && courses[k].PerformanceEnd == DateTime.Today)
                {
                    CrossLocalNotifications.Current.Show("Objective Assessment Starting", courses[k].PerformanceAssessmentName + " due today!");
                }
            }
        }
        
    }
}
