using bot;
using bot.acciones;
using bot.mysql;
using Discord;
using Discord.WebSocket;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot.mysql
{
    public class crudEvento
    {

        private ConectMysql connect = new ConectMysql();

        private string CREATE_TABLE = "CREATE TABLE botdata.events (id INT NOT NULL AUTO_INCREMENT, name VARCHAR(45) NOT NULL, mensage TEXT(1000) NULL, embed JSON NOT NULL, tiempo_envio DATETIME NOT NULL, tiempo_reenvio VARCHAR(45) NULL, zone_hour VARCHAR(10) NOT NULL, canal_envio BIGINT NOT NULL, PRIMARY KEY(id));";

        private string SELECT_TABLE = "SELECT * FROM botdata.events;";

        private string INSERT_ROW = "INSERT INTO botdata.events (name, mensage, embed, tiempo_envio, tiempo_reenvio, zone_hour, canal_envio) VALUES (@name, @mensage, @embed, @tiempo_envio, @tiempo_reenvio, @zone_hour, @canal_envio);";

        private string IF_EXISTS = "SELECT IF( EXISTS( SELECT * FROM botdata.events WHERE name=@name), 1, 0);";

        private string DELETE_ROW = "DELETE FROM botdata.events WHERE (id = @id);";

        private string UPDATE_ROW = "UPDATE botdata.events SET mensage = @mensage, embed = @embed, tiempo_envio = @tiempo_envio, tiempo_reenvio = @tiempo_reenvio, zone_hour = @zone_hour, canal_envio = @canal_envio WHERE (id = @id);";

        private string ID_FOR_NAME = "SELECT id FROM botdata.events WHERE (id = @id)";

        public bool createTable()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(CREATE_TABLE, connect.Connection());

                cmd.ExecuteNonQuery();

                return true;

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error crear tabla:" + ex.ToString());
                return false;
            }
            finally
            {
                connect.Desconectar();
            }
        }

        public Dictionary<int, MensageRepetitive> getTable()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@SELECT_TABLE, connect.Connection());

                MySqlDataReader dr = cmd.ExecuteReader();

                Dictionary<int, MensageRepetitive> csm = new Dictionary<int, MensageRepetitive>();

                if (dr.HasRows)
                {
                    int id;
                    string name;
                    string mensage;
                    EmbedBuilder embed;
                    DateTime tiempoEnvio;
                    TimeSpan timeToRepeat;
                    string zoneHour;
                    SocketChannel canalEnvio;

                    while (dr.Read())
                    {
                        id = dr.GetInt32(0);
                        name = dr.GetString(1);
                        mensage = dr.GetString(2);
                        embed = embedJsonD(dr.GetString(3));
                        tiempoEnvio = dr.GetDateTime(4);
                        timeToRepeat = TimeSpan.Parse(dr.GetString(5));
                        zoneHour = dr.GetString(6);
                        canalEnvio = Bot.buscarCanal(dr.GetUInt64(7));

                        csm.Add(id, new MensageRepetitive(name, mensage, embed, tiempoEnvio, timeToRepeat, zoneHour, canalEnvio));
                    }

                }
                return csm;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
            finally
            {
                connect.Desconectar();
            }

        }

        public bool insertRow(MensageRepetitive mensageR)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(INSERT_ROW, connect.Connection());

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = mensageR.name;
                cmd.Parameters.Add("@mensage", MySqlDbType.Text).Value = mensageR.mensage;
                cmd.Parameters.Add("@embed", MySqlDbType.JSON).Value = embedJsonS(mensageR.embed);
                cmd.Parameters.Add("@tiempo_envio", MySqlDbType.DateTime).Value = mensageR.tiempoEnvio.ToString("yyyy:MM:dd HH:mm:ss");
                cmd.Parameters.Add("@tiempo_reenvio", MySqlDbType.VarChar).Value = mensageR.timeToRepeat.ToString();
                cmd.Parameters.Add("@zone_hour", MySqlDbType.VarChar).Value = mensageR.zoneHour;
                cmd.Parameters.Add("@canal_envio", MySqlDbType.Int64).Value = mensageR.canalEnvio.Id;

                cmd.ExecuteNonQuery();


                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                connect.Desconectar();

            }
        }

        public int verificInTable(string name)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(IF_EXISTS, connect.Connection());
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;

                var a = cmd.ExecuteReader();
                a.Read();
                return a.GetUInt16(0);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error verificar row: " + ex.ToString());
                return -1;
            }finally
            {
                connect.Desconectar();
            }
        }

        public bool deleteRow(int id)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(DELETE_ROW, connect.Connection());
                cmd.Parameters.Add("@name", MySqlDbType.Int64).Value = id;

                int a = cmd.ExecuteNonQuery();

                if (a >= 0) { return true; }
                else return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Errro: " + ex.Message);
                return false;
            }
            finally
            {
                connect.Desconectar();
            }
        }

        public bool updateRow(MensageRepetitive mensageR)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand(UPDATE_ROW, connect.Connection());

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = mensageR.name;
                cmd.Parameters.Add("@mensage", MySqlDbType.Text).Value = mensageR.mensage;
                cmd.Parameters.Add("@embed", MySqlDbType.JSON).Value = embedJsonS(mensageR.embed);
                cmd.Parameters.Add("@tiempo_envio", MySqlDbType.DateTime).Value = mensageR.tiempoEnvio.ToString("yyyy:MM:dd HH:mm:ss");
                cmd.Parameters.Add("@tiempo_reenvio", MySqlDbType.VarChar).Value = mensageR.timeToRepeat.ToString();
                cmd.Parameters.Add("@zone_hour", MySqlDbType.VarChar).Value = mensageR.zoneHour;
                cmd.Parameters.Add("@canal_envio", MySqlDbType.Int64).Value = mensageR.canalEnvio.Id;


                int a = cmd.ExecuteNonQuery();

                if (a >= 0) { return true; }
                else return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Errro: " + ex.Message);
                return false;
            }
            finally
            {
                connect.Desconectar();
            }
        }

        public int obtenerIdForName(string name)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand(ID_FOR_NAME, connect.Connection());

                cmd.Parameters.Add("@name", MySqlDbType.Text).Value = name;


                var a = cmd.ExecuteReader();

                a.Read();

                return a.GetInt16(0);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener id: " + ex.Message);
                return -1;
            }
            finally
            {
                connect.Desconectar();
            }
        }


        private string embedJsonS(EmbedBuilder embed)
        {
            return JsonConvert.SerializeObject(embed);
        }
        private EmbedBuilder embedJsonD(string embed)
        {
            return JsonConvert.DeserializeObject<EmbedBuilder>(embed);
        }

    }
}
