using BisolUITest.v1.Pages.Residents;
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

namespace BisolUITest.v1.Pages
{
    /// <summary>
    /// Interaction logic for Resident.xaml
    /// </summary>
    public partial class Resident : UserControl
    {
        public Resident()
        {
            InitializeComponent();

            // create and assign the appearance view model
            this.DataContext = new ResidentViewModel();
        }
    }
}
