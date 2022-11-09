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
        private Dictionary<int, Mensage> collecionMensageRepetitive;

        private configJson config = new configJson();

        private crudMessage dbMessage = new crudMessage();

        public CargaDeMessage()
        {
            
            cargarTabla();

        }
        public bool agregarMRepetitivo(Mensage mensage)
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
                    collecionMensageRepetitive.Add(id, new Mensage(mensage.name, mensage.mensage, mensage.embed, mensage.canalEnvio));
                    return true;

                }
                else { throw new EventsException("Error al agregar la accion.", EventsException.ERROR_INSERT); }


            }else
            {
                throw new EventsException("Error al agregar la accion.", EventsException.ERROR_INSERT);
            }


        }

        public bool updateMRepetitivo(int id, Mensage mensage)
        {
            bool vr = dbMessage.updateRow(id, mensage);

            if (vr)
            {
                collecionMensageRepetitive[id] = new Mensage(mensage.name, mensage.mensage, mensage.embed, mensage.canalEnvio);

                return true;
            }
            else return false;

        }

        private void cargarTabla()
        {
            try
            {
                collecionMensageRepetitive = dbMessage.getTable();

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
            collecionMensageRepetitive[id].ejecutarMensage();
        }

        public Dictionary<int, Mensage> get() { return collecionMensageRepetitive; }
    }
}
