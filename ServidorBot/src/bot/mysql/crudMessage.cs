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
    public class crudMessage
    {

        private ConectMysql connect = new ConectMysql();

        private string CREATE_TABLE = "CREATE TABLE botdata.message (id INT NOT NULL AUTO_INCREMENT, name VARCHAR(45) NOT NULL, mensage TEXT(1000) NULL, embeds JSON NOT NULL, canal_envio BIGINT NOT NULL, guild_envio BIGINT NOT NULL, user_create BIGINT NOT NULL, date_create DATETIME NOT NULL, PRIMARY KEY(id));";

        private string SELECT_TABLE = "SELECT * FROM botdata.message;";

        private string INSERT_ROW = "INSERT INTO botdata.message (name, mensage, embeds, canal_envio, guild_envio, user_create, date_create) VALUES (@name, @mensage, @embeds, @canal_envio, @guild_envio, @user_create, @date_create);";

        private string IF_EXISTS = "SELECT IF( EXISTS( SELECT * FROM botdata.message WHERE name=@name), 1, 0);";

        private string DELETE_ROW = "DELETE FROM botdata.message WHERE (id = @id);";

        private string UPDATE_ROW = "UPDATE botdata.message SET name = @name, mensage = @mensage, embeds = @embeds, canal_envio = @canal_envio, guild_envio = @guild_envio, user_create=@user_create, date_create = @date_create WHERE (id = @id);";

        private string ID_FOR_NAME = "SELECT id FROM botdata.message WHERE (id = @id)";

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

        public Dictionary<int, Mensage> getTable()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@SELECT_TABLE, connect.Connection());

                MySqlDataReader dr = cmd.ExecuteReader();

                Dictionary<int, Mensage> csm = new Dictionary<int, Mensage>();

                if (dr.HasRows)
                {
                    int id;
                    string name;
                    string mensage;
                    List<EmbedBuilder> embeds;
                    DateTime tiempo_envio;
                    TimeSpan time_to_repeat;
                    string zone_hour;
                    SocketChannel canal_envio;
                    SocketGuild guild_envio;
                    SocketUser user_create;
                    DateTime date_create;

                    while (dr.Read())
                    {
                        id = dr.GetInt16(0);
                        name = dr.GetString(1);
                        mensage = dr.GetString(2);
                        embeds = embedJsonD(dr.GetString(3));
                        tiempo_envio = dr.GetDateTime(4);
                        time_to_repeat = TimeSpan.Parse(dr.GetString(5));
                        zone_hour = dr.GetString(6);
                        canal_envio = Bot.buscarCanal(dr.GetUInt64(7));
                        guild_envio = Bot.buscarGuild(dr.GetUInt64(8));
                        user_create = Bot.buscarUser(dr.GetUInt64(9));
                        date_create = dr.GetDateTime(10);

                        csm.Add(id, new Mensage(name, mensage, embeds, canal_envio, guild_envio, user_create, date_create));
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

        public bool insertRow(Mensage mensage)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(INSERT_ROW, connect.Connection());

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = mensage.name;
                cmd.Parameters.Add("@mensage", MySqlDbType.Text).Value = mensage.mensage;
                cmd.Parameters.Add("@embeds", MySqlDbType.JSON).Value = embedJsonS(mensage.embeds);
                cmd.Parameters.Add("@canal_envio", MySqlDbType.Int64).Value = mensage.canal_envio.Id;
                cmd.Parameters.Add("@guild_envio", MySqlDbType.Int64).Value = mensage.guild_envio.Id;
                cmd.Parameters.Add("@user_create", MySqlDbType.Int64).Value = mensage.user_create.Id;
                cmd.Parameters.Add("@date_create", MySqlDbType.DateTime).Value = mensage.date_create.ToString("yyyy:MM:dd HH:mm:ss");

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
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

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

        public bool updateRow(int id, Mensage mensage)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand(UPDATE_ROW, connect.Connection());

                cmd.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = mensage.name;
                cmd.Parameters.Add("@mensage", MySqlDbType.Text).Value = mensage.mensage;
                cmd.Parameters.Add("@embeds", MySqlDbType.JSON).Value = embedJsonS(mensage.embeds);
                cmd.Parameters.Add("@canal_envio", MySqlDbType.Int64).Value = mensage.canal_envio.Id;
                cmd.Parameters.Add("@date_create", MySqlDbType.DateTime).Value = mensage.date_create;


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

        private string embedJsonS(List<EmbedBuilder> embed)
        {
            return JsonConvert.SerializeObject(embed);
        }
        private List<EmbedBuilder> embedJsonD(string embed)
        {
            return JsonConvert.DeserializeObject<List<EmbedBuilder>>(embed);
        }

    }
}
