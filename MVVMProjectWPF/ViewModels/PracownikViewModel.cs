using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ColorModes.Model;
using ColorModes.Services;

namespace ColorModes.ViewModel
{
    public class PracownikViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Pracownik SelectedPracownik { get; set; }
        private void NotifyPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private int pracownikId;
        public int PracownikId
        {
            get { return pracownikId; }
            set
            {
                pracownikId = value;
                NotifyPropertyChanged("PracownikId");
            }
        }

        private string pracownikImie;
        public string PracownikImie
        {
            get { return pracownikImie; }
            set
            {
                pracownikImie = value;
                NotifyPropertyChanged("PracownikImie");
            }
        }

        private string pracownikNazwisko;
        public string PracownikNazwisko
        {
            get { return pracownikNazwisko; }
            set
            {
                pracownikNazwisko = value;
                NotifyPropertyChanged("PracownikNazwisko");
            }
        }

        private bool pracownikPlec;
        public bool PracownikPlec
        {
            get;
            set;
        }

        private string pracownikAdresMiasto;
        public string PracownikAdresMiasto
        {
            get { return pracownikAdresMiasto; }
            set
            {
                pracownikAdresMiasto = value;
                NotifyPropertyChanged("PracownikAdresMiasto");
            }
        }

        private string pracownikAdresUlica;
        public string PracownikAdresUlica
        {
            get { return pracownikAdresUlica; }
            set
            {
                pracownikAdresUlica = value;
                NotifyPropertyChanged("PracownikAdresUlica");
            }
        }

        private string pracownikNumerTelefonu;
        public string PracownikNumerTelefonu
        {
            get { return pracownikNumerTelefonu; }
            set
            {
                pracownikNumerTelefonu = value;
                NotifyPropertyChanged("PracownikNumerTelefonu");
            }
        }

        private string pracownikEmail;
        public string PracownikEmail
        {
            get { return pracownikEmail; }
            set
            {
                pracownikEmail = value;
                NotifyPropertyChanged("PracownikEmail");
            }
        }

        private string pracownikPesel;
        public string PracownikPesel
        {
            get { return pracownikPesel; }
            set
            {
                pracownikPesel = value;
                NotifyPropertyChanged("PracownikPesel");
            }
        }

        private int pracownikIloscZaslug;
        public int PracownikIloscZaslug
        {
            get { return pracownikIloscZaslug; }
            set
            {
                pracownikIloscZaslug = value;
                NotifyPropertyChanged("PracownikIloscZaslug");
            }
        }

        private Pracownik pracownikMiesiaca;
        public Pracownik PracownikMiesiaca
        {
            get { return pracownikMiesiaca; }
            set
            {
                pracownikMiesiaca = value;
                NotifyPropertyChanged("PracownikMiesiaca");

            }
        }

        private List<Pracownik> pracownikList;
        public List<Pracownik> PracownikList
        {
            get { return pracownikList; }
            set
            {
                pracownikList = value;
                NotifyPropertyChanged("PracownikList");

            }
        }
        private List<Pracownik> pracownikListByIloscZaslug;
        public List<Pracownik> PracownikListByIloscZaslug
        {
            get { return pracownikListByIloscZaslug; }
            set
            {
                pracownikListByIloscZaslug = value;
                NotifyPropertyChanged("PracownikListByIloscZaslug");

            }
        }

        public ICommand cmdAddPracownik
        {
            get;
            private set;
        }

        public ICommand cmdEditPracownik
        {
            get;
            private set;
        }
        public ICommand cmdDeletePracownik
        {
            get;
            private set;
        }
        public bool CanExectute
        {
            get { return !string.IsNullOrEmpty(PracownikImie); }
        }

        public bool CanExectute2
        {
            get { return Pracownik.Equals(SelectedPracownik, null); }
        }

        public PracownikViewModel()
        {
            cmdAddPracownik = new RelayCommand(AddPracownik, () => CanExectute);
            cmdEditPracownik = new RelayCommand(EditPracownik, () => CanExectute2);
            cmdDeletePracownik = new RelayCommand(DeletePracownik, () => CanExectute2);
            getPracownik();
            getPracownikByIloscZaslug();

        }

