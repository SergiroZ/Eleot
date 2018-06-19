using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Eleot
{
    /// <summary>
    /// Логика взаимодействия для Win_Help.xaml
    /// </summary>
    public partial class Win_Help : Window
    {
        public Win_Help()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string s = "\tСправочная информация...";
            textBox.Text = s;
        }
    }
}