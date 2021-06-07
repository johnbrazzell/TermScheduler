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
    public partial class CourseCarouselPage : CarouselPage
    {

        //I think i need to pass in the term reference, or find the term
        //public CourseCarouselPage(string termTitle, List<Course> courses)
        public CourseCarouselPage(AddTermView termView)
        {
            InitializeComponent();

          
            //Populate carousel with pages based on amount of classes in term
            for(int i = 0; i < termView.GetClassList().Count; i++)
            {
                TermOverviewPage newClassPage = new TermOverviewPage(termView, termView.GetClass(i));
                this.Children.Add(newClassPage);
            }
    
        }

        public void ReloadPages(AddTermView termView)
        {
            
            for(int i = 0; i < this.Children.Count; i++)
            {
                this.Children.RemoveAt(i);
            }

            for (int i = 0; i < termView.GetClassList().Count; i++)
            {
                TermOverviewPage newClassPage = new TermOverviewPage(termView, termView.GetClass(i));
                this.Children.Add(newClassPage);
            }
        }

 
    }
}