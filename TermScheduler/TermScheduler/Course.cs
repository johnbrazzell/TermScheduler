using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;

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
    public class Course : INotifyPropertyChanged
    {
        private string _name;
        private string _startDate;
        private string _endDate;
        private DateTime _courseStartDate;
        private DateTime _courseEndDate;
        private string _courseStatus;
        private string _instructorName;
        private string _instructorPhoneNumber;
        private string _instructorEmail;
        private bool _courseStartNotifications;
        private bool _courseEndNotifications;

        private string _objName;
        private string _objStartDate;
        private string _objEndDate;
        private bool _objStartNotification;
        private bool _objEndNotification;

        private string _perfName;
        private string _perfStartDate;
        private string _perfEndDate;
        private bool _perfStartNotification;
        private bool _perfEndNotification;

        private string _courseNotes;

        private DateTime _performanceStart = DateTime.Now;
        private DateTime _performanceEnd = DateTime.Now;
        private DateTime _objectiveStart = DateTime.Now;
        private DateTime _objectiveEnd = DateTime.Now;

        //implement INotifyPropertyChanged
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int TermID { get; set; }

        public DateTime CourseStartDate
        {
            get => _courseStartDate;
            set
            {
                _courseStartDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CourseStartDate)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StartDate)));

            }
        }

        public DateTime CourseEndDate
        {
            get => _courseEndDate;
            set
            {
                _courseEndDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CourseEndDate)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EndDate)));
            }
        }
        public bool CourseStartNotifications
        {
            get => _courseStartNotifications;
            set
            {
                _courseStartNotifications = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CourseStartNotifications)));
            }
        }

        public bool CourseEndNotifications
        {
            get => _courseEndNotifications;
            set
            {
                _courseEndNotifications = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CourseEndNotifications)));
            }
        }

        public DateTime PerformanceStart {
            get => _performanceStart;
            set
            {
                _performanceStart = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PerformanceStart)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ObjectiveAssessmentStartDate)));
            }
            }

        public DateTime PerformanceEnd
        {
            get => _performanceEnd;
            set
            {
                _performanceEnd = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PerformanceEnd)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ObjectiveAssessmentEndDate)));
            }
        }

        public DateTime ObjectiveStart
        {
            get => _objectiveStart;
            set
            {
                _objectiveStart = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ObjectiveStart)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ObjectiveAssessmentStartDate)));
            }
        }

        public DateTime ObjectiveEnd
        {
            get => _objectiveEnd;
            set
            {
                _objectiveEnd = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ObjectiveEnd)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ObjectiveAssessmentEndDate)));
            }
        }

        public string Name { 
            get => _name;
            set {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }
        public string StartDate { 
            get => _courseStartDate.ToShortDateString();
            //set { 
            //    _startDate = value;
            //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StartDate)));
            //}
        }
        public string EndDate { 
            get => _courseEndDate.ToShortDateString(); 
            //set {
            //    _endDate = value;
            //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EndDate)));
            //} 
        }
        public string CourseStatus { 
            get => _courseStatus;
            set {
                _courseStatus = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CourseStatus)));
            } 
        }
        public string InstructorName { 
            get => _instructorName;
            set {
                _instructorName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InstructorName)));
            } 
        }
        public string InstructorPhoneNumber { 
            get => _instructorPhoneNumber;
            set {
                _instructorPhoneNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InstructorPhoneNumber)));
            } 
        }
        public string InstructorEmail { 
            get => _instructorEmail;
            set {
                _instructorEmail = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InstructorEmail)));
            } 
        }

        public string ObjectiveAssessmentName
        {
            get => _objName;
            set
            {
                _objName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ObjectiveAssessmentName)));
            }
        }

        public string ObjectiveAssessmentStartDate  
        {
            get => _objectiveStart.ToShortDateString();
            //get
            //{
            //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ObjectiveAssessmentStartDate)));
            //    return _objectiveStart.ToShortDateString();
            //}
            //set
            //{
            //    _objStartDate = value;
            //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ObjectiveAssessmentStartDate)));
            //}
        }

        public string ObjectiveAssessmentEndDate
        {
            get => _objectiveEnd.ToShortDateString();
            //set
            //{
            //    _objEndDate = value;
            //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ObjectiveAssessmentEndDate)));
            //}
        }

        public bool ObjectiveAssessmentStartNotifications
        {
            get => _objStartNotification;
            set
            {
                _objStartNotification = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ObjectiveAssessmentStartNotifications)));
            }
        }

        public bool ObjectiveAssessmentEndNotifications
        {
            get => _objEndNotification;
            set
            {
                _objEndNotification = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ObjectiveAssessmentEndNotifications)));
            }
        }

        public string PerformanceAssessmentName
        {
            get => _perfName;
            set
            {
                _perfName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PerformanceAssessmentName)));
            }
        }

        public string PerformanceAssessmentStartDate
        {
            get => _performanceStart.ToShortDateString();
            //set
            //{
            //    _perfStartDate = value;
            //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PerformanceAssessmentStartDate)));
            //}
        }

        public string PerformanceAssessmentEndDate
        {
            get => _performanceStart.ToShortDateString();
            //set
            //{
            //    _perfEndDate = value;
            //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PerformanceAssessmentEndDate)));
            //}
        }

        public bool PerformanceAssessmentStartNotifications
        {
            get => _perfStartNotification;
            set
            {
                _perfStartNotification = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PerformanceAssessmentStartNotifications)));
            }
        }

        public bool PerformanceAssessmentEndNotifications
        {
            get => _perfEndNotification;
            set
            {
                _perfEndNotification = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PerformanceAssessmentEndNotifications)));
            }
        }

        public string CourseNotes
        {
            get => _courseNotes;
            set
            {
                _courseNotes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CourseNotes)));
            }
        }
        //name, start date, end date, start notification, end notification
        //public ObjectiveAssessment ObjectiveAssessment { get; set; }
        //public PerformanceAssessment PerformanceAssessment { get; set; }

      
        public event PropertyChangedEventHandler PropertyChanged;


        
    
    }
}
