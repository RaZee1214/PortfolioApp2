using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PortfolioApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ProjectGroup> ProjectsList { get; set; } = new ObservableCollection<ProjectGroup>();
        
        public MainPage()
        {
            InitializeComponent();

            var projects = new List<Project>();

            string subtitleText = "testSubtitle";
            string bodyText = "testBody";

            ProjectsList.Add(new ProjectGroup("Uuuuuuuuuuuh", new[]
            {
                new Project(
                    title: "LLProject1",
                    subtitle: subtitleText,
                    imageSource: "https://i.gyazo.com/f2af3ad799ba568239dcf43a8bbf0cf3.png",
                    bodyText: bodyText
                ),
                new Project(
                    title: "LLProject2",
                    subtitle: subtitleText,
                    imageSource: "https://i.gyazo.com/f2af3ad799ba568239dcf43a8bbf0cf3.png",
                    bodyText: bodyText
                ),
                new Project(
                    title: "LLProject3",
                    subtitle: subtitleText,
                    imageSource: "https://i.gyazo.com/f2af3ad799ba568239dcf43a8bbf0cf3.png",
                    bodyText: "helpless"
                ),
                new Project(
                    title: "LLProject4",
                    subtitle: subtitleText,
                    imageSource: "https://i.gyazo.com/f2af3ad799ba568239dcf43a8bbf0cf3.png",
                    bodyText: bodyText
                ),
                new Project(
                    title: "LLProject5",
                    subtitle: subtitleText,
                    imageSource: "https://i.gyazo.com/f2af3ad799ba568239dcf43a8bbf0cf3.png",
                    bodyText: bodyText
                ),                
                new Project(
                    title: "LLProject6",
                    subtitle: subtitleText,
                    imageSource: "https://i.gyazo.com/f2af3ad799ba568239dcf43a8bbf0cf3.png",
                    bodyText: bodyText
                )
            }));

//            ProjectsList.Add(new ProjectGroup("Hurtig", new[]
//            {
//
//            }));

            ProjectsList = new ObservableCollection<ProjectGroup>(ProjectsList.OrderBy(x => x.Area));
            listView.ItemsSource = ProjectsList;
        }

        private async void PreviewProject(object sender, EventArgs e)
        {
            Button button = sender as Button;
            await Navigation.PushAsync(new ProjectView(button.BindingContext as Project));
        }

        private async void DeleteProject(object sender, EventArgs e)
        {
            Button button = sender as Button;
            var LL = button.BindingContext as Project;
            ProjectsList.FirstOrDefault(X => X.Any(y => y == LL))?.Remove(LL);
        }

        public class Project
        {
            public string Title { get; set; }
            public string Subtitle { get; set; }
            public string ImageSource { get; set; }
            public string BodyText { get; set; }

            public Project(string title, string subtitle, string imageSource, string bodyText)
            {
                Title = title;
                Subtitle = subtitle;
                ImageSource = imageSource;
                BodyText = bodyText;
            }
        }
        public class ProjectGroup : ObservableCollection<Project>
        {
            public string Area { get; set; }

            public ProjectGroup(string area) : base()
            {
                Area = area;
            }

            public ProjectGroup(string area, IEnumerable<Project> source) : base(source)
            {
                Area = area;
            }
        }

    }
}
