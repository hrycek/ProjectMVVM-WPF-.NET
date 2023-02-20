using ColorModes.Model;
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

namespace ColorModes
{
    /// <summary>
    /// Interaction logic for FormularzEdit.xaml
    /// </summary>
    public partial class FormularzEdit : Window
    {
        private Pracownik pracownik { get; set; }
        public FormularzEdit(Pracownik pracownik)
        {
            InitializeComponent();
            this.DataContext = new ViewModel.PracownikViewModel(pracownik);
        }

        private void cmdEditPracownik_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pomyślnie edytowano pracownika");

            this.Close();
        }
    }
}
