    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;


using bot.acciones;
using Discord;
using Discord.WebSocket;
using bot.funciones;
using bot.mysql;
using bot.Exceptions;

namespace bot.actividad
{
    public class CargaDeMessage
    {
        private Dictionary<int, Mensage> collecionMensage;

        private configJson config = new configJson();

        private crudMessage dbMessage = new crudMessage();

        public CargaDeMessage()
        {
            
            cargarTabla();

        }
        public bool agregarMensage(Mensage mensage)
        {
         
            if (dbMessage.verificInTable(mensage.name) == 1)
            {
                Console.WriteLine("Ya existe mensage con este nombre. Usa otro.");
                return false;
            }
            else if(dbMessage.verificInTable(mensage.name) == 0)
            {

                bool vr = dbMessage.insertRow(mensage);
                if (vr)
                {
                    int id = dbMessage.obtenerIdForName(mensage.name);
                    collecionMensage.Add(id, new Mensage(mensage.name, mensage.mensage, mensage.embeds, mensage.canal_envio, mensage.guild_envio, mensage.user_create));
                    return true;

                }
                else { throw new EventsException("Error al agregar la accion.", EventsException.ERROR_INSERT); }


            }else
            {
                throw new EventsException("Error al agregar la accion.", EventsException.ERROR_INSERT);
            }


        }

        public bool updateMensage(int id, Mensage mensage)
        {
            bool vr = dbMessage.updateRow(id, mensage);

            if (vr)
            {
                collecionMensage[id] = new Mensage(mensage.name, mensage.mensage, mensage.embeds, mensage.canal_envio, mensage.guild_envio, mensage.user_create);

                return true;
            }
            else return false;

        }

        private void cargarTabla()
        {
            try
            {
                collecionMensage = dbMessage.getTable();

            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1146)
                {
                    if(dbMessage.createTable()) Console.WriteLine($"Se acaba de crear la tabla message con exito.");
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void activarMensage(int id)
        {
            collecionMensage[id].ejecutarMensage();
        }

        public Dictionary<int, Mensage> get() { return collecionMensage; }
    }
}
