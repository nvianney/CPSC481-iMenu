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

namespace CPSC481_iMenu
{
    /// <summary>
    /// Interaction logic for LocalSpecialWindow.xaml
    /// </summary>
    public partial class LocalSpecialWindow : Window
    {
        public LocalSpecialWindow()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
