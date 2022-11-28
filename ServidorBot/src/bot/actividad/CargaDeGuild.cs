using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using bot.modelos;
using bot.mysql;
using MySql.Data.MySqlClient;

namespace back_bot.src.bot.actividad
{
    public class CargaDeGuild
    {
        private Dictionary<ulong, Guild> guilds;

        private crudGuild dbGuild = new crudGuild();

        public Dictionary<ulong, Guild> Guilds { get { return guilds; } }


        public CargaDeGuild()
        {
            cargarTabla();
        }


        private void cargarTabla()
        {
            try
            {

                guilds = dbGuild.getGuilds();

            }catch (MySqlException ex)
            {
                if (ex.Number == 1146)
                {
                    if (dbGuild.createTable()) Console.WriteLine($"Se acaba de crear la tabla message con exito.");
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine(ex.ToString());
            }
        }



        public string getLang(ulong id_guild)
        {

            try
            {
                return guilds[id_guild].lang;
            }
            catch (Exception ex)
            {
                Guild tempG = new Guild(id_guild, "es");
                if(dbGuild.insertGuild(tempG))
                {
                    Guilds.Add(id_guild, tempG);
                    return getLang(id_guild);
                }
                else
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        public bool updateLang(Guild guil)
        {
            try
            {
                if (dbGuild.updateGuild(guil))
                {
                    guilds[guil.id] = guil;
                    return true;
                }
                else
                {
                    return false;
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
