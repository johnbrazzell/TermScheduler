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
    
    public partial class EditPerformanceAssessmentPage : ContentPage
    {
        private Course _course;
        private bool _isSaveButtonPressed = false;

        private string _perfName;
        private DateTime _perfStart;
        private DateTime _perfEnd;
        private bool _perfStartNotifications;
        private bool _perfEndNotifications;

        public EditPerformanceAssessmentPage(Course course)
        {
            InitializeComponent();
            Title = "Edit Performance Assessment";
            _course = course;

            _perfName = _course.PerformanceAssessmentName;
            _perfStart = _course.PerformanceStart;
            _perfEnd = _course.PerformanceEnd;
            _perfStartNotifications = _course.PerformanceAssessmentStartNotifications;
            _perfEndNotifications = _course.PerformanceAssessmentEndNotifications;
        }
   
        public EditPerformanceAssessmentPage()
        {
            InitializeComponent();
          
            
            Title = "Edit Performance Assessment";
            
          
      
        }

      

        private void RevertChanges()
        {
            assessmentName.Text = _perfName;
            startDate.Date = _perfStart;
            endDate.Date = _perfEnd;
            startCheckBoxNotifications.IsChecked = _perfStartNotifications;
            endCheckBoxNotifications.IsChecked = _perfEndNotifications;
        }

        private async void UpdatePerformanceAssessment(Course course)
        {
            await DBService.UpdateCourse(course);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (!_isSaveButtonPressed)
            {
                RevertChanges();
            }

        }

        private void saveButton_Clicked_1(object sender, EventArgs e)
        {
            _isSaveButtonPressed = true;
            UpdatePerformanceAssessment(_course);
            Navigation.PopAsync();
        }

        private void cancelButton_Clicked_1(object sender, EventArgs e)
        {
            _isSaveButtonPressed = false;
            //RevertChanges();
            Navigation.PopAsync();
        }
    }
}