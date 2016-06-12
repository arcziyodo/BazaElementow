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
    interface HowMany
    {
        void HowManyShow(int count);
    }
    class Counting : HowMany
    {
        public void Count(ObservableCollection<Element> elemList)
        {
            int count = 0;
            foreach (var item in elemList)
            {
                count = count + item.amount;

            }
            HowManyShow(count);
        }
        public void HowManyShow(int count)
        {
            MessageBox.Show("W bazie znajduje się " + count.ToString() + " elementów", "Liczba elementów w bazie", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
