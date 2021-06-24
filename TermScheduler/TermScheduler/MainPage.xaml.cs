using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
           
            termCarouselView.SetBinding(ItemsView.ItemsSourceProperty, "_termList");
            termCarouselView.ItemsSource = _termList;


        }

     
        public void AddTerm(Term term)
        {
            _termList.Add(term);
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

      
        public void AddClassesToCarousel()
        {
            //for each class in term create a new CourseDetailView
            //add each course detail view to list
            //set itemsource of carousel to newly created list
            //term
            //courseCarouselView.ItemsSource = 

          

            //for (int i = 0; i < termView.GetClassList().Count; i++)
            //{
            //    //TermOverviewPage newClassPage = new TermOverviewPage(termView, termView.GetClass(i));
            //    //this.Children.Add(newClassPage);
            //    CourseViewCell newCourseDetailView = new CourseViewCell();
            //    courseDetailList.Add(newCourseDetailView);

            //}

            //int pos = termCarouselView.Position;

            //courseCarouselView.SetBinding(ItemsView.ItemsSourceProperty, "_courseList");

            //courseCarouselView.ItemsSource = _courseList;


            int pos = termCarouselView.Position;
            Term term = _termList[pos];
            _courseList = term.GetCourseList();

            //ObservableCollection<Course> courseList = term.GetCourseList();
            //courseList = term.GetCourseList();

           //courseCarouselView.SetBinding(ItemsView.ItemsSourceProperty, "_courseList");
           //courseCarouselView.ItemsSource = _courseList;

            //courseCarouselView.ItemTemplate = new DataTemplate(() =>
            //{
            //    Label courseNameLabel = new Label { };
            //    courseNameLabel.SetBinding(Label.TextProperty, "Name");
            //    Label courseStartLabel = new Label { };
            //    courseStartLabel.SetBinding(Label.TextProperty, "StartDate");

            //    StackLayout stackLayout = new StackLayout
            //    {
            //        Children = { courseNameLabel, courseStartLabel }
            //    };
            //    return stackLayout;
            //});
        }

   

        private void deleteTerm_Clicked(object sender, EventArgs e)
        {
            int pos = termCarouselView.Position;
            if (_termList.Count > 0)
                _termList.RemoveAt(pos);
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
