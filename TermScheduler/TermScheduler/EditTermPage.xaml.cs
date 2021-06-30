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
        private string _termName;
        private DateTime _termStart;
        private DateTime _termEnd;
        private bool _termStartNotifications;
        private bool _termEndNotifications;

        private bool _isSaveButtonPressed = false;
        public EditTermPage(Term term)
        {
            InitializeComponent();
            _term = term;

            _termName = _term.TermName;
            _termStart = _term.TermStart;
            _termEnd = _term.TermEnd;
            _termStartNotifications = _term.TermStartNotifications;
            _termEndNotifications = _term.TermEndNotifications;

        }
        public EditTermPage()
        {
            InitializeComponent();

        }

        private void saveButton_Clicked(object sender, EventArgs e)
        {
            _isSaveButtonPressed = true;
            UpdateTerm();
            Navigation.PopAsync();
        }

        private void RevertChanges()
        {
            termNameEntry.Text = _termName;
            startTermDate.Date = _termStart;
            endTermDate.Date = _termEnd;
            startNofitications.IsChecked = _termStartNotifications;
            endNotifications.IsChecked = _termEndNotifications;
        }

        private void cancelButton_Clicked(object sender, EventArgs e)
        {
            _isSaveButtonPressed = false;
            RevertChanges();
            Navigation.PopAsync();
        }

        private async void UpdateTerm()
        {
            await DBService.UpdateTerm(_term);
        }

        protected override async void OnDisappearing()
        {
           if(!_isSaveButtonPressed)
            {

                RevertChanges();
            }
        }
    }
}