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

    
        Course _course = null;

       

        public EditObjectiveAssessmentPage(Course course)
        {
            InitializeComponent();
            Title = "Edit Objective Assessment";
       
            _course = course;
            LoadData();
           
            
        }

        private void LoadData()
        {
            if(_course.ObjectiveAssessmentName != null)
            {
                assessmentName.Text = _course.ObjectiveAssessmentName;
            }
            if (_course.ObjectiveAssessmentStartDate != null)
            {
                DateTime d = Convert.ToDateTime(_course.ObjectiveAssessmentStartDate);
                startDate.Date = d;
            }
            else
            {
                startDate.Date = DateTime.Today;
            }

            if(_course.ObjectiveAssessmentEndDate != null)
            {
                DateTime x = Convert.ToDateTime(_course.ObjectiveAssessmentEndDate);
                startDate.Date = x;
            }
            else
            {
                startDate.Date = DateTime.Today;
            }
          
            startCheckBoxNotifications.IsChecked = _course.ObjectiveAssessmentStartNotifications;
            endCheckBoxNotifications.IsChecked = _course.ObjectiveAssessmentEndNotifications;
        }

        private void saveButton_Clicked(object sender, EventArgs e)
        {
            _course.ObjectiveAssessmentName = assessmentName.Text;
            _course.ObjectiveAssessmentStartDate = startDate.Date.ToShortDateString();
            _course.ObjectiveAssessmentEndDate = endDate.Date.ToShortDateString();
            _course.ObjectiveAssessmentStartNotifications = startCheckBoxNotifications.IsChecked;
            _course.ObjectiveAssessmentEndNotifications = endCheckBoxNotifications.IsChecked;

         

            Navigation.PopAsync();
        }

        private void cancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}