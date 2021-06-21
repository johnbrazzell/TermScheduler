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
        private Course _course = null;

   
        public EditPerformanceAssessmentPage()
        {
            InitializeComponent();
          
            
            Title = "Edit Performance Assessment";
            
           // _course = course;
        
          
          
      
        }

   
        private void saveButton_Clicked(object sender, EventArgs e)
        {

     

            

            //_course.PerformanceAssessmentName = assessmentName.Text;
            //_course.PerformanceAssessmentStartDate = startDate.Date.ToShortDateString();
            //_course.PerformanceAssessmentEndDate = endDate.Date.ToShortDateString();
            //_course.PerformanceAssessmentStartNotifications = startCheckBoxNotifications.IsChecked;
            //_course.PerformanceAssessmentEndNotifications = endCheckBoxNotifications.IsChecked;
            

        
            Navigation.PopAsync();
        }

        private void cancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }


    }
}