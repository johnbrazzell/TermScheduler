using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TermScheduler
{
   
    public partial class App : Application
    {
       
        public App()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new MainPage());
            
          

            
        }

        protected override void OnStart()
        {
            PushNotifications.CheckNotifications();

        }

        protected override void OnSleep()
        {
            PushNotifications.CheckNotifications();
        }

        protected override void OnResume()
        {
            PushNotifications.CheckNotifications();
        }
    }
}
