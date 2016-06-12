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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public ObservableCollection<Element> elementsList;

        public MainWindow()
        {
            InitializeComponent();
            elementsList = new ObservableCollection<Element>();
            ListView1.ItemsSource = elementsList;
            Element elem = new Element();
            elem.name = "Dioda red";
            elem.elementSignature = "1A";
            elem.boxSignature = "A";
            elem.amount = 20;
            elementsList.Add(elem);


        }

        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }

}
