using bot;
using bot.acciones;
using bot.modelos;
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
    public class crudGuild
    {

        private ConectMysql connect = new ConectMysql();

        private string CREATE_TABLE = "CREATE TABLE botdata.guilds (id INT NOT NULL AUTO_INCREMENT, id_guild VARCHAR(45) NOT NULL, lang VARCHAR(5) NOT NULL, PRIMARY KEY(id));";

        private string SELECT_TABLE = "SELECT * FROM botdata.guilds;";

        private string INSERT_ROW = "INSERT INTO botdata.guilds (id_guild, lang) VALUES (@id_guild, lang );";

        private string IF_EXISTS = "select if( exists(select * from botdata.events where id_guild=@id_guild), 'true', 'false');";

        private string UPDATE_LANG = "UPDATE botdata.guilds SET lang = @lang WHERE (id = @id);";

        private string ID_FOR_GUILD_Id = "SELECT id FROM botdata.guilds WHERE (id_guild = @id_guild);";

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

        public Dictionary<ulong, Guild> getGuilds()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@SELECT_TABLE, connect.Connection());

                MySqlDataReader dr = cmd.ExecuteReader();

                Dictionary<ulong, Guild> csm = new Dictionary<ulong, Guild>();

                if (dr.HasRows)
                {
                    ulong id_guild;
                    string lang;

                    while (dr.Read())
                    {
                        id_guild = dr.GetUInt64(1);
                        lang = dr.GetString(2);

                        csm.Add(id_guild, new Guild(id_guild, lang));
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

        public bool insertGuild(Guild gld)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(INSERT_ROW, connect.Connection());

                cmd.Parameters.Add("@id_guil", MySqlDbType.VarChar).Value = gld.id;
                cmd.Parameters.Add("@lang", MySqlDbType.Text).Value = gld.lang;

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

        public string ifExist(ulong id_guild)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand(IF_EXISTS, connect.Connection());

                cmd.Parameters.Add("@id_guild", MySqlDbType.UInt64).Value = id_guild;

                var a = cmd.ExecuteReader();
                a.Read();
                return a.GetString(0);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error verificar row: " + ex.ToString());
                return "-1";
            }finally
            {
                connect.Desconectar();
            }
        }

        public bool updateGuild(Guild guild)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand(UPDATE_LANG, connect.Connection());

                cmd.Parameters.Add("@id_guild", MySqlDbType.UInt64).Value = guild.id;
                cmd.Parameters.Add("@lang", MySqlDbType.VarChar).Value =guild.lang;


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

        public string obtenerIdForIdGuild(ulong id_guild)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand(ID_FOR_GUILD_Id, connect.Connection());

                cmd.Parameters.Add("@id_guild", MySqlDbType.UInt64).Value = id_guild;


                var a = cmd.ExecuteReader();

                a.Read();

                return a.GetString(0);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener id: " + ex.Message);
                return "-1";
            }
            finally
            {
                connect.Desconectar();
            }
        }

    }
}
