using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CH04.DataGridFilterDemo
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
            DependencyProperty.Register("Employees", typeof(ObservableCollection<Employee>), typeof(MainWindow), new PropertyMetadata(null));

        public MainWindow()
        {
            InitializeComponent();

            Employees = new ObservableCollection<Employee>
            {
                new Employee
                {
                    ID = "EMP0001",
                    FirstName = "Kunal", LastName = "Chowdhury",
                    Department = "Software Division"
                },

                new Employee
                {
                    ID = "EMP0002",
                    FirstName = "Michael", LastName = "Washington",
                    Department = "Software Division"
                },

                new Employee
                {
                    ID = "EMP0003",
                    FirstName = "John", LastName = "Strokes",
                    Department = "Finance Department"
                },

                new Employee
                {
                    ID = "EMP0004",
                    FirstName = "Ramesh", LastName = "Shukla",
                    Department = "Finance Department"
                }
            };
        }

        private void OnFilterChanged(object sender, TextChangedEventArgs e)
        {
            var cvs = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);
            if (cvs != null && cvs.CanFilter)
            {
                cvs.Filter = OnFilterApplied;
            }
        }

        private bool OnFilterApplied(object obj)
        {
            if(obj is Employee emp)
            {
                var searchText = searchBox.Text.ToLower();
                return emp.Department.ToLower().Contains(searchText) ||
                       emp.FirstName.ToLower().Contains(searchText) ||
                       emp.LastName.ToLower().Contains(searchText);
            }

            return false;
        }
    }
}
