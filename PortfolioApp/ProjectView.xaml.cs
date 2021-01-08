using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static PortfolioApp.MainPage;

namespace PortfolioApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectView : ContentPage
    {
        public ProjectView(Project project)
        {
            InitializeComponent();
            this.Title = project.Title;
            listView.ItemsSource = new List<Project> { project };
        }
    }
}