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

        ObjectiveAssessment obj = null;
        Course _course = null;
        public EditObjectiveAssessmentPage(ObjectiveAssessment objectiveAssessment, Course course)
        {
            InitializeComponent();
            Title = "Edit Objective Assessment";
            obj = objectiveAssessment;
            _course = course;
            assessmentName.Text = obj.Name;
        }

        private void saveButton_Clicked(object sender, EventArgs e)
        {
            obj.Name = assessmentName.Text;
            obj.StartDate = startDate.Date.ToShortDateString();
            obj.EndDate = endDate.Date.ToShortDateString();
            obj.ActivateStartNotifications = startCheckBoxNotifications.IsChecked;
            obj.ActivateEndNotifications = endCheckBoxNotifications.IsChecked;

            _course.ObjectiveAssessment = obj;

            Navigation.PopAsync();
        }
    }
}