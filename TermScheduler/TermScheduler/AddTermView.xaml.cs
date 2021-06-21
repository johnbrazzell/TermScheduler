using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermScheduler
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTermView : ContentView
    {


        /// <summary>
        /// this should have a button to add classes
        /// </summary>
        
        private MainPage _mainPage;
        private List<Course> _classList = new List<Course>(); // change this to observable list
        private ObservableCollection<Course> _test = new ObservableCollection<Course>();

      
        public AddTermView()
        {
            InitializeComponent();
            BindingContext = this;
        
        }

        public string GetStartTermLabel()
        {
            return startTermLabel.Text;
        }

        public void SetStartTermLabel(string startTerm)
        {
            startTermLabel.Text = startTerm;
        }

        public string GetEndTermLabel()
        {
            return endTermLabel.Text;
        }

        public void SetEndTermLabel(string endTerm)
        {
            endTermLabel.Text = endTerm;
        }

        public void SetTermName(string termName)
        {
            termNameLabel.Text = termName;
            
        }

        public string GetTermName()
        {
            return termNameLabel.Text;
        }

        public void AddClass(Course newClass)
        {
            if (_classList.Count < 6)
            {
                _classList.Add(newClass);
                _test.Add(newClass);
            }
        }

        public void RemoveClass(Course classToRemove)
        {
            _classList.Remove(classToRemove);
            _test.Remove(classToRemove);
        }

        public Course GetClass(int course)
        {
            return _classList[course];
        }

        public List<Course> GetClassList()
        {
            return _classList;
        }

        public void UpdateCourseCounter()
        {
            //coursesScheduledLabel.Text = _classList.Count.ToString() + " / 6 Courses Scheduled";
            //coursesScheduledLabel.Text = _test.Count.ToString() + " / 6 Courses Scheduled";
        }

        
       

        private void viewTermButton_Clicked(object sender, EventArgs e)
        {
            //this button should launch the term details page
            //this should launch a carousel view of the 
            //associated courses
            if(_classList.Count == 0)
            {
                AddClassesAlert();
                return;
            }

            //Maybe I should reference the main page here
            //add in the actual termview
           // Navigation.PushAsync(new CourseCarouselPage(this));
           //Maybe add binding here
           //create the carouselpage and add binding
           //then push the page
            _mainPage = App.Current.MainPage.Navigation.NavigationStack.First() as MainPage;
        //   _mainPage.AddClassesToCarousel(this);
           //Navigation.PushAsync(new CourseCarouselPage(this));
        }

        private void addCourseButton_Clicked(object sender, EventArgs e)
        {
            //this button should bring you to the term edit page
            //TermCreationPage editTerm = new TermCreationPage();
            //Need to call page with reference to this term
            //That way when the Add Course button is selected you can add the class to the list
           // Navigation.PushAsync(new AddCoursePage(this));

        }

        private void deleteTermButton_Clicked(object sender, EventArgs e)
        {
            //this button should delete the term
            //TODO add a popup warning before confirming delete

            //Reference the root page
            ConfirmDeleteAlert();
            //_mainPage = App.Current.MainPage.Navigation.NavigationStack.First() as MainPage;
            //_mainPage.RemoveTermFromList(this);
            
        }

        private async void AddClassesAlert()
        {

            
            await App.Current.MainPage.DisplayAlert("Alert", "No classes have been added to the term. \nAdd classes to view term.", "OK");

        }

        private async void ConfirmDeleteAlert()
        {
           bool answer = await App.Current.MainPage.DisplayAlert("Alert", "Are you sure you want delete " + this.termNameLabel.Text + "?", "Yes", "No");
           
            if(answer)
            {
                _mainPage = App.Current.MainPage.Navigation.NavigationStack.First() as MainPage;
               // _mainPage.RemoveTermFromList(this);
            }
            else
            {
                return;
            }
        }

    }
}