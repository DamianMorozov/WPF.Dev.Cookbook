using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CH04.DataGridGroupDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> Employees
        {
            get => (ObservableCollection<Employee>)GetValue(EmployeesProperty);
            set => SetValue(EmployeesProperty, value);
        }

        public static readonly DependencyProperty EmployeesProperty =
            DependencyProperty.Register("Employees", typeof(ObservableCollection<Employee>), typeof(MainWindow), new PropertyMetadata(null));

        public MainWindow()
        {
            InitializeComponent();

            Employees = new ObservableCollection<Employee>
            {
                new Employee { ID = "EMP0001", FirstName = "Kunal", LastName = "Chowdhury", Department = "Software Division" },
                new Employee { ID = "EMP0002", FirstName = "Michael", LastName = "Washington", Department = "Software Division" },
                new Employee { ID = "EMP0003", FirstName = "John", LastName = "Strokes", Department = "Finance Department" },
                new Employee { ID = "EMP0004", FirstName = "Ramesh", LastName = "Shukla", Department = "Finance Department" }
            };
            //dataGrid.ItemsSource = Employees;
        }

        private void OnGroupByDepartment(object sender, RoutedEventArgs e)
        {
            OnGroup(sender, e, "Department");
        }
        
        private void OnGroup(object sender, RoutedEventArgs e, string propName)
        {
            var source = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);
            if (source != null && source.CanGroup)
            {
                source.GroupDescriptions.Clear();
                if (sender is CheckBox checkBox)
                {
                    if (checkBox.IsChecked == true)
                    {
                        source.GroupDescriptions.Add(new PropertyGroupDescription(propName));
                    }
                }
            }
        }
    }
}
