using System.Windows;

namespace CH04.ObjectBindingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public Person PersonDetails
        {
            get { return (Person)GetValue(PersonDetailsProperty); }
            set { SetValue(PersonDetailsProperty, value); }
        }

        public static readonly DependencyProperty PersonDetailsProperty =
            DependencyProperty.Register("PersonDetails", typeof(Person), typeof(MainWindow), new PropertyMetadata(null));


        public MainWindow()
        {
            InitializeComponent();

            PersonDetails = new Person
            {
                Name = "Kunal Chowdhury",
                Blog = "http://www.kunal-chowdhury.com",
                Experience = 10
            };

            DataContext = PersonDetails;
        }
    }
}
