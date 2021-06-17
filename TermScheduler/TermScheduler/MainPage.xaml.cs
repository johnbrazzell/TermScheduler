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
       
        List<Course> _courseList = new List<Course>();
        AddTermView _termView;
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
            //termStackLayout.Children.Add(new AddTermView());
            
        }

        //public List<AddTermView> GetTermList()
        //{
        //    List<AddTermView> termList = new List<AddTermView>();
        //    for(int i = 0; i < termStackLayout.Children.Count; i++)
        //    {
        //        termList.Add(termStackLayout.Children[i] as AddTermView);
        //    }
        //    return termList;

            
        //}

        public List<Course> GetClassList()
        {
            return _courseList;
        }

        //public void AddTermToList(AddTermView addTermView)
        //{
         
        //    termStackLayout.Children.Add(addTermView);
        //    //termStackLayout.Children.Insert()
        //}

        //public void RemoveTermFromList(AddTermView addTermView)
        //{
        //    termStackLayout.Children.Remove(addTermView);
        //}

        //I need to add inotifyproperty changes to course class
        //I need to add class list and term list as observable collection and create a term class
        // and add it to another carousel view 

        public void AddClassesToCarousel(AddTermView termView)
        {
            //for each class in term create a new CourseDetailView
            //add each course detail view to list
            //set itemsource of carousel to newly created list
            //term
            //courseCarouselView.ItemsSource = 

            //List<Course> courseList = termView.GetClassList();
            _courseList = termView.GetClassList();
            _termView = termView;
           // List<CourseViewCell> courseDetailList = new List<CourseViewCell>();
            
            //for (int i = 0; i < termView.GetClassList().Count; i++)
            //{
            //    //TermOverviewPage newClassPage = new TermOverviewPage(termView, termView.GetClass(i));
            //    //this.Children.Add(newClassPage);
            //    CourseViewCell newCourseDetailView = new CourseViewCell();
            //    courseDetailList.Add(newCourseDetailView);

            //}

            courseCarouselView.SetBinding(ItemsView.ItemsSourceProperty, "_courseList");

            courseCarouselView.ItemsSource = _courseList;

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

        private void editObjectiveAssessmentButton_Clicked(object sender, EventArgs e)
        {
           
            int pos = courseCarouselView.Position;
            Course course = _termView.GetClass(pos);
            Navigation.PushAsync(new EditObjectiveAssessmentPage(course));
        }

        private void editPerformanceAssessmentButton_Clicked(object sender, EventArgs e)
        {
            int pos = courseCarouselView.Position;
            Course course = _termView.GetClass(pos);
            Navigation.PushAsync(new EditPerformanceAssessmentPage(course));
        }

  
    }
}
