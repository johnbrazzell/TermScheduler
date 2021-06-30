using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermScheduler
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCoursePage : ContentPage
    {
        Course _course;

        private string _courseName;
        private DateTime _courseStart;
        private DateTime _courseEnd;
        private string _courseStatus;
        private string _instructorName;
        private string _instructorPhone;
        private string _instructorEmail;
        private bool _courseStartNotifications;
        private bool _courseEndNotifications;

        private bool _isSaveButtonPressed = false;

        public EditCoursePage(Course course)
        {
            InitializeComponent();
            _course = course;
            courseStatus.Items.Add("Not Started");
            courseStatus.Items.Add("In Progress");
            courseStatus.Items.Add("Completed");
            courseStatus.Items.Add("Dropped");

            _courseName = _course.Name;
            _courseStart = _course.CourseStartDate;
            _courseEnd = _course.CourseEndDate;
            _courseStatus = _course.CourseStatus;
            _instructorName = _course.InstructorName;
            _instructorEmail = _course.InstructorEmail;
            _instructorPhone = _course.InstructorPhoneNumber;
            _courseStartNotifications = _course.CourseStartNotifications;
            _courseEndNotifications = _course.CourseEndNotifications;

        }
        public EditCoursePage()
        {
            InitializeComponent();
            courseStatus.Items.Add("Not Started");
            courseStatus.Items.Add("In Progress");
            courseStatus.Items.Add("Completed");
            courseStatus.Items.Add("Dropped");
        }

        private void cancelButton_Clicked(object sender, EventArgs e)
        {
            _isSaveButtonPressed = false;
            Navigation.PopAsync();
        }

        private void saveButton_Clicked(object sender, EventArgs e)
        {
            _isSaveButtonPressed = true;
            UpdateCourse(_course);
            Navigation.PopAsync();
        }

        private async void UpdateCourse(Course course)
        {
            await DBService.UpdateCourse(course);
        }

        private void RevertChanges()
        {
            courseNameEntry.Text = _courseName;
            courseStartDate.Date = _courseStart;
            courseEndDate.Date = _courseEnd;
            courseStatus.SelectedItem = _courseStatus;
            instructorNameEntry.Text = _instructorName;
            instructorEmailAddressEntry.Text = _instructorEmail;
            instructorPhoneNumberEntry.Text = _instructorPhone;
            startNotifications.IsChecked = _courseStartNotifications;
            endNotifications.IsChecked = _courseEndNotifications;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if(!_isSaveButtonPressed)
            {
                RevertChanges();
            }

        }
    }
}