using System;
using System.Windows;
using System.Windows.Controls;

namespace Eleot
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            string message = "Вы действительно хотите закончить\n" +
                "работу с приложением?";
            string caption = "Окончание работы.";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult defaultResult = MessageBoxResult.Yes;
            MessageBoxOptions options = MessageBoxOptions.ServiceNotification;
            // Show message box
            MessageBoxResult result = MessageBox.Show(
                message, caption, buttons, icon, defaultResult, options);

            if (result == MessageBoxResult.Yes)
            {
                // Closes the parent form.
                //this.Close();
                Environment.Exit(0);
            }
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Win_Help win_help = new Win_Help();
            win_help.Show();
        }

        private void Person_Click(object sender, RoutedEventArgs e)
        {
            Personals win_person = new Personals();
            win_person.Show();
        }
    }
}