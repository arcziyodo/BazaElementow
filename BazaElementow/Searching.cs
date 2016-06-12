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
using System.Collections.ObjectModel;

namespace BazaElementow
{
    public enum SearchOptions
    {
        None,
        ByAmount,
        ByName,
        ByElement,
        ByBox
    }
    public partial class MainWindow : Window
    {
        private void Search(SearchOptions options)
        {
            String text;
            ObservableCollection<Element> result = new ObservableCollection<Element>();
            if (options == SearchOptions.ByName)
            {
                text = this.NameTextBox.Text;
                foreach (var item in elementsList)
                {
                    if (item.name == text)
                    {
                        result.Add(item);
                    }
                }
            }
            else if (options == SearchOptions.ByElement)
            {
                text = this.ElementSignatureTextBox.Text;
                foreach (var item in elementsList)
                {
                    if (item.elementSignature == text)
                    {
                        result.Add(item);
                    }
                }
            }
            else
            {
                text = this.BoxSignatureTextBox.Text;
                foreach (var item in elementsList)
                {
                    if (item.boxSignature == text)
                    {
                        result.Add(item);
                    }
                }
            }
            ListView1.ItemsSource = result;
        }
        public void Search(int number)
        {
            ObservableCollection<Element> result = new ObservableCollection<Element>();
            Element eleme = new Element();
            foreach (var item in elementsList)
            {
                if (item.amount == number)
                {
                    result.Add(item);
                }
            }
            ListView1.ItemsSource = result;
        }


    }
}
