using Microsoft.Win32;
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

namespace Lab01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string sourcePath;// = "resources/Hornet.jpg";

        ObservableCollection<Person> people = new ObservableCollection<Person>
        {
            //new Person { Name = "P1", Age = 1, image = "resources/Hornet.jpg" },
            //new Person { Name = "P2", Age = 2, image = null }
        };

        public ObservableCollection<Person> Items
        {
            get => people;
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        
        private void AddNewPersonButton_Click(object sender, RoutedEventArgs e)
        {
            people.Add(new Person { image = sourcePath, Age = int.Parse(ageTextBox.Text), Name = nameTextBox.Text });
        }
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            //ImageViewer1.Source = new BitmapImage(new Uri("Creek.jpg", UriKind.Relative));
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == true)
            {
                FileNameLabel.Content = dlg.FileName;
                Image1.Source = new BitmapImage(new Uri(dlg.FileName));
            }
            sourcePath = dlg.FileName;
        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            if (list.SelectedIndex != -1)
            {
                Image1.Source = new BitmapImage(new Uri(people[list.SelectedIndex].image));
            }
            //Image1.Source = people[list.SelectedIndex].image;
        }
        }
    }