using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CH04.DataGridSortDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
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
            dataGrid.ItemsSource = Employees;
        }

        private void OnSortByIdAsc(object sender, RoutedEventArgs e)
        {
            MakeSort(sender, e, "ID", ListSortDirection.Ascending);
        }

        private void OnSortByIdDesc(object sender, RoutedEventArgs e)
        {
            MakeSort(sender, e, "ID", ListSortDirection.Descending);
        }

        private void OnSortByFirstNameAsc(object sender, RoutedEventArgs e)
        {
            MakeSort(sender, e, "FirstName", ListSortDirection.Ascending);
        }

        private void OnSortByFirstNameDesc(object sender, RoutedEventArgs e)
        {
            MakeSort(sender, e, "FirstName", ListSortDirection.Descending);
        }

        private void OnSortByLastNameAsc(object sender, RoutedEventArgs e)
        {
            MakeSort(sender, e, "LastName", ListSortDirection.Ascending);
        }

        private void OnSortByLastNameDesc(object sender, RoutedEventArgs e)
        {
            MakeSort(sender, e, "LastName", ListSortDirection.Descending);
        }

        private void OnSortByDepartmentAsc(object sender, RoutedEventArgs e)
        {
            MakeSort(sender, e, "Department", ListSortDirection.Ascending);
        }

        private void OnSortByDepartmentDesc(object sender, RoutedEventArgs e)
        {
            MakeSort(sender, e, "Department", ListSortDirection.Descending);
        }

        private void MakeSort(object sender, RoutedEventArgs e, string propName, ListSortDirection sortDirection)
        {
            var source = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);
            if (source != null && source.CanSort)
            {
                source.SortDescriptions.Clear();
                if (sender is CheckBox checkBox)
                {
                    foreach (var child in gridMain.Children)
                    {
                        if (child is CheckBox getChild)
                        {
                            if (getChild != checkBox)
                            {
                                getChild.IsChecked = false;
                            }
                        }
                    }
                    if (checkBox.IsChecked == true)
                    {
                        source.SortDescriptions.Add(new SortDescription(propName, sortDirection));
                    }
                }
            }
        }
    }
}
