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
          //  _courseList = await DBService.GetClasses();

            BindingContext = _courseList;
            //courseCarouselView.SetBinding(ItemsView.ItemsSourceProperty, "_courseList");
            courseCarouselView.ItemsSource = term.GetCourseList();



        }

        
          


        private void emailNotesButton_Clicked(object sender, EventArgs e)
        {
            EmailNotesAlert();
        }

        private async void EmailNotesAlert()
        {
            List<string> email = new List<string>();

            Course course = _courseList[courseCarouselView.Position];
            
            string emailToAdd = await DisplayPromptAsync("Email Recipient", "Enter e-mail address", keyboard: Keyboard.Email);

            email.Add(emailToAdd);
            await ComposeEmail.SendEmail("Notes for " + course.Name, course.CourseNotes, email);

        }

        private void editObjectiveAssessmentButton_Clicked(object sender, EventArgs e)
        {
            Course course = _courseList[courseCarouselView.Position];
            EditObjectiveAssessmentPage page = new EditObjectiveAssessmentPage(course);
            page.BindingContext = course;
            //page.BindingContext = _courseList[courseCarouselView.Position];
            Navigation.PushAsync(page);
           
        }

        private void editPerformanceAssessmentButton_Clicked(object sender, EventArgs e)
        {
            Course course = _courseList[courseCarouselView.Position];
            EditPerformanceAssessmentPage page = new EditPerformanceAssessmentPage(course);
            page.BindingContext = course;
            //page.BindingContext = _courseList[courseCarouselView.Position];
            Navigation.PushAsync(page);
            
        }

        private void deleteClassButton_Clicked(object sender, EventArgs e)
        {
            //Course course = _term.ge
            Course course = _courseList[courseCarouselView.Position];
            RemoveCourse(course);
            _term.RemoveCourse(_courseList[courseCarouselView.Position]);
        }

        private void editClassButton_Clicked(object sender, EventArgs e)
        {
            
            Course course = _courseList[courseCarouselView.Position];
            EditCoursePage page = new EditCoursePage(course);
            page.BindingContext = course;
            //page.BindingContext = _courseList[courseCarouselView.Position];
            Navigation.PushAsync(page);
        }

        private async void RemoveCourse(Course course)
        {
            await DBService.DeleteCourse(course.Id);
        }

        private async void UpdateCourse(Course course)
        {
            await DBService.UpdateCourse(course);
        }

        private void notesEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            Course course = _courseList[courseCarouselView.Position];
            UpdateCourse(course);
        }
    }
}