        public PracownikViewModel(Pracownik pracownik)
        {
            if (pracownik != null)
            {
                PracownikId = pracownik.Id;
                PracownikImie = pracownik.Imie;
                PracownikNazwisko = pracownik.Nazwisko;
                PracownikPlec = pracownik.Plec;
                PracownikAdresMiasto = pracownik.Miasto;
                PracownikAdresUlica = pracownik.Ulica;
                PracownikNumerTelefonu = pracownik.NumerTelefonu;
                PracownikEmail = pracownik.Email;
                PracownikPesel = pracownik.Pesel;
                PracownikIloscZaslug = pracownik.IloscZaslug;

                cmdEditPracownik = new RelayCommand(EditPracownik, () => CanExectute);
                getPracownik();
                getPracownikByIloscZaslug();
            }
        }


        private async void AddPracownik()
        {

            var r = await App.PracownikDatabase.SavePracownikAsync(new Pracownik
            {
                Imie = PracownikImie,
                Nazwisko = PracownikNazwisko,
                Plec = PracownikPlec,
                Miasto = PracownikAdresMiasto,
                Ulica = PracownikAdresUlica,
                NumerTelefonu = PracownikNumerTelefonu,
                Email = PracownikEmail,
                Pesel = PracownikPesel,
                IloscZaslug = PracownikIloscZaslug,
            });
            getPracownik();
            getPracownikByIloscZaslug();
            Trace.WriteLine("Dodano pracownika");
        }

        private async void EditPracownik()
        {
            var r = await App.PracownikDatabase.EditPracownikAsync(new Pracownik
            {
                Id = PracownikId,
                Imie = PracownikImie,
                Nazwisko = PracownikNazwisko,
                Plec = PracownikPlec,
                Miasto = PracownikAdresMiasto,
                Ulica = PracownikAdresUlica,
                NumerTelefonu = PracownikNumerTelefonu,
                Email = PracownikEmail,
                Pesel = PracownikPesel,
                IloscZaslug = PracownikIloscZaslug,
            });
            getPracownik();
            getPracownikByIloscZaslug();
            Trace.WriteLine("Dodano pracownika");
        }

        private async void DeletePracownik()
        {
            await App.PracownikDatabase.DeletePracownikAsync(SelectedPracownik);
            getPracownik();
            getPracownikByIloscZaslug();

        }
        public async void getPracownik()
        {
            try
            {
                PracownikList = await App.PracownikDatabase.GetPracownikAsync();
                ((MainWindow)Application.Current.MainWindow).pracownikList.ItemsSource = PracownikList;
            }
            catch (Exception ex) { }
        }

        public async void getPracownikByIloscZaslug()
        {
            try
            {
                PracownikListByIloscZaslug = await App.PracownikDatabase.GetPracownikAsyncByIloscZaslug();
                PracownikMiesiaca = PracownikListByIloscZaslug.First();
                ((MainWindow)Application.Current.MainWindow).listPracownikByIloscZaslug.ItemsSource = PracownikListByIloscZaslug;
            }
            catch (Exception ex) { }

        }

        public void addPoints(int currentPoints, Pracownik pracownik)
        {
            currentPoints++;
            pracownik.IloscZaslug = currentPoints;
            Console.WriteLine(pracownik.IloscZaslug);
            editPracownikPoints(pracownik);
            getPracownik();
            getPracownikByIloscZaslug();

        }

        private async void editPracownikPoints(Pracownik pracownik)
        {
            var r = await App.PracownikDatabase.EditPracownikAsync(new Pracownik
            {
                Id = pracownik.Id,
                Imie = pracownik.Imie,
                Nazwisko = pracownik.Nazwisko,
                Plec = pracownik.Plec,
                Miasto = pracownik.Miasto,
                Ulica = pracownik.Ulica,
                NumerTelefonu = pracownik.NumerTelefonu,
                Email = pracownik.Email,
                Pesel = pracownik.Pesel,
                IloscZaslug = pracownik.IloscZaslug,
            });
            getPracownik();
            getPracownikByIloscZaslug();
            Trace.WriteLine("Dodano pracownika");
        }

