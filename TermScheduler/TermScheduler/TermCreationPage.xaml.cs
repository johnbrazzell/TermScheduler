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
    public partial class TermCreationPage : ContentPage
    {
        private MainPage _mainPage;

        private string defaultTermText = "New Term";
        public TermCreationPage()
        {
            InitializeComponent();
        }

      

        private void addTermButton_Clicked(object sender, EventArgs e)
        {

            _mainPage = App.Current.MainPage.Navigation.NavigationStack.First() as MainPage;

            Term newTerm = new Term();

            if(String.IsNullOrEmpty(termNameEntry.Text))
            {
                AlertNameBlank();
                return;
            }

            //check to make sure dates are correct
            if(startTermDate.Date > endTermDate.Date)
            {
               
                AlertDateOverlap();
                return;
            }


            newTerm.TermName = termNameEntry.Text;
            newTerm.TermStart = startTermDate.Date;
            newTerm.TermEnd = endTermDate.Date;
            newTerm.TermStartNotifications = startNofitications.IsChecked;
            newTerm.TermEndNotifications = endNotifications.IsChecked;

            _mainPage.AddTerm(newTerm);
            AddTermToDB(newTerm);
       

            Navigation.PopAsync();
        }

        private async void AddTermToDB(Term term)
        {
            await DBService.AddTerm(term.TermName, term.TermStart, term.TermEnd, term.TermStartNotifications, term.TermEndNotifications);
        }

        private void cancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void AlertDateOverlap()
        {
            
            await DisplayAlert("Alert", "Term Start Date cannot be greater than Term End Date", "OK");

            
        }

        private async void AlertNameBlank()
        {

            await DisplayAlert("Alert", "Term name cannot be blank", "OK");


        }
    }
}