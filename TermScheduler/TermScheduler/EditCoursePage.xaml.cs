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
    public partial class EditCoursePage : ContentPage
    {
        public EditCoursePage()
        {
            InitializeComponent();
            courseStatus.Items.Add("Not Started");
            courseStatus.Items.Add("In Progress");
            courseStatus.Items.Add("Completed");
            courseStatus.Items.Add("Dropped");
        }

        private void cancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void saveButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}