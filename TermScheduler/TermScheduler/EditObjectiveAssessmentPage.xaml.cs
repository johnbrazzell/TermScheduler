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

    
  

       

        public EditObjectiveAssessmentPage()
        {
            InitializeComponent();
            Title = "Edit Objective Assessment";
       

           
            
        }


        private void saveButton_Clicked(object sender, EventArgs e)
        {
            
         

            Navigation.PopAsync();
        }

        private void cancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}