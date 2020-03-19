using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CH04.DependencyPropertyDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Fields and properties

        public string Department { get { return "Software Engineering"; } }

        #endregion

        #region DependencyProperty

        public string PersonName
        {
            get { return (string)GetValue(PersonNameProperty); }
            set { SetValue(PersonNameProperty, value); }
        }

        public static readonly DependencyProperty PersonNameProperty =
            DependencyProperty.Register("PersonName", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty, OnPropertyChangedCallback),
                OnValidateValueCallback);

        private static void OnPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }

        private static bool OnValidateValueCallback(object value)
        {
            var result = false;
            if (value is string s)
            {
                var digits = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                var err = false;
                foreach (var item in digits)
                {
                    if (s.Contains(item.ToString()))
                    {
                        err = true;
                        break;
                    }
                }
                if (!err)
                    result = true;
            }
            if (!result)
                MessageBox.Show("PersonName cann't contains any digits!");
            return result;
        }

        #endregion

        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello " + PersonName);
        }

        private void OnReset(object sender, RoutedEventArgs e)
        {
            PersonName = string.Empty;
        }
    }
}
