using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BazaElementow
{
    public partial class MainWindow : Window
    {
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            Element elem = new Element();
            elem.name = this.NameTextBox.Text;
            elem.elementSignature = this.ElementSignatureTextBox.Text;
            elem.boxSignature = this.BoxSignatureTextBox.Text;
            if (this.NameTextBox.Text != "" && this.AmountTextBox.Text != "" && this.ElementSignatureTextBox.Text != "" && this.BoxSignatureTextBox.Text != "")
            {
                try
                {
                    elem.amount = int.Parse(this.AmountTextBox.Text);
                    elementsList.Add(elem);
                }
                catch (Exception)
                {
                    MessageBox.Show("Nie podałeś wartości liczbowej w polu Liczba", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Formularz zawiera puste pola", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            ListView1.ItemsSource = elementsList;

        }
        private void buttonClean_Click(object sender, RoutedEventArgs e)
        {
            this.NameTextBox.Text = "";
            this.AmountTextBox.Text = "";
            this.ElementSignatureTextBox.Text = "";
            this.BoxSignatureTextBox.Text = "";
            ListView1.ItemsSource = elementsList;

        }
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchOptions option;
            option = Check();
        
            if (option == SearchOptions.ByAmount)
            {
                try
                {
                    Search(int.Parse(this.AmountTextBox.Text));
                }
                catch (Exception)
                {
                    MessageBox.Show("Nie podałeś wartości liczbowej w polu Liczba", "Błąd! ", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else if (option != SearchOptions.None)
            {
                Search(option);
            }
            else if (this.NameTextBox.Text == "" && this.AmountTextBox.Text == "" && this.ElementSignatureTextBox.Text == "" && this.BoxSignatureTextBox.Text == "")
            {
                MessageBox.Show("Wszystkie pola są puste, wypełnij jedno dowolne", "Błąd! ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("Zbyt wiele wypełnionych pól, wypełnij tylko jedno dowolne", "Błąd! ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Element deleteElement = (Element)ListView1.SelectedItems[0];
                elementsList.Remove(deleteElement);
            }
            catch
            {
                MessageBox.Show("Wybierz element, który chcesz usunąć!",
                 "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            ListView1.ItemsSource = elementsList;
        }
        private void buttonCount_Click(object sender, RoutedEventArgs e)
        {
            Counting cos = new Counting();
            cos.Count(elementsList);
        }
        private SearchOptions Check()
        {
            SearchOptions option = SearchOptions.None;
            if (this.NameTextBox.Text != "" && this.AmountTextBox.Text == "" && this.ElementSignatureTextBox.Text == "" && this.BoxSignatureTextBox.Text == "")
            {
                option = SearchOptions.ByName;
            }
            else if (this.NameTextBox.Text == "" && this.AmountTextBox.Text != "" && this.ElementSignatureTextBox.Text == "" && this.BoxSignatureTextBox.Text == "")
            {
                option = SearchOptions.ByAmount;
            }
            else if (this.NameTextBox.Text == "" && this.AmountTextBox.Text == "" && this.ElementSignatureTextBox.Text != "" && this.BoxSignatureTextBox.Text == "")
            {
                option = SearchOptions.ByElement;
            }
            else if (this.NameTextBox.Text == "" && this.AmountTextBox.Text == "" && this.ElementSignatureTextBox.Text == "" && this.BoxSignatureTextBox.Text != "")
            {
                option = SearchOptions.ByBox;
            }
            return option;
        }
    }

}
