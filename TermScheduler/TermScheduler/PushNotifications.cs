using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.LocalNotifications;
using System.Collections.ObjectModel;

namespace TermScheduler
{
    public static class PushNotifications
    {

        
        public static void CheckNotifications()
        {
            MainPage mainPage = App.Current.MainPage.Navigation.NavigationStack.First() as MainPage;
            ObservableCollection<Term> termList = mainPage.GetTermList();

            for(int i = 0; i < termList.Count; i++)
            {
                if (termList[i].TermStartNotifications)
                {
                    CrossLocalNotifications.Current.Show(termList[i].TermName, termList[i].TermName + " starts today!");
                }
            }
            
            CrossLocalNotifications.Current.Show("Test Alert", "Here is a push notification");
        }

        
    }
}
