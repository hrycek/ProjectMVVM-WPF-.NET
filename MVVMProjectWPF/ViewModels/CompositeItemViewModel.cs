//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Diagnostics;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Input;
//using ColorModes.Model;
//using ColorModes.Services;

//namespace ColorModes.ViewModels
//{
//    public class CompositeItemViewModel: INotifyPropertyChanged
//    {
//        public event PropertyChangedEventHandler PropertyChanged;
//        private void NotifyPropertyChanged([CallerMemberName] string name = "")
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
//        }

//        private List<Pracownik> listaPracownikow;
//        public List<Pracownik> ListaPracownikow
//        {
//            get { return listaPracownikow; }
//            set
//            {
//                listaPracownikow = value;
//                NotifyPropertyChanged("ListaPracownikow");

//            }
//        }

//        private List<Zaklad> listaZakladow;
//        public List<Zaklad> ListaZakladow
//        {
//            get { return listaZakladow; }
//            set
//            {
//                listaZakladow = value;
//                NotifyPropertyChanged("ListaZakladow");

//            }
//        }

//        public CompositeItemViewModel()
//        {
//            getZaklad();
//            getPracownik();
//        }

//        public async void getZaklad()
//        {
//            ListaZakladow = await App.ZakladDatabase.GetZakladAsync();
//        }
//        public async void getPracownik()
//        {
//            ListaPracownikow = await App.PracownikDatabase.GetPracownikAsync();
//        }
//    }
//}
