using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        Term _term = null;

        ObservableCollection<Course> _courseList = new ObservableCollection<Course>();
        public TermOverviewPage(Term term)
        {

            InitializeComponent();
            _term = term;
            _courseList = term.GetCourseList();
            BindingContext = _courseList;
            courseCarouselView.SetBinding(ItemsView.ItemsSourceProperty, "term.GetCourseList()");
            courseCarouselView.ItemsSource = term.GetCourseList();



        }

 
          

        public void UpdatePerformanceAssessment(Course course)
        {
           // performanceAssessmentNameLabel.Text = course.PerformanceAssessment.Name;
           // performanceAssessmentDueDateLabel.Text = course.PerformanceAssessment.StartDate;
            
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
           // await ComposeEmail.SendEmail("Notes for " + courseNameLabel.Text, notesEditor.Text, email);

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
            EditPerformanceAssessmentPage page = new EditPerformanceAssessmentPage();
            page.BindingContext = _courseList[courseCarouselView.Position];
            Navigation.PushAsync(page);
           // Navigation.PushAsync(new EditPerformanceAssessmentPage(_termView, _course));
        }

        private void deleteClassButton_Clicked(object sender, EventArgs e)
        {
            //Course course = _term.ge
            _term.RemoveCourse(_courseList[courseCarouselView.Position]);
        }

        private void editClassButton_Clicked(object sender, EventArgs e)
        {
            //create new page
            //set binding to this course
            
        }
    }
}