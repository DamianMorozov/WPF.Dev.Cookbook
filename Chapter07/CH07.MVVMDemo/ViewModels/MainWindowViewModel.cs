using CH07.MVVMDemo.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CH07.MVVMDemo.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private UserModel m_newUserDetails;
        public UserModel NewUserDetails
        {
            get { return m_newUserDetails; }
            set
            {
                m_newUserDetails = value;
                OnPropertyChanged("NewUserDetails");
            }
        }

        private UserModel m_selectedUser;
        public UserModel SelectedUser
        {
            get { return m_selectedUser; }
            set
            {
                m_selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        private ObservableCollection<UserModel> m_userCollection;
        public ObservableCollection<UserModel> UserCollection
        {
            get { return m_userCollection; }
            set
            {
                m_userCollection = value;
                OnPropertyChanged("UserCollection");
            }
        }

        public MainWindowViewModel()
        {
            UserCollection = new ObservableCollection<UserModel>
            {
                new UserModel
                {
                    Firstname = "User", Lastname = "One"
                },
                new UserModel
                {
                    Firstname = "User", Lastname = "Two"
                },
                new UserModel
                {
                    Firstname = "User", Lastname = "Three"
                },
                new UserModel
                {
                    Firstname = "User", Lastname = "Four"
                },
            };

            NewUserDetails = new UserModel();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}