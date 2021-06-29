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
    public partial class AddCoursePage : ContentPage
    {
        private Term _term;
        private MainPage _mainPage;
        public AddCoursePage(Term term)
        {
            InitializeComponent();
           
            courseStatus.Items.Add("Not Started");
            courseStatus.Items.Add("In Progress");
            courseStatus.Items.Add("Completed");
            courseStatus.Items.Add("Dropped");

            courseStatus.SelectedIndex = 0;

            _term = term;
        }

        private void cancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void AddCourse(Course course)
        {
            await DBService.AddCourse(course.Name, course.TermID, course.CourseStartDate, course.CourseEndDate, course.CourseStatus, course.InstructorName, course.InstructorPhoneNumber,
                                       course.InstructorEmail, course.CourseStartNotifications, course.CourseEndNotifications, "", DateTime.Now,
                                       DateTime.Now, false, false, "", DateTime.Now, DateTime.Now, false, false, "");
        }
        private void addCourseButton_Clicked(object sender, EventArgs e)
        {
            Course course = new Course();
            course.Name = courseNameEntry.Text;
            course.CourseStatus = courseStatus.SelectedItem.ToString();

            course.CourseStartDate = courseStartDate.Date;
            course.CourseEndDate = courseEndDate.Date;
            course.InstructorName = instructorNameEntry.Text;
            course.InstructorPhoneNumber = instructorPhoneNumberEntry.Text;
            course.InstructorEmail = instructorEmailAddressEntry.Text;
            course.TermID = _term.Id;
            
            _term.AddCoursePage(course);
            AddCourse(course);
            
            

            //Call DB add course
            //_mainPage.AddClassesToCarousel();
            Navigation.PopAsync();
        }

    
    }
}