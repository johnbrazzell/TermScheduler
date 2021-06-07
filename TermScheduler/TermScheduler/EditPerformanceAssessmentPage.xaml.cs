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
        AddTermView _tv = null;
        public EditPerformanceAssessmentPage(AddTermView tv, Course course)
        {
            InitializeComponent();
          
            
            Title = "Edit Performance Assessment";
            _tv = tv;
            _course = course;
        
            if(_course.PerformanceAssessment != null)
            {
                assessmentName.Text = _course.PerformanceAssessment.Name;

            }
          
      
        }

   
        private void saveButton_Clicked(object sender, EventArgs e)
        {

     

            PerformanceAssessment performance = new PerformanceAssessment();

            performance.Name = assessmentName.Text;
            performance.StartDate = startDate.Date.ToShortDateString();
            performance.EndDate = endDate.Date.ToShortDateString();
            performance.ActivateStartNotifications = startCheckBoxNotifications.IsChecked;
            performance.ActivateEndNotifications = endCheckBoxNotifications.IsChecked;
            

            _course.PerformanceAssessment = performance;

            MainPage _mainPage = App.Current.MainPage.Navigation.NavigationStack.First() as MainPage;
            List<AddTermView> termList = _mainPage.GetTermList();

            for(int i = 0; i < termList.Count; i++)
            {
                if(termList[i].GetTermName() == _tv.GetTermName())
                {
                    var classes = termList[i].GetClassList();
                    for(int j = 0; j < classes.Count; j++)
                    {
                        if(classes[j].Name == _course.Name)
                        {
                            classes[j].PerformanceAssessment = performance;
                        }
                    }
                }
            }

    
           
           
            
            Navigation.PopAsync();
        }

        private void cancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }


    }
}