using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ColorModes.Model
{

    [Table("Pracownicy")]
    public class Pracownik
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; } 
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public bool Plec { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public string NumerTelefonu { get; set; }
        public string Email { get; set; }
        public string Pesel { get; set; }
        public int IloscZaslug { get; set; }
    }

    
}
