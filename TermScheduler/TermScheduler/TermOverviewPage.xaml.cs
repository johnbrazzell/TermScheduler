using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotifications;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermScheduler
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermOverviewPage : ContentPage
    {
        Course _course = null;
        AddTermView _termView = null;

        
        public TermOverviewPage(AddTermView termView, Course course)
        {

            InitializeComponent();
            _course = course;

            _termView = termView;
           
          

        }

        protected override void OnAppearing()
        {
            
            courseNameLabel.Text = _course.Name;
            courseStartLabel.Text = "Start Date " + _course.StartDate;
            courseEndLabel.Text = "End Date " + _course.EndDate;
            courseStatusLabel.Text = "Status: " + _course.CourseStatus;



            instructorNameLabel.Text = "Instructor Name " + _course.InstructorName;
            instructorPhoneLabel.Text = "Instructor Phone " + _course.InstructorPhoneNumber;
            instructorEmailLabel.Text = "Instructor Email " + _course.InstructorEmail;


            if(_course.PerformanceAssessment != null)
                performanceAssessmentNameLabel.Text = _course.PerformanceAssessment.Name; 
            
            
        }
          

        public void UpdatePerformanceAssessment(Course course)
        {
            performanceAssessmentNameLabel.Text = course.PerformanceAssessment.Name;
            performanceAssessmentDueDateLabel.Text = course.PerformanceAssessment.StartDate;
            
        }

        private void emailNotesButton_Clicked(object sender, EventArgs e)
        {
            EmailNotesAlert();
        }

        private async void EmailNotesAlert()
        {
            List<string> email = new List<string>();

            string emailToAdd = await DisplayPromptAsync("Email Recipient", "Enter e-mail address", keyboard: Keyboard.Email);

            email.Add(emailToAdd);
            await ComposeEmail.SendEmail("Notes for " + courseNameLabel.Text, notesEditor.Text, email);

        }

        private void editObjectiveAssessmentButton_Clicked(object sender, EventArgs e)
        {
            //ObjectiveAssessment objAssessment = new ObjectiveAssessment();
            _course.Name = "This is the updated name";
           // Navigation.NavigationStack.
          //  objAssessment.Name = "New Test";
            //_course.ObjectiveAssessment = objAssessment;
            // load information into pop up form
            // unhide form
            // on save add text back
            // on cancel clear form and hide it
            //objectiveAsssessmentNameLabel.Text = _course.ObjectiveAssessment.Name;
           
        }

        private void editPerformanceAssessmentButton_Clicked(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new EditPerformanceAssessmentPage(_termView, _course));
        }

        private void deleteClassButton_Clicked(object sender, EventArgs e)
        {
            _termView.RemoveClass(_course);
        }


        async void TestAlert()
        {
            //bool answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
            string testName = await DisplayPromptAsync("Edit Objective Assessment", "Enter Name");
            string testStart = await DisplayPromptAsync("Edit Objective", "Enter Date"); 
            objectiveAsssessmentNameLabel.Text = testName;
            objectiveAssessmentDueDateLabel.Text = testStart;
        }
    }
}