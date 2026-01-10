using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace kutuphaneotomasyonu.DAL
{
    public class DbConnection
    {
        private string connectionString =
        "Server=172.21.54.253;Database=26_132430034;Uid=26_132430034;Pwd=İnif123.;";
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
