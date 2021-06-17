using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace TermScheduler
{
    public class Term : INotifyPropertyChanged
    {
        private string _name;
        private bool _startNotifications;
        private bool _endNotifications;
        private DateTime _startDate;
        private DateTime _endDate;

        private ObservableCollection<Course> _courseList = new ObservableCollection<Course>();
        
        public event PropertyChangedEventHandler PropertyChanged;

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

        public DateTime TermStartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TermStartDate)));
            }
        }

        public DateTime TermEndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TermEndDate)));
            }
        }



        public ObservableCollection<Course> GetCourseList()
        {
            return _courseList;
        }

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
