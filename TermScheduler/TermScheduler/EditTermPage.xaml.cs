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
    public partial class EditTermPage : ContentPage
    {
        private Term _term;
        public EditTermPage(Term term)
        {
            InitializeComponent();
            _term = term;
        }
        public EditTermPage()
        {
            InitializeComponent();
            
        }

        private void saveButton_Clicked(object sender, EventArgs e)
        {
            UpdateTerm();
            Navigation.PopAsync();
        }

        private void cancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void UpdateTerm()
        {
            await DBService.UpdateTerm(_term);
        }
    }
}