        public async void updatePracownikPoints()
        {
            try
            {
                PracownikListByIloscZaslug = await App.PracownikDatabase.GetPracownikAsyncByIloscZaslug();
                PracownikMiesiaca = PracownikListByIloscZaslug.First();
                ((MainWindow)Application.Current.MainWindow).listPracownikByIloscZaslug.ItemsSource = PracownikListByIloscZaslug;
            }
            catch (Exception ex) { }

        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string name]
        {
            get
            {
                string result = null;

                if (name == "PracownikImie")
                {
                    if (this.pracownikImie == "")
                    {
                        result = "To pole nie może być puste";
                    }
                    else if (this.pracownikImie != null)
                    {
                        if (this.pracownikImie.Length > 20)
                        {
                            result = "Za dlugie imie! (max 20)";
                        }
                        else if (!Regex.IsMatch(this.pracownikImie, @"^[a-zżźćńółęąśŻŹĆĄŚĘŁÓŃA-Z]+$"))
                        {
                            result = "Zły format danych (tylko litery)";
                        }

                    }
                }

                if (name == "PracownikNazwisko")
                {
                    if (this.pracownikNazwisko == "")
                    {
                        result = "To pole nie może być puste";
                    }
                    else if (this.pracownikNazwisko != null)
                    {
                        if (this.pracownikNazwisko.Length > 20)
                        {
                            result = "Za dlugie nazwisko! (max 20)";
                        }
                        else if (!Regex.IsMatch(this.pracownikNazwisko, @"^[a-zżźćńółęąśŻŹĆĄŚĘŁÓŃA-Z]+$"))
                        {
                            result = "Zły format danych (tylko litery)";
                        }

                    }
                }

                if (name == "PracownikAdresMiasto")
                {
                    if (this.pracownikAdresMiasto == "")
                    {
                        result = "To pole nie może być puste";
                    }
                    else if (this.pracownikAdresMiasto != null)
                    {
                        if (this.pracownikAdresMiasto.Length > 20)
                        {
                            result = "Za dluga nazwa miasta! (max 20)";
                        }
                        else if (!Regex.IsMatch(this.pracownikAdresMiasto, @"^[a-zżźćńółęąśŻŹĆĄŚĘŁÓŃA-Z]+$"))
                        {
                            result = "Zły format danych (tylko litery)";
                        }

                    }
                }

                if (name == "PracownikAdresUlica")
                {
                    if (this.pracownikAdresUlica == "")
                    {
                        result = "To pole nie może być puste";
                    }
                    else if (this.pracownikAdresUlica != null)
                    {
                        if (this.pracownikAdresUlica.Length > 25)
                        {
                            result = "Za dluga nazwa ulicy! (max 25)";
                        }
                    }
                }

                if (name == "PracownikNumerTelefonu")
                {
                    if (this.pracownikNumerTelefonu == "")
                    {
                        result = "To pole nie może być puste";
                    }
                    else if (this.pracownikNumerTelefonu != null)
                    {
                        if (this.pracownikNumerTelefonu.Length > 9)
                        {
                            result = "Za dlugi numer telefonu! (max 9)";
                        }
                        else if (!Regex.IsMatch(this.pracownikNumerTelefonu, "^[0-9]+$"))
                        {
                            result = "Zły format danych (tylko litery)";
                        }
                    }
                }

                if (name == "PracownikEmail")
                {
                    if (this.pracownikEmail == "")
                    {
                        result = "To pole nie może być puste";
                    }
                    else if (this.pracownikEmail != null)
                    {
                        if (this.pracownikEmail.Length > 20)
                        {
                            result = "Za dlugi adres email! (max 25)";
                        }
                        else if (!Regex.IsMatch(this.pracownikEmail, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                        {
                            result = "Zły format danych (tylko litery)";
                        }
                    }
                }

                if (name == "PracownikPesel")
                {
                    if (this.pracownikPesel == "")
                    {
                        result = "To pole nie może być puste";
                    }
                    else if (this.pracownikPesel != null)
                    {
                        if (this.pracownikPesel.Length != 11)
                        {
                            result = "Pesel powinien wynosic 11 cyfr";
                        }
                        else if (!Regex.IsMatch(this.pracownikPesel, "^[0-9]+$"))
                        {
                            result = "Zły format danych (tylko litery)";
                        }
                    }
                }



                return result;
            }
        }
    }
}
