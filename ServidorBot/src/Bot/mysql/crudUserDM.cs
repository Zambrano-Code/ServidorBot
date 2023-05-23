using bot.acciones;
using bot.mysql;
using Discord;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using ServidorBot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bot.mysql
{
    public class crudUserDM
    {

        private ConectMysql connect = new ConectMysql();

        private string CREATE_TABLE = "CREATE TABLE botdata.userdm (idUserDM  BIGINT NOT NULL AUTO_INCREMENT, PRIMARY KEY(idUserDM));";

        private string SELECT_TABLE = "SELECT * FROM botdata.userdm;";

        private string INSERT_ROW = "INSERT INTO botdata.userdm (idUserDM) VALUES (@idUserDM);";

        private string IF_EXISTS = "SELECT IF( EXISTS( SELECT * FROM botdata.userdm WHERE idUserDM=@idUserDM), 1, 0);";

        private string DELETE_ROW = "DELETE FROM botdata.userdm WHERE (idUserDM = @idUserDM);";

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
                Console.WriteLine("Error crear tabla: \n\t" + ex.ToString());
                return false;
            }
            finally
            {
                connect.Desconectar();
            }
        }

        public List<IDMChannel> getTable()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@SELECT_TABLE, connect.Connection());

                MySqlDataReader dr = cmd.ExecuteReader();

                List<IDMChannel> csm = new List<IDMChannel>();


                if (dr.HasRows)
                {
                    ulong id;

                    IDMChannel canalDM;

                    while (dr.Read())
                    {
                        id = dr.GetUInt64(0);

                        canalDM = App.Bot.buscarDMUser(id);

                        csm.Add(canalDM);
                    }

                }
                return csm;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: getTable userdm: \n" + ex.Message);

                return null;
            }
            finally
            {
                connect.Desconectar();
            }

        }

        public bool insertRow(IDMChannel DMChanel)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(INSERT_ROW, connect.Connection());

                cmd.Parameters.Add("@idUserDM", MySqlDbType.VarChar).Value = DMChanel.Id;

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

        public int verificInTable(ulong idUserDM)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(IF_EXISTS, connect.Connection());
                cmd.Parameters.Add("@idUserDM", MySqlDbType.VarChar).Value = idUserDM;

                var a = cmd.ExecuteReader();
                a.Read();
                return a.GetUInt16(0);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error verificar row: " + ex.ToString());
                return -1;
            }
            finally
            {
                connect.Desconectar();
            }
        }

        public bool deleteRow(ulong idUserDM)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(DELETE_ROW, connect.Connection());
                cmd.Parameters.Add("@idUserDM", MySqlDbType.VarChar).Value = idUserDM;

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

        //public bool updateRow(int id, Mensage mensage)
        //{
        //    try
        //    {

        //        MySqlCommand cmd = new MySqlCommand(UPDATE_ROW, connect.Connection());

        //        cmd.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
        //        cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = mensage.name;
        //        cmd.Parameters.Add("@mensage", MySqlDbType.Text).Value = mensage.mensage;
        //        cmd.Parameters.Add("@embed", MySqlDbType.JSON).Value = embedJsonS(mensage.embed);
        //        cmd.Parameters.Add("@canal_envio", MySqlDbType.Int64).Value = mensage.canalEnvio.Id;


        //        int a = cmd.ExecuteNonQuery();

        //        if (a >= 0) { return true; }
        //        else return false;

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Errro: " + ex.Message);
        //        return false;
        //    }
        //    finally
        //    {
        //        connect.Desconectar();
        //    }
        //}

        //public int obtenerIdForName(string name)
        //{
        //    try
        //    {

        //        MySqlCommand cmd = new MySqlCommand(ID_FOR_NAME, connect.Connection());

        //        cmd.Parameters.Add("@name", MySqlDbType.Text).Value = name;


        //        var a = cmd.ExecuteReader();

        //        a.Read();

        //        return a.GetInt16(0);

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error al obtener id: " + ex.Message);
        //        return -1;
        //    }
        //    finally
        //    {
        //        connect.Desconectar();
        //    }
        //}


    }
}
