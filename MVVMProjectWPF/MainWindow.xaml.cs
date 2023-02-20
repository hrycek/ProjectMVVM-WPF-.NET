using ColorModes.Model;
using ColorModes.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorModes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Pracownik pracownik { get; set; }

        private PracownikViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = this.DataContext as PracownikViewModel;

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tabItem = ((sender as TabControl).SelectedItem as TabItem).Header as string;

            switch (tabItem)
            {
                case "Wyjście":
                    System.Windows.Application.Current.Shutdown();
                    break;

                case "Panel zarządzania":
                    if (pracownikList.SelectedItems.Count == 0)
                    {
                        Edytuj.IsEnabled = false;
                        Usun.IsEnabled = false;
                    }
                    break;

                default:
                    return;
            }
        }

        private void BlackMode_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorMode = "Black";

            //and to save the settings
            Properties.Settings.Default.Save();
        }

        private void DarkMode_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorMode = "Dark";

            //and to save the settings
            Properties.Settings.Default.Save();
        }

        private void LightkMode_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorMode = "Light";

            //and to save the settings
            Properties.Settings.Default.Save();
        }

        private void WhiteMode_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorMode = "White";

            //and to save the settings
            Properties.Settings.Default.Save();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Formularz formularz = new Formularz();
            formularz.Tytul.Text = "➕ Dodawanie pracownika ➕";
            formularz.ShowDialog();
        }


        private void Edytuj_Click(object sender, RoutedEventArgs e)
        {
            FormularzEdit formularz = new FormularzEdit(pracownik);
            formularz.Tytul.Text = "📋 Edycja pracownika 📋";
            formularz.ShowDialog();
        }

        private void pracownikList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView item = (ListView)sender;
            pracownik = (Pracownik)item.SelectedItem;
            if (item.SelectedItems.Count == 0)
            {
                Edytuj.IsEnabled = false;
                Usun.IsEnabled = false;
            }
            else
            {
                Edytuj.IsEnabled = true;
                Usun.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel.cmdDeletePracownik.Execute(pracownik);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        protected void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var pracownik = ((ListViewItem)sender).Content as Pracownik; //Casting back to the binded Track
            viewModel.addPoints(pracownik.IloscZaslug, pracownik);
            Trace.WriteLine("Kliknieto w pracownika " + pracownik.Imie);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Maximized)
            {
                this.BorderThickness = new System.Windows.Thickness(0);
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.BorderThickness = new System.Windows.Thickness(7);
                this.WindowState = WindowState.Maximized;
            }
            
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Szczegoly_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show(
                "Imie: \t \t" + viewModel.PracownikMiesiaca.Imie + "\n" +
                "Nazwisko: \t" + viewModel.PracownikMiesiaca.Nazwisko + "\n" +
                "Miasto: \t \t" + viewModel.PracownikMiesiaca.Miasto + "\n" +
                "Ulica: \t \t" + viewModel.PracownikMiesiaca.Ulica + "\n" +
                "NumerTelefonu: \t" + viewModel.PracownikMiesiaca.NumerTelefonu + "\n" +
                "Email: \t \t" + viewModel.PracownikMiesiaca.Email + "\n" +
                "Pesel: \t \t" + viewModel.PracownikMiesiaca.Pesel + "\n" +
                "IloscZaslug: \t" + viewModel.PracownikMiesiaca.IloscZaslug + "\n", "Pracownik miesiąca");
        }
    }


}
