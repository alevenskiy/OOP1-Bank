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

namespace Task2
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ComboBox_Position.SelectedIndex = 0;

            this.grid_supp.Visibility = Visibility.Collapsed;

            ReturnView();
        }

        private void ReturnView()
        {
            this.text_surname.Focusable = false;
            this.text_name.Focusable = false;
            this.text_secondname.Focusable = false;
            this.text_phone.Focusable = false;
            this.text_passport.Focusable = false;

            this.text_surname.Clear();
            this.text_name.Clear();
            this.text_secondname.Clear();
            this.text_phone.Clear();
            this.text_passport.Clear();

            this.butt_surname.Content = "chng";
            this.butt_name.Content = "chng";
            this.butt_secondname.Content = "chng";
            this.butt_phone.Content = "chng";
            this.butt_passport.Content = "chng";
        }

        private bool CheckSave()
        {
            if(this.butt_surname.Content.ToString() == "save")
                return true;
            else if(this.butt_name.Content.ToString() == "save")
                return true;
            else if(this.butt_secondname.Content.ToString() == "save")
                return true;
            else if(this.butt_phone.Content.ToString() == "save")
                return true;
            else if(this.butt_passport.Content.ToString() == "save")
                return true;
            else
                return false;
        }

        private void ComboBox_Position_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_Position.SelectedIndex == 0)
            {
                if (manager != null && CheckSave())
                {
                    if (MessageBox.Show("Do you want to save?", "Save", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        manager.SaveClient();
                    
                    ReturnView();
                }

                this.butt_surname.Visibility = Visibility.Collapsed;
                this.butt_name.Visibility = Visibility.Collapsed;
                this.butt_secondname.Visibility = Visibility.Collapsed;
                this.butt_passport.Visibility = Visibility.Collapsed;

                if(consultant == null)
                    consultant = new Consultant(this);
                isConsultant = true;
            }
            else
            {
                if (consultant != null && CheckSave())
                {
                    if (MessageBox.Show("Do you want to save?", "Save", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        consultant.SaveClient();
                    
                        ReturnView();
                }

                this.butt_surname.Visibility = Visibility.Visible;
                this.butt_name.Visibility = Visibility.Visible;
                this.butt_secondname.Visibility = Visibility.Visible;
                this.butt_passport.Visibility = Visibility.Visible;

                if(manager == null)
                    manager = new Manager(this);
                isConsultant = false;
            }

            ReturnView();
        }

        private void Butt_Download_Click(object sender, RoutedEventArgs e)
        {
            if (isConsultant)
                consultant.LoadClient();
            else
                manager.LoadClient();
        }

        private void butt_surname_Click(object sender, RoutedEventArgs e)
        {
            if (this.butt_surname.Content.ToString() == "chng")
            {
                this.text_surname.Focusable = true;
                this.butt_surname.Content = "save";
            }
            else
            {
                this.text_surname.Focusable = false;
                this.butt_surname.Content = "chng";

                manager.SurnameChange(this.text_surname.Text);
            }
        }

        private void butt_name_Click(object sender, RoutedEventArgs e)
        {
            if (this.butt_name.Content.ToString() == "chng")
            {
                this.text_name.Focusable = true;
                this.butt_name.Content = "save";
            }
            else
            {
                this.text_name.Focusable = false;
                this.butt_name.Content = "chng";

                manager.NameChange(this.text_name.Text);
            }
        }

        private void butt_secondname_Click(object sender, RoutedEventArgs e)
        {
            if (this.butt_secondname.Content.ToString() == "chng")
            {
                this.text_secondname.Focusable = true;
                this.butt_secondname.Content = "save";
            }
            else
            {
                this.text_secondname.Focusable = false;
                this.butt_secondname.Content = "chng";

                manager.SecondnameChange(this.text_secondname.Text);
            }
        }

        private void butt_phone_Click(object sender, RoutedEventArgs e)
        {


            if (this.butt_phone.Content.ToString() == "chng")
            {
                this.text_phone.Focusable = true;
                this.butt_phone.Content = "save";
            }
            else
            {
                if (isConsultant)
                {
                    if (consultant.PhoneNumberChange(this.text_phone.Text))
                    {
                        this.text_phone.Focusable = false;
                        this.butt_phone.Content = "chng";
                    }
                }
                else
                {
                    if (manager.PhoneNumberChange(this.text_phone.Text))
                    {
                        this.text_phone.Focusable = false;
                        this.butt_phone.Content = "chng";
                    }
                }

            }

        }

        private void butt_passport_Click(object sender, RoutedEventArgs e)
        {
            if (this.butt_passport.Content.ToString() == "chng")
            {
                this.text_passport.Focusable = true;
                this.butt_passport.Content = "save";
            }
            else
            {
                this.text_passport.Focusable = false;
                this.butt_passport.Content = "chng";

                manager.PassportChange(this.text_passport.Text);
            }
        }

        private void Butt_Save_Click(object sender, RoutedEventArgs e)
        {
            if (isConsultant)
                consultant.SaveClient();
            else
                manager.SaveClient();
        }

        private void text_surname_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(this.text_surname.Focusable == true)
                this.text_surname.Background = new SolidColorBrush(Colors.White);
            else
                this.text_surname.Background = new SolidColorBrush(Colors.LightGray);
        }

        private void text_name_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.text_name.Focusable == true)
                this.text_name.Background = new SolidColorBrush(Colors.White);
            else
                this.text_name.Background = new SolidColorBrush(Colors.LightGray);
        }

        private void text_secondname_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.text_secondname.Focusable == true)
                this.text_secondname.Background = new SolidColorBrush(Colors.White);
            else
                this.text_secondname.Background = new SolidColorBrush(Colors.LightGray);
        }

        private void text_phone_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.text_phone.Focusable == true)
                this.text_phone.Background = new SolidColorBrush(Colors.White);
            else
                this.text_phone.Background = new SolidColorBrush(Colors.LightGray);
        }

        private void text_passport_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.text_passport.Focusable == true)
                this.text_passport.Background = new SolidColorBrush(Colors.White);
            else
                this.text_passport.Background = new SolidColorBrush(Colors.LightGray);
        }
    }
}
