using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    class DbConnection
    {
        private string Ip { get; set; }
        private string Name { get; set; }
        private string User { get; set; }
        private string Pass { get; set; }
        private string ConnectionString { get; set; }

        public DbConnection(string i, string n, string u, string p)
        {
            Ip = i;
            Name = n;
            User = u;
            Pass = p;
        }
        public MySqlConnection polaczenie()
        {
            ConnectionString = "Server=" + Ip + "; Database=" + Name + "; User Id=" + User + "; Password=" + Pass + "; Convert Zero Datetime=True";
            MySqlConnection polaczenie = new MySqlConnection(ConnectionString);
            return polaczenie;
        }

    }
}
