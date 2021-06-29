using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using SQLite;

namespace TermScheduler
{
    public class Term : INotifyPropertyChanged
    {
        private string _name;
        private bool _startNotifications;
        private bool _endNotifications;
        //private string _startDate;
        //private string _endDate;
        private DateTime _termStartDate = DateTime.Now;
        private DateTime _termEndDate = DateTime.Now;

        private ObservableCollection<Course> _courseList = new ObservableCollection<Course>();
        
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TermName
        {
            get => _name;
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TermName)));
            }
        }

        public bool TermStartNotifications
        {
            get => _startNotifications;
            set
            {
                _startNotifications = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TermStartNotifications)));
            }
        }


        public bool TermEndNotifications
        {
            get => _endNotifications;
            set
            {
                _endNotifications = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TermEndNotifications)));
            }
        }

        public string TermStartDate
        {
            get => _termStartDate.ToShortDateString();
            //set
            //{
            //    _startDate = value;
            //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TermStartDate)));
            //}
        }

        public string TermEndDate
        {
            get => _termEndDate.ToShortDateString();
            //set
            //{
            //    _endDate = value;
            //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TermEndDate)));
            //}
        }

        public DateTime TermStart
        {
            get => _termStartDate;
            set
            {
                _termStartDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TermStart)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TermStartDate)));
            }
        }


        public DateTime TermEnd
        {
            get => _termEndDate;
            set
            {
                _termEndDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TermEnd)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TermEndDate)));
            }
        }


        public ObservableCollection<Course> GetCourseList()
        {
            return _courseList;
        }

        //associate by term name
        public void AddCoursePage(Course course)
        {
            if (_courseList.Count < 6)
                _courseList.Add(course);
            else
                return;
        }

        public void RemoveCourse(Course course)
        {
            _courseList.Remove(course);
        }
    }
}
