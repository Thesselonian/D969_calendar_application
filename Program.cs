using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calendarApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var dbCon = DBConnection.Instance();
            dbCon.Server = "localhost";
            dbCon.DatabaseName = "client_schedule";
            dbCon.UserName = "sqlUser";
            dbCon.Password = "Passw0rd!";
            if (dbCon.IsConnect())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new loginForm(dbCon));
            }
        }
    }
}
