using CH07.MVVMDemo.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace CH07.MVVMDemo.Views
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel ViewModel = null;

        public MainWindow()
        {
            InitializeComponent();

            ViewModel = Resources["ViewModel"] as MainWindowViewModel;
            if (ViewModel == null) { throw new NullReferenceException("ViewModel can't be NULL"); }
        }

        private void CanExecute_AddCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            if (ViewModel != null)
            {
                var userDetails = ViewModel.NewUserDetails;
                e.CanExecute = !string.IsNullOrWhiteSpace(userDetails.Firstname) &&
                    !string.IsNullOrWhiteSpace(userDetails.Lastname);
            }
        }

        private void Execute_AddCommand(object sender, ExecutedRoutedEventArgs e)
        {
            ViewModel.UserCollection.Add(ViewModel.NewUserDetails);
            ViewModel.SelectedUser = ViewModel.NewUserDetails;
            ViewModel.NewUserDetails = new Models.UserModel();
        }
    }
}
