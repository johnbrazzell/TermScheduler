using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotifications;
using Xamarin.Forms;


namespace TermScheduler
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Term> _termList = new ObservableCollection<Term>();
       
        private ObservableCollection<Course> _courseList = new ObservableCollection<Course>();

    
        public MainPage()
        {
            InitializeComponent();
       
            LoadTermsAndClasses();

            termCarouselView.SetBinding(ItemsView.ItemsSourceProperty, "_termList");
            termCarouselView.ItemsSource = _termList;
          
             

      
        }
        
  
        private async void LoadTermsAndClasses()
        {
            List<Term> terms = (List<Term>)await DBService.GetTerms();
            List<Course> courses = (List<Course>)await DBService.GetClasses();
            AlertTermCount(terms);
            AlertClassCount(courses);
            for (int i = 0; i < terms.Count; i++)
            {
                _termList.Add(terms[i]);
                
               
                for(int j = 0; j < courses.Count; j++)
                {
                    if(courses[j].TermID == terms[i].Id)
                    {
                        terms[i].AddCoursePage(courses[j]);
                    }
                }
       

               
            }

           
        }

        private async void AlertClassCount(List<Course> list)
        {
            string count = list.Count.ToString();
            await DisplayAlert("Course Count", "DB Class Count is " + count, "OK") ;


        }

        private async void AlertTermCount(List<Term> list)
        {
            string count = list.Count.ToString();
            await DisplayAlert("Course Count", "DB Term Count is " + count, "OK");


        }

        private async void RemoveTermsAndClasses(Term term)
        {
            ObservableCollection<Course> courses = term.GetCourseList();
            if (courses.Count > 0)
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    if(courses[i].TermID == term.Id)
                        await DBService.DeleteCourse(courses[i].Id);
                }
            }
            await DBService.DeleteTerm(term.Id);

        }
            
        public void AddTerm(Term term)
        {
            _termList.Add(term);
        }

        public ObservableCollection<Term> GetTermList()
        {
            return _termList;
        }
        public void RemoveTerm(Term term)
        {
            _termList.Remove(term);
          
        }

        private void addTerm_Clicked(object sender, EventArgs e)
        {
            //Show popup for user to input basic term information
            Navigation.PushAsync(new TermCreationPage());
            
            
        }

      
        //public void AddClassesToCarousel()
        //{
            

        //    int pos = termCarouselView.Position;
        //    Term term = _termList[pos];
        //    _courseList = term.GetCourseList();
       
        //}

   

        private void deleteTerm_Clicked(object sender, EventArgs e)
        {
            int pos = termCarouselView.Position;
            Term term = _termList[pos];

            if (_termList.Count > 0)
            {
                _termList.RemoveAt(pos);
                RemoveTermsAndClasses(term);
            }
            else
                return;
        }

        private void addCourseButton_Clicked(object sender, EventArgs e)
        {
            int pos = termCarouselView.Position;
            Term term = _termList[pos];
            Navigation.PushAsync(new AddCoursePage(term));
        }


        private void viewTermButton_Clicked(object sender, EventArgs e)
        {
            int pos = termCarouselView.Position;
            Term term = _termList[pos];
            Navigation.PushAsync(new TermOverviewPage(term));
        }

        private void editTerm_Clicked(object sender, EventArgs e)
        {
            int pos = termCarouselView.Position;
            Term term = _termList[pos];
            EditTermPage page = new EditTermPage();
            page.BindingContext = term;
            Navigation.PushAsync(page);
        }
    }
}
