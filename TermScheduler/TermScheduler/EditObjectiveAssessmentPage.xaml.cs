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
    public partial class EditObjectiveAssessmentPage : ContentPage
    {

        private Course _course;

        private string _objName;
        private DateTime _objStartDate;
        private DateTime _objEndDate;
        private bool _objStartNotifications;
        private bool _objEndNotifications;

        private bool _isSaveButtonPressed = false;
  
        public EditObjectiveAssessmentPage(Course course)
        {
            InitializeComponent();
            _course = course;

            _objName = _course.ObjectiveAssessmentName;
            _objStartDate = _course.ObjectiveStart;
            _objEndDate = _course.ObjectiveEnd;
            _objStartNotifications = _course.ObjectiveAssessmentStartNotifications;
            _objEndNotifications = _course.ObjectiveAssessmentEndNotifications;
        }
       

        public EditObjectiveAssessmentPage()
        {
            InitializeComponent();
            Title = "Edit Objective Assessment";
       

           
            
        }

        private void RevertChanges()
        {
            assessmentName.Text = _objName;
            startDate.Date = _objStartDate;
            endDate.Date = _objEndDate;
            startCheckBoxNotifications.IsChecked = _objStartNotifications;
            endCheckBoxNotifications.IsChecked = _objEndNotifications;
        }

        private void saveButton_Clicked(object sender, EventArgs e)
        {


            _isSaveButtonPressed = true;
            UpdateObjectiveAssessment();
            Navigation.PopAsync();
        }

        private void cancelButton_Clicked(object sender, EventArgs e)
        {
            _isSaveButtonPressed = false;
            RevertChanges();
            Navigation.PopAsync();
        }

        private async void UpdateObjectiveAssessment()
        {
            await DBService.UpdateCourse(_course);
        }

        protected override async void OnDisappearing()
        {
            if (!_isSaveButtonPressed)
            {

                RevertChanges();
            }
        }
    }
}