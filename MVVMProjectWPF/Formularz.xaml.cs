using ColorModes.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ColorModes
{
    /// <summary>
    /// Interaction logic for Formularz.xaml
    /// </summary>
    public partial class Formularz : Window
    {
        private Pracownik pracownik { get; set; }
        public Formularz(Pracownik pracownik)
        {
            InitializeComponent();
            this.DataContext = new ViewModel.PracownikViewModel(pracownik);

            Trace.WriteLine("Otwarto formularz");

        }

        public Formularz()
        {
            InitializeComponent();

            Trace.WriteLine("Otwarto formularz");

        }

        private void cmdAddPracownik_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pomyślnie dodano pracownika");
            
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
