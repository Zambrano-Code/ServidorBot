using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

using bot.funciones;


namespace bot.mysql
{
    public class ConectMysql
    {
        private static configJson config = new configJson();

        private string SQL_CONNECTION = $"datasource={config.mysql.Datasource}; port={config.mysql.Port}; username={config.mysql.Username}; password={config.mysql.Password}; database={config.mysql.Database}; ";

        MySqlConnection conn;
        
        public ConectMysql()
        {
            conn = new MySqlConnection(SQL_CONNECTION);
        }

        public MySqlConnection Connection()
        {
            try
            {
                conn.Open();
                return conn;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
        public bool Desconectar()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }


    }
}
