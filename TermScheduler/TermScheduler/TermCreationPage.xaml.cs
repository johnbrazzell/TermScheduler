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


            //check to make sure dates are correct
            if(startTermDate.Date > endTermDate.Date)
            {
               
                AlertDateOverlap();
                return;
            }
            newTerm.TermName = termNameEntry.Text;
            newTerm.TermStartDate = startTermDate.Date.ToShortDateString();
            newTerm.TermEndDate = endTermDate.Date.ToShortDateString();
            newTerm.TermStartNotifications = startNofitications.IsChecked;
            newTerm.TermEndNotifications = endNotifications.IsChecked;

            _mainPage.AddTerm(newTerm);
            ////Reference the root page
            //_mainPage = App.Current.MainPage.Navigation.NavigationStack.First() as MainPage;
            ////_mainPage.term
            //AddTermView newTerm = new AddTermView();

            //if(String.IsNullOrEmpty(termNameEntry.Text))
            //{
            //    newTerm.SetTermName(defaultTermText);
            //}
            //else
            //{

            //    newTerm.SetTermName(termNameEntry.Text);
            //}

            
            
            //newTerm.SetStartTermLabel(startTermDate.Date.ToShortDateString());
            //newTerm.SetEndTermLabel(endTermDate.Date.ToShortDateString());


           // _mainPage.AddTermToList(newTerm);

            Navigation.PopAsync();
        }

        private void cancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void AlertDateOverlap()
        {
            
            await DisplayAlert("Alert", "Term Start Date cannot be greater than Term End Date", "OK");

            
        }
    }
}