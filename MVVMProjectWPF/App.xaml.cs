using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ColorModes.Services;

namespace ColorModes
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static PracownikDatabaseService pracownikDatabase;

        public static PracownikDatabaseService PracownikDatabase
        {
            get
            {
                if (pracownikDatabase == null)
                {
                    string workingDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
                    pracownikDatabase = new PracownikDatabaseService(workingDirectory + "PracownicyDB.db");
                }
                return pracownikDatabase;
            }
        }
    }
}
