using System;
using System.Collections.Generic;
using System.IO;
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

namespace Day03AllInputs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cmbContinentOfResidence.ItemsSource = Enum.GetValues(typeof(Continent));
        }

        private void btRegisterMe_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            if ("" == name)
            {
                MessageBox.Show(this, "Name must not be empty", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string age = "";
            if (true == rbAgeBelow18.IsChecked)
            {
                age = "Below 18";
            }
            else if (true == rbAge18To35.IsChecked)
            {
                age = "18 to 35";
            }
            else if (true == rbAge36AndAbove.IsChecked)
            {
                age = "36 or above";
            }
            else
            {
                MessageBox.Show(this, "Age must be selected", "Internal Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            List<string> petsList = new List<string>();
            if (true == cbCat.IsChecked)
            {
                petsList.Add("Cat");
            }
            if (true == cbDog.IsChecked)
            {
                petsList.Add("Dog");
            }
            if (true == cbOther.IsChecked)
            {
                petsList.Add("Other");
            }
            string pets = string.Join(",", petsList);

            string continentOfResidence = cmbContinentOfResidence.SelectedValue?.ToString();
            if (null == continentOfResidence)
            {
                MessageBox.Show(this, "Continent of residence must be selected", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double tempC = sldTempC.Value;

            string line = String.Format("{0};{1};{2};{3};{4}\n", name, age, pets, continentOfResidence, tempC);
            File.AppendAllText(@"../../result.txt", line);
            MessageBox.Show(this, "Register process is done", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}