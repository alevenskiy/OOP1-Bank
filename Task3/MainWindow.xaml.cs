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

namespace Task3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Consultant consultant;
        Manager manager;
        bool isConsultant;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Butt_Download_Click(object sender, RoutedEventArgs e)
        {
            if (isConsultant)
                consultant.LoadClient();
            else
                manager.LoadClient();
        }

        private void Butt_Save_Click(object sender, RoutedEventArgs e)
        {
            if (isConsultant)
            {
                if (consultant.SaveClient())
                {
                    MessageBox.Show("Data saved", "Save Completed", MessageBoxButton.OK);
                }
            }
            else
            {
                if (manager.SaveClient())
                {
                    MessageBox.Show("Data saved", "Save Completed", MessageBoxButton.OK);
                }
            }
        }

        private void ComboBox_Position_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_Position.SelectedIndex == 0)
            {
                if (consultant == null)
                    consultant = new Consultant(this);
                isConsultant = true;

                //this.text_surname.Focusable = false;
                //this.text_name.Focusable = false;
                //this.text_secondname.Focusable = false;
                //this.text_passport.Focusable = false;
            }
            else
            {
                if (manager == null)
                    manager = new Manager(this);
                isConsultant = false;

                //this.text_surname.Focusable = true;
                //this.text_name.Focusable = true;
                //this.text_secondname.Focusable = true;
                //this.text_passport.Focusable = true;
            }
        }
    }
}
