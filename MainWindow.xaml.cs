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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FilterTuneWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void SelectWorkingDirectory_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open the file dialogue \n" +
                "Let user choose a file \n" +
                "Grab a list of similar files\n" +
                "Populate the combobox \n" +
                "Remember the directory");
        }
    }
}
