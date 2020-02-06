using CH09.ClientDemo.EmployeeServiceReference;
using System.Collections.ObjectModel;
using System.Windows;

namespace CH09.ClientDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> Employees
        {
            get { return (ObservableCollection<Employee>)GetValue(EmployeesProperty); }
            set { SetValue(EmployeesProperty, value); }
        }

        public static readonly DependencyProperty EmployeesProperty = 
                    DependencyProperty.Register("Employees", 
                                                typeof(ObservableCollection<Employee>), 
                                                typeof(MainWindow),
                                                new PropertyMetadata(null));

        private static EmployeeServiceClient client = new EmployeeServiceClient();

        public MainWindow()
        {
            InitializeComponent();

            Loaded += (s, e) => RefreshListAsync();
        }

        private void OnRefreshClicked(object sender, RoutedEventArgs e)
        {
            RefreshListAsync();
        }

        private void OnAddClicked(object sender, RoutedEventArgs e)
        {
            AddNewEmployeeAsync();
            RefreshListAsync();
        }

        private async void RefreshListAsync()
        {
            var result = await client.GetEmployeesAsync();
            Employees = new ObservableCollection<Employee>(result);
        }

        private async void AddNewEmployeeAsync()
        {
            var employee = new Employee
            {
                ID = "EMP00" + (Employees.Count + 1),
                FirstName = "User",
                LastName = (Employees.Count + 1).ToString(),
                Designation = "Software Engineer"
            };

            await client.InsertEmployeeAsync(employee);
        }
    }
}
