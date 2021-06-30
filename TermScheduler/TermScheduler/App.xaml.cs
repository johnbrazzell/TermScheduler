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
            PushNotifications.CheckTermNotifications();
            PushNotifications.CheckCourseNotifications();

        }

        protected override void OnSleep()
        {
            PushNotifications.CheckTermNotifications();
            PushNotifications.CheckCourseNotifications();
        }

        protected override void OnResume()
        {
            PushNotifications.CheckTermNotifications();
            PushNotifications.CheckCourseNotifications();
        }
    }
}
